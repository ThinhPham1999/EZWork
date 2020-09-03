using EZWork.Core.Abstract;
using EZWork.Core.DBContext;
using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private EZWorkDbContext db;
        public InvoiceRepository()
        {
            db = new EZWorkDbContext();
        }

        public Order Detail(int ID)
        {
            return db.Orders.SingleOrDefault(x => x.OrderId == ID);
        }

        public IEnumerable<Order> GetAllInvoice()
        {
          return db.Orders.ToList();
        }

        public IEnumerable<Order> SearchInvoice(string searchTerm, int page, int recordSize,int? statusCode,DateTime? time)
        {
            var orders = db.Orders.ToList();
            if (statusCode.HasValue) {
                orders = orders.Where(x => x.Status == statusCode.Value).ToList();
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
                orders = orders.Where(x => x.Price.ToString().Contains(searchTerm)).ToList();
            }
            if (time.HasValue) {
                orders = orders.Where(x => x.CreateAt.CompareTo(time.Value) > 0).ToList();
            }
            var skip = (page - 1) * recordSize;
            //  skip = (1    -  1) = 0 * 3 = 0
            //  skip = (2    -  1) = 1 * 3 = 3
            //  skip = (3    -  1) = 2 * 3 = 6
            return orders.OrderBy(x => x.CreateAt).Skip(skip).Take(recordSize).ToList();        
        }

        public int SearchInvoiceCount(string searchTerm, int? statusCode, DateTime? time)
        {
            var orders = db.Orders.ToList();
            if (statusCode.HasValue)
            {
                orders = orders.Where(x => x.Status == statusCode.Value).ToList();
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
              //  Consider FullName of Seller
                orders = orders.Where(x => x.Price.ToString().Contains(searchTerm)).ToList();
            }
            if (time.HasValue)
            {
                orders = orders.Where(x => x.CreateAt.CompareTo(time.Value) > 0).ToList();
            }
            return orders.Count();
        }
    }
}
