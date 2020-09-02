using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EZWork.Core.Entities;
using EZWork.Core.Abstract;
using EZWork.Core.Repository;

namespace EZWork.WebUI.Areas.Admin.Controllers
{
    public class PayerController : Controller
    {
        private IPayerRepository payerRepository;

        public PayerController()
        {
            payerRepository = new PayerRepository();
        }
        

        [HttpGet]
        [Authorize(Roles = "Admin")]
        // GET: Admin/Payer
        public ActionResult Edit()
        {
            var payer = payerRepository.GetPayer(1);
            return View(payer);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PayerId,PayerAccountNumber,PayerAccountName,PayerBank")] Payer payer)
        {
            if (ModelState.IsValid)
            {
                payerRepository.EditPayer(payer);
                return RedirectToAction("Edit");
            }
            return View(payer);
        }
    }
}