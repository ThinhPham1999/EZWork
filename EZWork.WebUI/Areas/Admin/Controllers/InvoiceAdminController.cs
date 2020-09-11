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
    [Authorize(Roles = "Admin")]
    public class InvoiceAdminController : Controller
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IOrderRepository orderRepository;
        public InvoiceAdminController()
        {
            invoiceRepository = new InvoiceRepository();
            orderRepository = new OrderRepository();
        }

        // GET: Admin/InvoiceAdmin
        public ActionResult Index(string searchTerm, int? page, int? statusCode, string datetimePicker)
        {
            int recordSize = 4;
            page = page ?? 1;
            statusCode = statusCode ?? 1;
            DateTime? time = Convert.ToDateTime(datetimePicker);
            ListInvoiceViewModel model = new ListInvoiceViewModel();
            model.DateTimePicker = time.Value;
            model.SearchTerm = searchTerm;
            model.StatusCode = statusCode.Value;
            int totalRecord = 0;
            if (statusCode == 1)
            {
                model.Orders = invoiceRepository.SearchInvoicePaied(searchTerm, page.Value, recordSize, statusCode, time).ToList();
                totalRecord = invoiceRepository.SearchInvoiceCountPaied(searchTerm, statusCode, time);
            }
            if (statusCode == 0)
            {
                model.Orders = invoiceRepository.SearchInvoiceNotPay(searchTerm, page.Value, recordSize, statusCode, time).ToList();
                totalRecord = invoiceRepository.SearchInvoiceCountNotPay(searchTerm, statusCode, time);
            }
            if (statusCode == 2)
            {
                model.Orders = invoiceRepository.SearchInvoiceCancel(searchTerm, page.Value, recordSize, statusCode, time).ToList();
                totalRecord = invoiceRepository.SearchInvoiceCountCancel(searchTerm, statusCode, time);
            }
            model.Pager = new Pager(totalRecord, page, recordSize);
            return View(model);
            // return View();
        }

        public ActionResult ListInvoicePartial(string searchTerm, int? page, int? statusCode, string datetimePicker)
        {
            int recordSize = 4;
            page = page ?? 1;
            statusCode = statusCode ?? 1;
            DateTime? time = Convert.ToDateTime(datetimePicker);
            ListInvoiceViewModel model = new ListInvoiceViewModel();
            model.DateTimePicker = time.Value;
            model.SearchTerm = searchTerm;
            model.StatusCode = statusCode.Value;
            int totalRecord = 0;
            if (statusCode == 1)
            {
                model.Orders = invoiceRepository.SearchInvoicePaied(searchTerm, page.Value, recordSize, statusCode, time).ToList();
                totalRecord = invoiceRepository.SearchInvoiceCountPaied(searchTerm, statusCode, time);
            }
            if (statusCode == 0)
            {
                model.Orders = invoiceRepository.SearchInvoiceNotPay(searchTerm, page.Value, recordSize, statusCode, time).ToList();
                totalRecord = invoiceRepository.SearchInvoiceCountNotPay(searchTerm, statusCode, time);
            }
            if (statusCode == 2)
            {
                model.Orders = invoiceRepository.SearchInvoiceCancel(searchTerm, page.Value, recordSize, statusCode, time).ToList();
                totalRecord = invoiceRepository.SearchInvoiceCountCancel(searchTerm, statusCode, time);
            }
            model.Pager = new Pager(totalRecord, page, recordSize);
            return PartialView(model);
            // return View();
        }

        public ActionResult Detail(int? ID)
        {
            if (!ID.HasValue)
            {
                HttpNotFound();
            }
            var invoice = invoiceRepository.Detail(ID.Value);
            return PartialView(invoice);
        }

        public JsonResult Action(int? ID, int? statusCode)
        {
            JsonResult json = new JsonResult();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var order = orderRepository.FindById(ID.Value);
            if (order != null)
            {
                if (statusCode.Value == 1)
                {
                    order.Status = 1;
                }
                if (statusCode.Value == 2)
                {
                    order.Status = 2;
                }
                orderRepository.Edit(order);
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false };
            }
            return json;
        }
    }
}