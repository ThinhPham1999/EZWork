using EZWork.WebUI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EZWork.Core.Repository;
using EZWork.Core.Abstract;

namespace EZWork.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private ISellerRepository sellerRepository;

        public OrderController()
        {
            sellerRepository = new SellerRepository();
        }

        [Authorize(Roles = "User,Seller")]
        // GET: Order
        public ActionResult CreateOrder(string sellerId)
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            var seller = sellerRepository.GetSellerByID(sellerId);
            decimal Price = 0;

            orderViewModel.UserId = User.Identity.GetUserId();
            orderViewModel.SellerId = sellerId;
            return View(orderViewModel);
        }

        
    }
}