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
    public class PayerRepository : IPayerRepository
    {
        private EZWorkDbContext db;

        public PayerRepository()
        {
            db = new EZWorkDbContext();
        }

        public void EditPayer(Payer payer)
        {
            if (payer != null)
            {
                db.Entry(payer).State = EntityState.Modified;
            }
            db.SaveChanges();
        }

        public Payer GetPayer(int id)
        {
            return db.Payers.Find(id);
        }
    }
}
