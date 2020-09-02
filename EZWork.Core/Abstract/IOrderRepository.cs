using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Abstract
{
    public interface IOrderRepository
    {
        void Add(Order order, CardAccount card);
        void Delete(Order order);
        Order FindById(int id);
        IList<Order> FindByName(string name);
        void Edit(Order order);
        IList<Order> GetAll();
        void Dispose();
    }
}
