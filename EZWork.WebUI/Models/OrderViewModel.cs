using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EZWork.WebUI.Models
{
    public class OrderViewModel
    {
        public string CardName { get; set; }
        [Required]
        public string CardCode { get; set; }
        [Required]
        public string BankName { get; set; }
        public string SellerId { get; set; }
        public string UserId { get; set; }
        [Range(0, Int32.MaxValue)]
        [Display(Name = "Price(VND)")]
        public decimal Price { get; set; } 
    }
}