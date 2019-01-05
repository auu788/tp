using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Data;

namespace GUI.Models
{
    public class ProductModel
    {
        private ProductService productService = new ProductService();
        private List<Product> products;
        public List<Product> Products
        {
            get
            {
                return products;
            }

            set
            {
                products = value;
            }
        }

        public ProductModel()
        {
            GetAllProducts();
        }

        public void AddProduct(Product product)
        {
            productService.CreateProduct(product);
            GetAllProducts();
        }

        public void UpdateProduct(Product product)
        {
            productService.UpdateProduct(product);
            GetAllProducts();
        }

        public void DeleteProduct(Product product)
        {
            productService.DeleteProduct(product);
            GetAllProducts();
        }

        private void GetAllProducts()
        {
            products = productService.GetAllProducts();
        }
    }
}
