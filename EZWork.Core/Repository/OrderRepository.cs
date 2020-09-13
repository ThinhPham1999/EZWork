using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZWork.Core.Abstract;
using EZWork.Core.DBContext;
using EZWork.Core.Entities;

namespace EZWork.Core.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EZWorkDbContext db;

        public OrderRepository()
        {
            db = new EZWorkDbContext();
        }

        public void Add(Order order, CardAccount card)
        {
            order.CardAccount = card;
            db.Entry(order).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Delete(Order order)
        {
            db.Entry(order).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Edit(Order order)
        {
            if (order != null)
            {
                db.Entry(order).State = EntityState.Modified;
            }
            db.SaveChanges();
        }

        public Order FindById(int id)
        {
            return db.Orders.Find(id);
        }

        public IList<Order> FindByName(string name)
        {
            var user = db.EZUsers.Where(ez => ez.UserName.Equals(name)).FirstOrDefault();
            if (user != null)
            {
                return db.Orders.Where(o => o.EZUserId.Equals(user.Id)).ToList();
            }
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IList<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public IList<Order> FindByUserId(string userid)
        {
            var user = db.EZUsers.Find(userid);
            var orders = user.Orders;
            return orders.ToList();
        }

        public bool IsExistedOrder(string sellerID, string userid)
        {
            var review = db.Orders.Where(x => x.SellerId.Equals(sellerID) && x.EZUserId.Equals(userid)).SingleOrDefault();
            return review != null ? true : false;
        }

        public IEnumerable<Order> SearchOrder(string searchTerm, int page, int recordSize, int? statusCode, DateTime? time, string userid)
        {
            var orders = db.Orders.Where(o => o.EZUserId.Equals(userid)).ToList();
            if (statusCode.HasValue)
            {
                orders = orders.Where(x => x.Status == statusCode.Value).ToList();
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
                orders = orders.Where(x => x.Price.ToString().Contains(searchTerm)).ToList();
            }
            if (time.HasValue)
            {
                orders = orders.Where(x => x.CreateAt.CompareTo(time.Value) > 0).ToList();
            }
            var skip = (page - 1) * recordSize;
            //  skip = (1    -  1) = 0 * 3 = 0
            //  skip = (2    -  1) = 1 * 3 = 3
            //  skip = (3    -  1) = 2 * 3 = 6
            return orders.OrderBy(x => x.CreateAt).Skip(skip).Take(recordSize).ToList();
        }

        public int SearchOrderCount(string searchTerm, int? statusCode, DateTime? time, string userid)
        {
            var orders = db.Orders.Where(o => o.EZUserId.Equals(userid)).ToList();
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
