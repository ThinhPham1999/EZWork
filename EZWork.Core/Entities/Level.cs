﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Entities
{
    public class Level
    {
        public int LevelId { get; set; }
        public string Description { get; set; }
        public virtual List<SellerMapSkill> SellerMapSkills { get; set; }
    }
}
