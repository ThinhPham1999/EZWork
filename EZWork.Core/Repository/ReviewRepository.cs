using EZWork.Core.DBContext;
using EZWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Repository
{
  public class ReviewRepository
    {
        private readonly EZWorkDbContext db = new EZWorkDbContext();
        public bool LeaveComment(Review review) {
            db.Reviews.Add(review);
            return db.SaveChanges()>0;
        }
        public List<Review> GetReviewsByID(string id) {
            return db.Reviews.Where(x => x.SellerID == id).ToList();
        }
        public bool IsExistedReviewer(string sellerID, string reviewerID) {
           var review= db.Reviews.Where(x => x.SellerID == sellerID && x.ReviewerID == reviewerID).SingleOrDefault();
            return review != null ? true : false;
        }
        public List<Review> GetListReviewsFollowPage( int page, int recordSize)
        {
            var reviews = db.Reviews.ToList();
            var skip = (page - 1) * recordSize;
            return reviews.OrderBy(x => x.TimeStamp).Skip(skip).Take(recordSize).ToList();
        }
        public int GetCountReview() {
            return db.Reviews.Count();
        }
    }
}
