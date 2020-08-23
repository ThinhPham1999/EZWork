using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZWork.Core.Entities;
using EZWork.Core.DBContext;
using EZWork.Core.Abstract;
using System.Data.Entity;

namespace EZWork.Core.Repository
{
    public class SkillRepository : ISKillRepository
    {
        private EZWorkDbContext db;

        public SkillRepository()
        {
            db = new EZWorkDbContext();
        }

        public int Create(Skill skill)
        {
            //Skill newSkill = new Skill
            //{
            //    Name = skill.Name,
            //    Description = skill.Description,
            //    UrlSlug = skill.UrlSlug
            //};

            //var career = db.Careers.Find(skill.Career.CareerId);
            //career.Skills.Add(newSkill);
            db.Entry(skill).State = EntityState.Added;

            db.SaveChanges();
            return 0;
        }

        public int Delete(int id)
        {
            var item = db.Skills.Find(id);
            db.Entry(item).State = EntityState.Deleted;
            db.SaveChanges();
            return 0;
        }

        public Skill Find(int id)
        {
            return db.Skills.Find(id);
        }

        public IEnumerable<Skill> Find(string name)
        {
            return db.Skills.Where(s => s.UrlSlug.Equals(name.ToLower()));
        }

        public IList<Skill> GetAll()
        {
            return db.Skills.ToList();
        }

        public IEnumerable<Skill> GetByCareer(string career)
        {
            return db.Skills.Where(s => s.Career.UrlSlug.Equals(career.ToLower()));
        }

        public int Update(Skill skill)
        {
            db.Entry(skill).State = EntityState.Modified;
            db.SaveChanges();
            return 0;
        }
    }
}
