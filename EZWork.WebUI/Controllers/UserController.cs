using System;
using System.Collections.Generic;
using System.IO;
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
            model.Gender = EZuser.Gender?? "";
            model.PhoneNumber = EZuser.EZAccount.PhoneNumber;
            model.Email = EZuser.EZAccount.Email;
            model.BirthDay = EZuser.BirthDay;
            model.ImageProfile = EZuser.ImageProfile;
            model.UserName = EZuser.UserName;
            return View("Profile", model);
        }

        [Authorize(Roles = "User,Seller")]
        [HttpPost]
        public ActionResult UserProfile(UserViewModel model, HttpPostedFileBase Image = null)
        {
            if (ModelState.IsValid)
            {
                var updateUser = EZUserRepository.GetEZUser(User.Identity.GetUserId());
                if (Image != null)
                {
                    model.ImageProfile = User.Identity.GetUserId();
                    byte[] ImageData = new byte[Image.ContentLength];
                    var fileName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                    model.ImageProfile = User.Identity.GetUserId() + fileName;
                    var path = Path.Combine(Server.MapPath("~/Uploads/Profile/"), model.ImageProfile);
                    Image.SaveAs(path);
                    updateUser.ImageProfile = model.ImageProfile;
                }

                updateUser.ModifierAt = DateTime.Now.ToString();
                updateUser.BirthDay = model.BirthDay;
                updateUser.FullName = model.FullName;
                updateUser.EZAccount.PhoneNumber = model.PhoneNumber;
                updateUser.Gender = model.Gender;

                EZUserRepository.UpdateEzUser(updateUser);

                return RedirectToAction("UserProfile");
            }
            else
            {
                return View(model);
            }
        }

    }
}