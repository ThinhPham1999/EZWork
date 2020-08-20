using EZWork.Core.DBContext;
using EZWork.Core.Entities;
using EZWork.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Repository
{
    public class SellerRepository : ISellerRepository
    {
        private EZWorkDbContext db;

        public SellerRepository()
        {
            db = new EZWorkDbContext();
        }

        public List<Seller> GetAll()
        {
            return db.Sellers.ToList();
        }

        public List<Seller> SearchSeller(string searchTerm, string sellerID, int page, int recordSize)
        {
            var listSeller = db.Sellers.ToList();
            if (!String.IsNullOrEmpty(sellerID))
            {
                listSeller = listSeller.Where(x => x.SellerId.Equals(sellerID)).ToList();
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
                listSeller = listSeller.Where(x => x.EZUser.EZAccount.UserName.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            var skipSeller = (page - 1) * recordSize;
            return listSeller.OrderBy(x => x.SellerId).Skip(skipSeller).Take(recordSize).ToList();
        }
        public int SearchSellerCount(string searchTerm, string sellerID)
        {
            var listSeller = db.Sellers.ToList();
            if (!String.IsNullOrEmpty(sellerID))
            {
                listSeller = listSeller.Where(x => x.SellerId.Equals(sellerID)).ToList();
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
                listSeller = listSeller.Where(x => x.EZUser.EZAccount.UserName.ToLower().Contains(searchTerm.ToLower())).ToList();
            }

            return listSeller.Count;
        }

        public Seller GetSellerByID(string ID)
        {
            return db.Sellers.Find(ID);
        }
        public bool SaveSeller(Seller seller)
        {
            db.Sellers.Add(seller);
            return db.SaveChanges() > 0;
        }
        public bool UpdateSeller(Seller seller)
        {
            db.Entry(seller).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool DeleteSkill(Seller seller)
        {
            db.Entry(seller).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }
    }
}
