using System;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System.Linq;
using System.Collections.Generic;

namespace ServiceTests
{
    [TestClass]
    public class ProductReviewServiceTest
    {
        [TestMethod]
        public void CreateDeleteReviewTest()
        {
            AdventureWorksDataContext db = new AdventureWorksDataContext();
            ProductService pr = new ProductService();
            ProductReviewService prs = new ProductReviewService();

            Product product = new Product();
            product.Name = "Test-Create-ProductReview";
            product.ProductNumber = "Test-Number-CD-PR";

            pr.CreateProduct(product);

            ProductReview productReview = new ProductReview();
            productReview.Rating = 1;
            productReview.Comments = "Comments-Test";
            productReview.ProductID = product.ProductID;

            prs.CreateReview(productReview);

            ProductReview actualProductReview = (from p in db.ProductReview
                             where p.Comments.Equals(productReview.Comments)
                             select p).First();

            Assert.AreEqual(1, actualProductReview.Rating);

            prs.DeleteReview(productReview);

            List<ProductReview> actualProductsReviewsAfterDelete = (from p in db.ProductReview
                                                   where p.Comments.Equals(productReview.Comments)
                                                   select p).ToList();
            
            Assert.AreEqual(0, actualProductsReviewsAfterDelete.Count);
            pr.DeleteProduct(product);
        }

        [TestMethod]
        public void GetAllReviewsByProductIdTest()
        {
            AdventureWorksDataContext db = new AdventureWorksDataContext();
            ProductService pr = new ProductService();
            ProductReviewService prs = new ProductReviewService();

            Product product = new Product();
            product.Name = "Test-GetAll-ProductReview1";
            product.ProductNumber = "Test-GetAll-PR";

            pr.CreateProduct(product);

            ProductReview productReview1 = new ProductReview();
            productReview1.Rating = 1;
            productReview1.Comments = "Comments-Test1";
            productReview1.ProductID = product.ProductID;
            prs.CreateReview(productReview1);

            ProductReview productReview2 = new ProductReview();
            productReview2.Rating = 2;
            productReview2.Comments = "Comments-Test2";
            productReview2.ProductID = product.ProductID;
            prs.CreateReview(productReview2);

            List<ProductReview> productReviews = (from p in db.ProductReview
                                                  where p.ProductID.Equals(product.ProductID)
                                                  select p).ToList();

            Assert.AreEqual(2, productReviews.Count);
            prs.DeleteReview(productReview1);
            prs.DeleteReview(productReview2);
            pr.DeleteProduct(product);
        }

        [TestMethod]
        public void UpdateReviewTest()
        {
            AdventureWorksDataContext db = new AdventureWorksDataContext();
            ProductService pr = new ProductService();
            ProductReviewService prs = new ProductReviewService();

            Product product = new Product();
            product.Name = "Test-Update-ProductReview2";
            product.ProductNumber = "Test-U-PR";

            pr.CreateProduct(product);

            ProductReview productReview = new ProductReview();
            productReview.Rating = 1;
            productReview.Comments = "Comments-Test";
            productReview.ProductID = product.ProductID;
            prs.CreateReview(productReview);

            productReview.Comments = "UPDATED-Comments-Test";
            prs.UpdateReview(productReview);

            ProductReview actualProductReview = (from p in db.ProductReview
                                                 where p.ProductID.Equals(product.ProductID)
                                                 select p).First();

            Assert.AreEqual("UPDATED-Comments-Test", actualProductReview.Comments);
            prs.DeleteReview(productReview);
            pr.DeleteProduct(product);
        }
    }
}
