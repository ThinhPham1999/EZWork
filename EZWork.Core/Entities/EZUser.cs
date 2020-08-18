using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Entities
{
  public class EZUser
    {
        [ForeignKey("EZAccount")]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string BirthDay { get; set; }
        public string ImageProfile { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CreateAt { get; set; }
        public string ModifierAt { get; set; }
        public virtual EZAccount  EZAccount { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public virtual IList<ReplyComment> ReplyComments { get; set; }
        public virtual IList<Rating> Ratings { get; set; }
        public int Status { get; set; }
    }
}
