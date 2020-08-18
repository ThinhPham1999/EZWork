﻿using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Abstract
{
    public interface IEZSellerRepository
    {
        IEnumerable<Seller> Sellers { get; }
        IEnumerable<EZUser> EZUsers { get; }
        IEnumerable<SellerMapSkill> SellerMapSkills { get; }
        IEnumerable<Skill> Skills { get; }
    }
}
