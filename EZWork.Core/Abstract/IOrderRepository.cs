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
        IList<Order> FindByUserId(string userid);
        bool IsExistedOrder(string sellerID, string userid);
        IEnumerable<Order> SearchOrder(string searchTerm, int page, int recordSize, int? statusCode, DateTime? time, string userid);
        int SearchOrderCount(string searchTerm, int? statusCode, DateTime? time, string userid);
        void Dispose();
    }
}
