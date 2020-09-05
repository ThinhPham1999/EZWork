using EZWork.Core.Abstract;
using EZWork.Core.Repository;
using EZWork.WebUI.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Areas.Admin.Controllers
{
    public class InvoiceAdminController : Controller
    {
        private readonly IInvoiceRepository invoiceRepository;
        public InvoiceAdminController()
        {
            invoiceRepository = new InvoiceRepository();
        }
        // GET: Admin/InvoiceAdmin
        public ActionResult Index(string searchTerm, int? page, int? statusCode, string datetimePicker)
        {
            int recordSize = 3;
            page = page ?? 1;
            statusCode = statusCode ?? 0;
            DateTime? time = Convert.ToDateTime(datetimePicker);
            ListInvoiceViewModel model = new ListInvoiceViewModel();
            model.DateTimePicker = time.Value;
            model.SearchTerm = searchTerm;
            model.Orders = invoiceRepository.SearchInvoice(searchTerm, page.Value, recordSize, statusCode, time).ToList();
            var totalRecord = invoiceRepository.SearchInvoiceCount(searchTerm, statusCode, time);
            model.Pager = new Pager(totalRecord, page, recordSize);
            return View(model);
            // return View();
        }

        public ActionResult ListInvoicePartial(string searchTerm, int? page, int? statusCode, string datetimePicker)
        {
            int recordSize = 3;
            page = page ?? 1;
            DateTime? time = Convert.ToDateTime(datetimePicker);
            ListInvoiceViewModel model = new ListInvoiceViewModel();
            model.DateTimePicker = time.Value;
            model.SearchTerm = searchTerm;
            model.Orders = invoiceRepository.SearchInvoice(searchTerm, page.Value, recordSize, statusCode, time).ToList();
            var totalRecord = invoiceRepository.SearchInvoiceCount(searchTerm, statusCode, time);
            model.Pager = new Pager(totalRecord, page, recordSize);
            return PartialView(model);
            // return View();
        }
        public ActionResult Detail(int? ID){
            if (!ID.HasValue) {
                HttpNotFound();
            }
            var invoice = invoiceRepository.Detail(ID.Value);
            return PartialView(invoice);
        }
    }
}