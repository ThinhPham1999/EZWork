using EZWork.WebUI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EZWork.Core.Repository;
using EZWork.Core.Abstract;
using EZWork.Core.Entities;

namespace EZWork.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private ISellerRepository sellerRepository;
        private IOrderRepository orderRepository;
        private IEZUserRepository eZUserRepository;
        private readonly IPayerRepository payerRepository;

        public OrderController()
        {
            sellerRepository = new SellerRepository();
            orderRepository = new OrderRepository();
            eZUserRepository = new EZUserRepository();
            payerRepository = new PayerRepository();
        }

        [HttpGet]
        [Authorize(Roles = "User,Seller")]
        // GET: Order
        public ActionResult CreateOrder(string sellerId)
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            var seller = sellerRepository.GetSellerByID(sellerId);
            decimal Price = CalculatePrice(seller);

            orderViewModel.UserId = User.Identity.GetUserId();
            orderViewModel.SellerId = sellerId;
            orderViewModel.Price = Price;
            return View(orderViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "User,Seller")]
        public ActionResult CreateOrder(OrderViewModel model)
        {
            string id = User.Identity.GetUserId();
            var user = eZUserRepository.GetEZUserByID(id);
            
            Order order = new Order()
            {
                SellerId = model.SellerId,
                EZUserId = model.UserId,
                Price = model.Price,
                CreateAt = DateTime.UtcNow,
                Status = 0
            };
            CardAccount cardAccount = new CardAccount()
            {
                BankName = model.BankName,
                CardCode = model.CardCode,
                CardName = model.CardName
            };
            orderRepository.Add(order, cardAccount);
            return RedirectToAction("ResultPayer", "Seller");
        }

        [HttpGet]
        [Authorize(Roles = "User,Seller")]
        public ActionResult GetAllOrder()
        {
            string id = User.Identity.GetUserId();
            var orders = orderRepository.FindByUserId(id);
            return View(orders);
        }

        public ActionResult ResultPayer()
        {
            var payer = payerRepository.GetPayer(1);
            return View(payer);
        }

        [NonAction]
        public decimal CalculatePrice(Seller seller)
        {
            decimal result = 0; ;
            if (seller.SellerMapSkills != null)
            {
                foreach(var skill in seller.SellerMapSkills)
                {
                    int id = skill.SkillId;
                    switch (id)
                    {
                        case 1:
                            result += 10000;
                            break;
                        case 2:
                            result += 20000;
                            break;
                        case 3:
                            result += 30000;
                            break;
                        case 4:
                            result += 40000;
                            break;
                        default:
                            break;
                    }
                }
            }
            return result;
        }
        
    }
}