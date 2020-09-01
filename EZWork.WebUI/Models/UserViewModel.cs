using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EZWork.WebUI.Models
{
    public class UserViewModel
    {
        [Display(Name = "Full name: ")]
        public string FullName { get; set; }
        [Display(Name = "User Name: ")]
        public string UserName { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        public string BirthDay { get; set; }
        public string ImageProfile { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}