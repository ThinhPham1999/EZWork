using EZWork.Core.DBContext;
using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Abstract
{
    public interface ISellerRepository
    {
        List<Seller> SearchSeller(string searchTerm, string sellerID, int page, int recordSize);
        int SearchSellerCount(string searchTerm, string sellerID);
        Seller GetSellerByID(string ID);
        bool SaveSeller(Seller seller);
        bool UpdateSeller(Seller seller);
        bool DeleteSkill(Seller seller);
        List<Seller> GetAll();
    }
}
