using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Abstract
{
    public interface IInvoiceRepository
    {
        IEnumerable<Order> GetAllInvoice();
        IEnumerable<Order> SearchInvoiceNotPay(string searchTerm, int page, int recordSize,int? statusCode,DateTime? time);
        int SearchInvoiceCountNotPay(string searchTerm, int? statusCode,DateTime? time);
        IEnumerable<Order> SearchInvoicePaied(string searchTerm, int page, int recordSize, int? statusCode, DateTime? time);
        int SearchInvoiceCountPaied(string searchTerm, int? statusCode, DateTime? time);
        IEnumerable<Order> SearchInvoiceCancel(string searchTerm, int page, int recordSize, int? statusCode, DateTime? time);
        int SearchInvoiceCountCancel(string searchTerm, int? statusCode, DateTime? time);
        Order Detail(int ID);
    }
}
