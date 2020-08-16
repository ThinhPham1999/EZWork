using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZWork.Core.Entities;

namespace EZWork.Core.Abstract
{
    public interface ISKillRepository
    {
        int Create(Skill skill);
        int Update(Skill skill);
        int Delete(int id);
        Skill Find(int id);
        IEnumerable<Skill> Find(string name);
        IEnumerable<Skill> GetAll();
        IEnumerable<Skill> GetByCareer(string career);
    }
}
