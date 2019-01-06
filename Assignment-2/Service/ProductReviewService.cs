using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductReviewService
    {
        private AdventureWorksDataContext db = new AdventureWorksDataContext();

        public void CreateReview(ProductReview review)
        {
            review.ReviewerName = "Automat";
            review.ReviewDate = DateTime.Now;
            review.EmailAddress = "auto@mat.com";
            review.ModifiedDate = DateTime.Now;

            db.ProductReview.InsertOnSubmit(review);
            db.SubmitChanges();
        }

        public List<ProductReview> GetReviewsByProductId(int productId)
        {
            List<ProductReview> productReviews = (from p in db.ProductReview
                                                  where p.ProductID.Equals(productId)
                                                  select p).ToList<ProductReview>();

            if (productReviews == null)
            {
                return new List<ProductReview>();
            }

            return productReviews;
        }

        public void UpdateReview(ProductReview review)
        {
            ProductReview reviewToUpdate = (from p in db.ProductReview
                                             where p.ProductReviewID.Equals(review.ProductReviewID)
                                       select p).First();

            reviewToUpdate.Rating = review.Rating;
            reviewToUpdate.Comments = review.Comments;
            review.ModifiedDate = DateTime.Now;

            db.SubmitChanges();
        }

        public void DeleteReview(ProductReview review)
        {
            ProductReview reviewToDelete = (from p in db.ProductReview
                                             where p.ProductReviewID.Equals(review.ProductReviewID)
                                       select p).First();

            db.ProductReview.DeleteOnSubmit(reviewToDelete);
            db.SubmitChanges();
        }
    }
}
