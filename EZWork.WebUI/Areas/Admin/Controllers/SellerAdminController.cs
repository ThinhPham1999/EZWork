using EZWork.Core.Abstract;
using EZWork.Core.Entities;
using EZWork.Core.Repository;
using EZWork.WebUI.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Areas.Admin.Controllers
{
    public class SellerAdminController : Controller
    {
        private ISellerRepository sellerRepository;
        public SellerAdminController()
        {
            sellerRepository = new SellerRepository();
        }
        //private AccountRepository _userManager;
        //public AccountRepository UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<AccountRepository>();
        //    }
        //    set
        //    {
        //        _userManager = value;
        //    }
        //}
        //private RoleRepository _roleManager;
        //public RoleRepository RoleManager
        //{
        //    get
        //    {
        //        return _roleManager ?? HttpContext.GetOwinContext().Get<RoleRepository>();
        //    }
        //    private set
        //    {
        //        _roleManager = value;
        //    }
        //}

        //public ActionResult Index(string searchTerm, int? page)
        //{
        //    {
        //        int recordSize = 3;
        //        page = page ?? 1;
        //        ListAccountViewModel model = new ListAccountViewModel();
        //        model.SearchTerm = searchTerm;
        //        model.EZAccounts = SearchEZAccount(searchTerm, page.Value, recordSize);
        //        var totalRecord = SearchEZAccountCount(searchTerm);
        //        model.Pager = new Pager(totalRecord, page, recordSize);
        //        return View(model);
        //    }
        //}
        public ActionResult Index(string searchTerm,int? page)
        {
            int recordSize = 3;
            page = page ?? 1;
            ListSellerViewModel model = new ListSellerViewModel();
            model.SearchTerm = searchTerm;
            model.Sellers = SearchEZSeller(searchTerm, page.Value, recordSize);
            var totalRecord = SearchEZSellerCount(searchTerm);
            model.Pager = new Pager(totalRecord, page, recordSize);
            return View(model);

        }
        #region NonAction
        [NonAction]
        public List<Seller> SearchEZSeller(string searchTerm, int page, int recordSize)
        {
            var sellers = sellerRepository.GetAll().ToList();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                sellers = sellers.Where(x => x.EZUser.FullName.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            var skip = (page - 1) * recordSize;
            //  skip = (1    -  1) = 0 * 3 = 0
            //  skip = (2    -  1) = 1 * 3 = 3
            //  skip = (3    -  1) = 2 * 3 = 6
            return sellers.OrderBy(x => x.CreateAt).Skip(skip).Take(recordSize).ToList();
        }
        [NonAction]
        public int SearchEZSellerCount(string searchTerm)
        {
            var sellers = sellerRepository.GetAll().ToList();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                sellers = sellers.Where(x => x.EZUser.FullName.ToLower().Contains(searchTerm.ToLower())).ToList();
            }        
            return sellers.Count();
        }
        #endregion
        [HttpGet]
        public ActionResult Detail(string ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var seller = sellerRepository.GetSellerByID(ID);      
            return PartialView(seller);
        }
    }
}