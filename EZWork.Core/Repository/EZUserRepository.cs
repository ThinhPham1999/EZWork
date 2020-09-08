using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZWork.Core.Abstract;
using EZWork.Core.Entities;
using EZWork.Core.DBContext;
using System.Data.Entity;

namespace EZWork.Core.Repository
{
    public class EZUserRepository : IEZUserRepository
    {
        private EZWorkDbContext db;
        
        public EZUserRepository()
        {
            db = new EZWorkDbContext();
        }

        public EZUser GetEZUserByID(string id)
        {
            var user = db.EZUsers.Find(id);
            return user;
        }

        public void UpdateEzUser(EZUser eZUser)
        {
            db.Entry(eZUser).State = EntityState.Modified;
            db.SaveChanges();
        }
        public bool InsertEZUser(EZUser eZUser) {
            db.EZUsers.Add(eZUser);
           return  db.SaveChanges()>0;
        }

       
    }
}
