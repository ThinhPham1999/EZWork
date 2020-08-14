﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Entities
{
    public class SellerMapSkill
    {
        [Key, Column(Order = 0)]
        public int SellerId { get; set; }
        [Key, Column(Order = 1)]
        public int SkillId { get; set; }
        public int Level { get; set; }

        public virtual Seller Seller { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
