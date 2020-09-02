using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZWork.Core.Entities;

namespace EZWork.Core.Abstract
{
    public interface IPayerRepository
    {
        void EditPayer(Payer payer);

        Payer GetPayer(int id);
    }
}
