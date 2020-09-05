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
    public class LevelRepository : ILevelRepository
    {
        private readonly EZWorkDbContext db;

        public LevelRepository()
        {
            db = new EZWorkDbContext();
        }

        public void Add(Level level)
        {
            db.Entry(level).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Delete(int levelId)
        {
            var level = db.Levels.Find(levelId);
            if (level != null)
            {
                db.Entry(level).State = EntityState.Deleted;
            }
            db.SaveChanges();
        }

        public void Edit(Level level)
        {
            db.Entry(level).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<Level> GetAll()
        {
            return db.Levels.ToList();
        }
    }
}
