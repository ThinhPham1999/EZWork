using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Entities
{
    public class ReplyComment
    {
        [Key]
        public int ReplyCommentId { get; set; }
        public DateTime CreateAt { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(4096)]
        [Required(ErrorMessage = "Vui lòng nhập comment")]
        public string Content { get; set; }
        [Range(1, 3)]
        public int Status { get; set; }

      //  public virtual EZUser EZUser { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
