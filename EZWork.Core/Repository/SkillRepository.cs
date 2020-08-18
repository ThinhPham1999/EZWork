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
            db.Skills.Add(skill);
            var career = db.Careers.Find(skill.Career.CareerId);
            career.Skills.Add(skill);
            skill.Career = career;
            db.SaveChanges();
            return 0;
        }

        public int Delete(int id)
        {
            var item = db.Skills.Find(id);
            db.Skills.Remove(item);
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

        public IEnumerable<Skill> GetAll()
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



        public List<Skill> SearchSkill(string searchTerm, int? carrerID, int page, int recordSize)
        {
            var listSkill = db.Skills.ToList();
            if (carrerID.HasValue)
            {
                listSkill = listSkill.Where(x => x.CareerId == carrerID.Value).ToList();
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
                listSkill = listSkill.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            var skipSkill = (page - 1) * recordSize;
            return listSkill.OrderBy(x => x.SkillId).Skip(skipSkill).Take(recordSize).ToList();
        }
        public int SearchSkillCount(string searchTerm, int? carrerID)
        {
            var listSkill = db.Skills.ToList();
            if (carrerID.HasValue)
            {
                listSkill = listSkill.Where(x => x.CareerId == carrerID.Value).ToList();
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
                listSkill = listSkill.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
            }

            return listSkill.Count;
        }

        public Skill GetSkillByID(int ID)
        {
            return db.Skills.Find(ID);
        }
        public bool SaveSkill(Skill skill)
        {
            db.Skills.Add(skill);
            return db.SaveChanges() > 0;
        }
        public bool UpdateSkill(Skill skill)
        {
            db.Entry(skill).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool DeleteSkill(Skill skill)
        {
            db.Entry(skill).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }
    }
}
