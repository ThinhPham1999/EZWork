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
        IEnumerable<Order> SearchInvoice(string searchTerm, int page, int recordSize,int? statusCode,DateTime? time);
        int SearchInvoiceCount(string searchTerm, int? statusCode,DateTime? time);
        Order Detail(int ID);
    }
}
