using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EZWork.Core.Abstract;
using EZWork.Core.Repository;
using EZWork.WebUI.Models;
using Microsoft.AspNet.Identity;

namespace EZWork.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IEZUserRepository EZUserRepository { get; set; }
        public UserController()
        {
            EZUserRepository = new EZUserRepository();
        }

        [HttpGet]
        [Authorize(Roles = "User,Seller")]
        // GET: User
        public ActionResult UserProfile()
        {
            var model = new UserViewModel();
            string id = User.Identity.GetUserId();
            var EZuser = EZUserRepository.GetEZUser(id);
            model.FullName = EZuser.FullName;
            model.Gender = EZuser.Gender;
            model.PhoneNumber = EZuser.EZAccount.PhoneNumber;
            model.Email = EZuser.EZAccount.Email;
            model.BirthDay = EZuser.BirthDay;
            model.ImageProfile = EZuser.ImageProfile;
            model.UserName = EZuser.UserName;
            return View("Profile", model);
        }

        [HttpPost]
        public ActionResult UserProfile(UserViewModel model, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    model.ImageProfile = User.Identity.GetUserId();
                    byte[] ImageData = new byte[image.ContentLength];
                    System.IO.Directory.CreateDirectory("~/Uploads/Profile");
                    System.IO.File.Move(image.FileName, model.ImageProfile);
                    //image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                //repository.SaveProduct(product);
                //TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                //there is something wrong with data value
                return View(model);
            }
        }

    }
}