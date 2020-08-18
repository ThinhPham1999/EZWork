using EZWork.Core.Abstract;
using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.DBContext
{
    public class EFSellerRepository : IEZSellerRepository
    {
        private EZWorkDbContext context = new EZWorkDbContext();
        public IEnumerable<Seller> Sellers
        {
            get { return context.Sellers; }
        }
        public IEnumerable<EZUser> EZUsers 
        {
            get { return context.EZUsers; }
        }

        public IEnumerable<SellerMapSkill> SellerMapSkills
        {
            get { return context.SellerMapSkills; }
        }

        public IEnumerable<Skill> Skills
        {
            get { return context.Skills; }
        }

        
    }
}
