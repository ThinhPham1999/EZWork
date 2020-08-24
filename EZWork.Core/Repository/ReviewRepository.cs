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
    }
}
