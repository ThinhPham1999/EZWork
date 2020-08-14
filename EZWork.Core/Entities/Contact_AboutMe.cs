using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Entities
{
    public class Contact_AboutMe
    {
        [Key]
        public int ContactId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Phone { get; set; }
        [StringLength(1024)]
        public string Address { get; set; }
        [Range(0, Int32.MaxValue)]
        public int PageCount { get; set; }
    }
}
