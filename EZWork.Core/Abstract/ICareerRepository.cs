using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Abstract
{
    public interface ICareerRepository
    {
        int CreateCareer(Career career);
        IEnumerable<Career> getAllCareers();
        Career Find(int id);
        Career Find(string name);
        int UpdateCareer(Career career);
        int Delete(int id);
    }
}
