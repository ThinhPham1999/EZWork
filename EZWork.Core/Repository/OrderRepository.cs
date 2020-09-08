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
    }
}
