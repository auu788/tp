using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService
    {
        private AdventureWorksDataContext db = new AdventureWorksDataContext();

        public void CreateProduct(Product product)
        {
            product.rowguid = Guid.NewGuid();
            product.ModifiedDate = DateTime.Now;

            db.Product.InsertOnSubmit(product);
            db.SubmitChanges();
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = (from p in db.Product
                                      select p).ToList<Product>();

            return products;

        }

        public void UpdateProductById(Product product)
        {
            Product productToUpdate = (from p in db.Product
                                       where p.ProductID.Equals(product.ProductID)
                                       select p).First();

            productToUpdate.Name = product.Name;
            productToUpdate.ProductNumber = product.ProductNumber;
            productToUpdate.ListPrice = product.ListPrice;
            productToUpdate.Weight = product.Weight;

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
