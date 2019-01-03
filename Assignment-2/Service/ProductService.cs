using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class ProductService
    {
        private AdventureWorksDataContext db = new AdventureWorksDataContext();

        public void CreateProduct(string name, string productNumber, decimal listPrice, decimal weight)
        {
            Product product = new Product()
            {
                Name = name,
                ProductNumber = productNumber,
                ListPrice = listPrice,
                Weight = weight,
                rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.Now
            };

            db.Product.InsertOnSubmit(product);
            db.SubmitChanges();
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = (from p in db.Product
                                      select p).ToList<Product>();

            return products;

        }

        public void UpdateProductById(int id, string name, string productNumber, decimal listPrice, decimal weight)
        {
            Product productToUpdate = (from p in db.Product
                                       where p.ProductID.Equals(id)
                                       select p).First();

            productToUpdate.Name = name;
            productToUpdate.ProductNumber = productNumber;
            productToUpdate.ListPrice = listPrice;
            productToUpdate.Weight = weight;

            db.SubmitChanges();
        }

        public void DeleteProductById(int id)
        {
            Product productToDelete = (from p in db.Product
                                       where p.ProductID.Equals(id)
                                       select p).First();

            db.Product.DeleteOnSubmit(productToDelete);
            db.SubmitChanges();
        }
    }
}
