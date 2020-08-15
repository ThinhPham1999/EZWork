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
    public class CareerRepository : ICareerRepository
    {
        private readonly EZWorkDbContext db;

        public CareerRepository()
        {
            db = new EZWorkDbContext();
        }

        public void CreateCareer(Career career)
        {
            db.Careers.Add(career);
            db.SaveChanges();
        }

        public Career Find(int id)
        {
            return db.Careers.Find(id);
        }

        public Career Find(string name)
        {
            return db.Careers.Where(c => c.Name.Equals(name)).FirstOrDefault();
        }

        public IEnumerable<Career> getAllCareers()
        {
            return db.Careers.ToList();
        }

        public void UpdateCareer(Career career)
        {
            db.Entry(career).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Delete(int id)
        {
            var item = db.Careers.Find(id);
            if (item != null)
            {
                foreach(var skill in item.Skills)
                {
                    db.Skills.Remove(skill);
                }
            }
            db.Careers.Remove(item);
            db.SaveChanges();
        }
    }
}
