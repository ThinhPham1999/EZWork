using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Abstract
{
    public interface IEZUserRepository
    {
        void UpdateEzUser(EZUser eZUser);

        EZUser GetEZUser(string id);
    }
}
