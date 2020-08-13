using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Abstract
{
    public interface IAccountRepository
    {
        List<EZAccount> SearchEZAccount(string searchTerm, int page, int recordSize);
        int SearchIdentityUserCount(string searchTerm);
    }
}
