using EZWork.Core.Entities;
using EZWork.Core.Repository;
using EZWork.WebUI.Areas.Admin.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Test
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
            {
                int recordSize = 3;
                page = page ?? 1;
                ListAccountViewModel model = new ListAccountViewModel();
                model.searchTerm = searchTerm;
                model.EZAccounts = SearchEZAccount(searchTerm, page.Value, recordSize);
                var totalRecord = SearchEZAccountCount(searchTerm);
                model.Pager = new Pager(totalRecord, page, recordSize);
                return View(model);
            }
        }
        #region NonAction
        [NonAction]
        public List<EZAccount> SearchEZAccount(string searchTerm, int page, int recordSize)
        {
            var users = UserManager.Users.ToList();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = users.Where(x => x.UserName.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            var skip = (page - 1) * recordSize;
            //  skip = (1    -  1) = 0 * 3 = 0
            //  skip = (2    -  1) = 1 * 3 = 3
            //  skip = (3    -  1) = 2 * 3 = 6
            return users.OrderBy(x => x.UserName).Skip(skip).Take(recordSize).ToList();
        }
        [NonAction]
        public int SearchEZAccountCount(string searchTerm)
        {
            var users = UserManager.Users.ToList();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = users.Where(x => x.UserName.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            return users.Count();
        }
        #endregion
        [HttpGet]
        public async Task<ActionResult> Detail(string ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(ID);

            ViewBag.RoleNames = await UserManager.GetRolesAsync(user.Id);

            return PartialView(user);
        }

        [HttpPost]
        public async Task<JsonResult> LockUser(string ID, string status)
        {
            JsonResult json = new JsonResult();
            IdentityResult result = null;

            if (!string.IsNullOrEmpty(ID) && !string.IsNullOrEmpty(status)) //we are trying to delete a record
            {
                var user = await UserManager.FindByIdAsync(ID);
                //  result = await UserManager.DeleteAsync(user);
                if (status.ToLower().Equals("lock"))
                {
                    user.LockoutEnabled = true;
                    user.LockoutEndDateUtc= DateTime.UtcNow.AddMinutes(10000);
                   result= await UserManager.UpdateAsync(user);
                    // result = await UserManager.SetLockoutEnabledAsync(user.Id, true);

                }
                else if (status.ToLower().Equals("unlock"))
                {
                    //result = await UserManager.SetLockoutEnabledAsync(user.Id, false);
                    user.LockoutEnabled = false;
                    user.LockoutEndDateUtc = DateTime.UtcNow.AddMinutes(10000);
                  result=  await UserManager.UpdateAsync(user);
                }              
                json.Data = new { Success = result.Succeeded, Message = string.Join(", ", result.Errors) };
            }
            else
            {
                json.Data = new { Success = false, Message = "Invalid role." };
            }

            return json;
        }

        [HttpGet]
        public async Task<ActionResult> DetailRole(string ID)
        {
            ActionAccountRoleViewModel model = new ActionAccountRoleViewModel();
            if (!string.IsNullOrEmpty(ID))
            {
                model.UserID = ID;
                var user = await UserManager.FindByIdAsync(ID);
                var userRolesID = user.Roles.Select(x => x.RoleId).ToList();
                model.UserRoles = RoleManager.Roles.Where(x => userRolesID.Contains(x.Id.ToLower())).ToList();
                model.Roles = RoleManager.Roles.Where(x => !userRolesID.Contains(x.Id.ToLower())).ToList();
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<JsonResult> ActionRole(string IDRole, string ID, bool isDelete)
        {
            JsonResult json = new JsonResult();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            IdentityResult result;
            var user = await UserManager.FindByIdAsync(ID);
            var role = await RoleManager.FindByIdAsync(IDRole);

            if (user != null && role != null)
            {
                if (!isDelete)
                {
                    result = await UserManager.AddToRoleAsync(ID, role.Name);
                }
                else
                {
                    result = await UserManager.RemoveFromRoleAsync(ID, role.Name);
                }

                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false };
            }
            return json;
        }

    }
}