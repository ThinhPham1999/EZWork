using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Abstract
{
    public interface ILevelRepository
    {
        void Add(Level level);
        void Edit(Level level);
        void Delete(int level);
        List<Level> GetAll();
    }
}
