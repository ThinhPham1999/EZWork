using EZWork.WebUI.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Test
        public ActionResult Index() { 
        //{
        //    int recordSize = 3;
        //    page = page ?? 1;
        //    ListAccountViewModel model = new ListAccountViewModel();
        //    model.searchTerm = searchTerm;
        //    model.EZAccounts
        //    var totalRecord = categoryRepository.SearchedCategoryCount(searchTerm);
        //    model.Pager = new Pager(totalRecord,page, recordSize);
            return View();
        }
    }
}