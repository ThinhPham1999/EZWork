using EZWork.Core.Entities;
using EZWork.Core.Repository;
using EZWork.WebUI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Controllers
{
    public class ReviewController : Controller
    {
        private ReviewRepository reviewRepository;
        private SellerRepository sellerRepository;
        public ReviewController()
        {
            reviewRepository = new ReviewRepository();
            sellerRepository = new SellerRepository();
        }

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LeaveReview(ReviewViewModel model)
        {
            JsonResult json = new JsonResult();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var review = new Review();
            var reviewerID = User.Identity.GetUserId();
            if (User.Identity.IsAuthenticated)
            {
                review.Text = model.Text;
                review.SellerID = model.SellerID;
             
                if (model.SellerID.Equals(reviewerID))
                {
                    json.Data = new { Success = false, Message = "You can not review yourself" };
                }
                else {
                    if (reviewRepository.IsExistedReviewer((model.SellerID), reviewerID)){
                        json.Data = new { Success = false, Message = "You can comment only one" };
                    }
                    else {
                        
                        review.ReviewerID = User.Identity.GetUserId();
                        //Lưu ý chỗ này
                        review.TimeStamp = DateTime.Now;
                        review.Rate = Convert.ToInt32(model.Rate);
                        
                        var result = reviewRepository.LeaveComment(review);
                        if (result)
                        {
                            var seller = sellerRepository.GetSellerByID(model.SellerID);
                            seller.FeedBackCount = reviewRepository.GetFeedbackCount(model.SellerID);
                            seller.Rate = reviewRepository.GetAverageRate(model.SellerID);
                            sellerRepository.UpdateSeller(seller);
                            json.Data = new { Success = true , newReview= review };               
                        }
                        //else
                        //{
                        //    json.Data = new { Success = false };
                        //}
                    }                  
                }            
            }
            else
            {
                json.Data = new { Success = false, Message = "Please login before comment" };
            }
            return json;
        }
    }
}