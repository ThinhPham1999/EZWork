using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EZWork.Core.Abstract;
using EZWork.Core.Repository;
using EZWork.Core.Entities;
using System.Threading.Tasks;
using EZWork.WebUI.Areas.Admin.Models;

namespace EZWork.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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
            var list = careerRepository.getAllCareers();
            IList<CareerViewModel> listView = new List<CareerViewModel>();
            foreach(var item in list)
            {
                listView.Add(new CareerViewModel()
                {
                    CareerId = item.CareerId,
                    CareerName = item.Name,
                    CareerDescription = item.Description,
                    CareerUrlSlug = item.UrlSlug
                });
            }
            return Json(listView, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(CareerViewModel career)
        {
            Career newCareer = new Career()
            {
                CareerId = career.CareerId,
                Description = career.CareerDescription,
                UrlSlug = career.CareerUrlSlug,
                Name = career.CareerName
            };
            careerRepository.CreateCareer(newCareer);
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetbyID(int id)
        {
            var career = careerRepository.Find(id);
            CareerViewModel careerView = new CareerViewModel()
            {
                CareerId = career.CareerId,
                CareerName = career.Name,
                CareerUrlSlug = career.UrlSlug,
                CareerDescription = career.Description
            };
            return Json(careerView, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(CareerViewModel careerView)
        {
            var career = careerRepository.Find(careerView.CareerId);
            career.Name = careerView.CareerName;
            career.Description = careerView.CareerDescription;
            career.UrlSlug = careerView.CareerUrlSlug;
            careerRepository.UpdateCareer(career);
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            return Json(careerRepository.Delete(id), JsonRequestBehavior.AllowGet);
        }
    }
}