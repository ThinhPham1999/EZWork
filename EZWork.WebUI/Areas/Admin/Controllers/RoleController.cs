using EZWork.Core.Repository;
using EZWork.WebUI.Areas.Admin.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        // GET: Admin/Role    
        private AccountRepository _userManager;
        public AccountRepository UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<AccountRepository>();
            }
            set
            {
                _userManager = value;
            }
        }
        private RoleRepository _roleManager;
        public RoleRepository RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<RoleRepository>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        public ActionResult Index(string searchTerm, int? page)
        {
            int recordSize = 3;
            page = page ?? 1;
            ListRoleViewModels model = new ListRoleViewModels();
            model.SearchTerm = searchTerm;
            model.IdentityRoles = SearchIdentityRole(searchTerm, page.Value, recordSize);
            var totalRecord = SearchedIdentityRoleCount(searchTerm);
            model.Pager = new Pager(totalRecord, page, recordSize);
            return View(model);          
        }
        #region NonAction
        [NonAction]
        public List<IdentityRole> SearchIdentityRole(string searchTerm, int page, int recordSize)
        {
            var roles = RoleManager.Roles.ToList();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                roles = roles.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            var skip = (page - 1) * recordSize;
            //  skip = (1    -  1) = 0 * 3 = 0
            //  skip = (2    -  1) = 1 * 3 = 3
            //  skip = (3    -  1) = 2 * 3 = 6
            return roles.OrderBy(x => x.Name).Skip(skip).Take(recordSize).ToList();
        }
        [NonAction]
        public int SearchedIdentityRoleCount(string searchTerm)
        {
            var roles = RoleManager.Roles.ToList();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                roles = roles.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            return roles.Count();
        }
        #endregion
        [HttpGet]
        public async Task<ActionResult> Action(string ID)
        {
            ActionIdentityRoleViewModel model = new ActionIdentityRoleViewModel();

            if (!string.IsNullOrEmpty(ID)) //we are trying to edit a record
            {
                var role = await RoleManager.FindByIdAsync(ID);
                model.ID = role.Id;
                model.Name = role.Name;
            }
            return PartialView("Action", model);
        }

        [HttpPost]
        public async Task<JsonResult> Action(ActionIdentityRoleViewModel model)
        {
            JsonResult json = new JsonResult();
            IdentityResult result = null;
            if (!string.IsNullOrEmpty(model.ID)) //we are trying to edit a record
            {
                var role = await RoleManager.FindByIdAsync(model.ID);

                role.Name = model.Name;

                result = await RoleManager.UpdateAsync(role);
            }
            else //we are trying to create a record
            {
                var role = new IdentityRole();

                role.Name = model.Name;

                result = await RoleManager.CreateAsync(role);
            }

            json.Data = new { Success = result.Succeeded, Message = string.Join(", ", result.Errors) };

            return json;
        }


        [HttpPost]
        public async Task<JsonResult> Delete(string ID)
        {
            JsonResult json = new JsonResult();

            IdentityResult result = null;

            if (!string.IsNullOrEmpty(ID)) //we are trying to delete a record
            {
                var role = await RoleManager.FindByIdAsync(ID);

                result = await RoleManager.DeleteAsync(role);

                json.Data = new { Success = result.Succeeded, Message = string.Join(", ", result.Errors) };
            }
            else
            {
                json.Data = new { Success = false, Message = "Invalid role." };
            }

            return json;
        }
    }
}