using EZWork.Core.Abstract;
using EZWork.Core.Repository;
using EZWork.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Controllers
{
    public class CareerController : Controller
    {
        private ICareerRepository careerRepository;

        public CareerController()
        {
            careerRepository = new CareerRepository();
        }

        // GET: Career
        public ActionResult Index()
        {
            var career = new CareerViewModel()
            {
                Careers = careerRepository.getAllCareers()
            };
            return View(career);
        }

        public ActionResult ViewAll()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetMenu()
        {
            return PartialView("_CareerPartial");
        }
    }
}