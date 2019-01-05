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
            product.SafetyStockLevel = 123;
            product.ReorderPoint = 123;
            product.ModifiedDate = DateTime.Now;
            product.SellStartDate = DateTime.Now;

            db.Product.InsertOnSubmit(product);
            db.SubmitChanges();
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = (from p in db.Product
                                      select p).ToList<Product>();

            Console.WriteLine("POBIERANIE WSZYST");
            return products;
        }

        public void UpdateProduct(Product product)
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

        public void DeleteProduct(Product product)
        {
            Product productToDelete = (from p in db.Product
                                       where p.ProductID.Equals(product.ProductID)
                                       select p).First();

            foreach(TransactionHistory th in productToDelete.TransactionHistory)
            {
                db.TransactionHistory.DeleteOnSubmit(th);
            }

            foreach(BillOfMaterials bom in productToDelete.BillOfMaterials)
            {
                db.BillOfMaterials.DeleteOnSubmit(bom);
            }

            foreach (ProductInventory pi in productToDelete.ProductInventory)
            {
                db.ProductInventory.DeleteOnSubmit(pi);
            }

            foreach (ProductProductPhoto ppp in productToDelete.ProductProductPhoto)
            {
                db.ProductProductPhoto.DeleteOnSubmit(ppp);
            }

            foreach (ProductVendor pv in productToDelete.ProductVendor)
            {
                db.ProductVendor.DeleteOnSubmit(pv);
            }

            foreach (PurchaseOrderDetail pod in productToDelete.PurchaseOrderDetail)
            {
                db.PurchaseOrderDetail.DeleteOnSubmit(pod);
            }

            foreach (WorkOrder wo in productToDelete.WorkOrder)
            {
                db.WorkOrder.DeleteOnSubmit(wo);
            }

            db.Product.DeleteOnSubmit(productToDelete);
            db.SubmitChanges();
        }
    }
}
