using Data;
using GUI.Models;
using GUI.ViewModels.ProductCommands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public ProductModel ProductModel { get; private set; }
        public AddProductCommand AddProductCommand { get; set; }
        public RemoveProductCommand RemoveProductCommand { get; set; }
        public Product AddedProduct { get; set; }
        public Product SelectedProduct { get; set; }

        public ProductViewModel()
        {
            this.ProductModel = new ProductModel();
            this.AddProductCommand = new AddProductCommand(this);
            this.RemoveProductCommand = new RemoveProductCommand(this);
            this.AddedProduct = new Product();
            Products = new ObservableCollection<Product>(ProductModel.Products);
        }

        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                Console.WriteLine("ZMIANA");
                OnPropertyChanged("Products");
            }
        }

        public void AddProduct()
        {
            try
            {
                ProductModel.AddProduct(AddedProduct);
                Products = new ObservableCollection<Product>(ProductModel.Products);
                AddedProduct = new Product();
                //SelectedProduct = Products.Last();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                MessageBox.Show("Dodanie nowego produktu nie powiodło się: " + e.Message, "Błąd dodawania");
            }
        }

        public void RemoveProduct()
        {
            try
            {
                ProductModel.DeleteProduct(SelectedProduct);
                Products = new ObservableCollection<Product>(ProductModel.Products);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                MessageBox.Show("Usuwanie produktu nie powiodło się: " + e.Message, "Błąd usuwania");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
