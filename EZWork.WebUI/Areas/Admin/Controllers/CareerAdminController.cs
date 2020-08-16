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
            return View();
        }

        [HttpGet]
        public JsonResult List()
        {
            return Json(careerRepository.getAllCareers(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(Career career)
        {
            return Json(careerRepository.CreateCareer(career), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetbyID(int id)
        {
            var career = careerRepository.Find(id);
            return Json(career, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Career career)
        {
            return Json(careerRepository.UpdateCareer(career), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            return Json(careerRepository.Delete(id), JsonRequestBehavior.AllowGet);
        }
    }
}