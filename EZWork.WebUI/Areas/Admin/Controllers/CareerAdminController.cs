using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EZWork.Core.Abstract;
using EZWork.Core.Repository;
using EZWork.Core.Entities;
using System.Threading.Tasks;

namespace EZWork.WebUI.Areas.Admin.Controllers
{
    public class CareerAdminController : Controller
    {
        private ICareerRepository careerRepository;

        public CareerAdminController()
        {
            careerRepository = new CareerRepository();
        }

        // GET: Admin/Career
        public ActionResult Index()
        {
            var careers = careerRepository.getAllCareers();
            return View(careers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Career career)
        {
            if (ModelState.IsValid)
            {
                careerRepository.CreateCareer(career);
                return RedirectToAction("Index");
            }
            else
            {
                return View(career);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            careerRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}