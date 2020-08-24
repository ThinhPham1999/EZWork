using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public DateTime CreateAt { get; set; }
        [StringLength(4096)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Vui lòng nhập nội dung comment")]
        public string Content { get; set; }
        [Range(1,3)]
        public int Status { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual EZUser EZUser { get; set; }
        public virtual IList<ReplyComment> ReplyComments { get; set; }
    }
}
