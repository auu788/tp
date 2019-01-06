using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Service;
using System.Linq;

namespace ServiceTests
{
    /// <summary>
    /// Opis podsumowujący elementu ProductServiceTest
    /// </summary>
    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
        public void CreateDeleteProductTest()
        {
            AdventureWorksDataContext db = new AdventureWorksDataContext();
            ProductService pr = new ProductService();

            Product product = new Product();
            product.Name = "Test-Create-Product";
            product.ProductNumber = "Test-Number-Create-P";

            pr.CreateProduct(product);

            List<Product> actualProducts = (from p in db.Product
                                            where p.ProductNumber.Equals(product.ProductNumber)
                                            select p).ToList<Product>();

            Assert.AreEqual(product.Name, actualProducts[0].Name);

            pr.DeleteProduct(product);
            List<Product> actualProductsAfterDelete = (from p in db.Product
                                                       where p.ProductNumber.Equals(product.ProductNumber)
                                                       select p).ToList<Product>();

            Assert.AreEqual(0, actualProductsAfterDelete.Count);
        }

        [TestMethod]
        public void GetAllProductsTest()
        {
            AdventureWorksDataContext db = new AdventureWorksDataContext();
            ProductService pr = new ProductService();

            int expectedCount = (from p in db.Product
                                 select p).Count();

            int actualCount = pr.GetAllProducts().Count();

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            AdventureWorksDataContext db = new AdventureWorksDataContext();
            ProductService pr = new ProductService();

            Product product = new Product();
            product.Name = "Test-Update-Product";
            product.ProductNumber = "Test-Number-Update-P";

            pr.CreateProduct(product);

            product.Name = "Edit-Product";
            pr.UpdateProduct(product);

            Product actualProduct = (from p in db.Product
                                     where p.ProductNumber.Equals(product.ProductNumber)
                                     select p).First();

            Assert.AreEqual("Edit-Product", actualProduct.Name);
            pr.DeleteProduct(product);
        }
    }
}
