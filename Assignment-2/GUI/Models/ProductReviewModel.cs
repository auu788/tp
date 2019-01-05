using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Service;

namespace GUI.Models
{
    public class ProductReviewModel
    {
        private ProductReviewService productReviewService = new ProductReviewService();
        private List<ProductReview> _productReviews;
        public List<ProductReview> ProductReviews
        {
            get
            {
                return _productReviews;
            }
            set
            {
                if (value != null)
                {
                    _productReviews = value;
                } else
                {
                    _productReviews = new List<ProductReview>();
                }
            }
        }

        private Product _product;
        public Product Product
        {
            get
            {
                return _product;
            }

            set
            {
                _product = value;
                GetReviews();
            }
        }

        public ProductReviewModel(Product product)
        {
            Product = product;
            GetReviews();
        }

        public void AddProduct(ProductReview review)
        {
            productReviewService.CreateReview(review);
            GetReviews();
        }

        public void UpdateProduct(ProductReview review)
        {
            productReviewService.UpdateReview(review);
            GetReviews();
        }

        public void DeleteProduct(ProductReview review)
        {
            productReviewService.DeleteReview(review);
            GetReviews();
        }

        private void GetReviews()
        {
            ProductReviews = productReviewService.GetReviewsByProductId(Product.ProductID);
        }
    }
}
