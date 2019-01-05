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
        public ProductReviewViewModel ProductReviewViewModel  { get; set; }
        public ProductModel ProductModel { get; private set; }
        public AddProductCommand AddProductCommand { get; set; }
        public UpdateProductCommand EditProductCommand { get; set; }
        public RemoveProductCommand RemoveProductCommand { get; set; }
        public Product AddedProduct { get; set; }
        public Product UpdatedProduct { get; set; }
        private Product _selectedProduct;
        public Product SelectedProduct {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                this.ProductReviewViewModel.RefreshReviews(value);
                OnPropertyChanged("SelectedProduct");
                Console.WriteLine("REVIEWS: " + ProductReviewViewModel.Reviews.Count);
            }
        }

        public ProductViewModel()
        {

            this.ProductModel = new ProductModel();
            this.AddProductCommand = new AddProductCommand(this);
            this.EditProductCommand = new UpdateProductCommand(this);
            this.RemoveProductCommand = new RemoveProductCommand(this);
            this.AddedProduct = new Product();
            Products = new ObservableCollection<Product>(ProductModel.Products);
            this.ProductReviewViewModel = new ProductReviewViewModel(Products.First());
            //this.SelectedProduct = Products.First();
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
                SelectedProduct = Products.Last();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                MessageBox.Show("Dodanie nowego produktu nie powiodło się: " + e.Message, "Błąd dodawania");
            }
        }

        public void UpdateProduct()
        {
            try
            {
                ProductModel.UpdateProduct(SelectedProduct);
                Products = new ObservableCollection<Product>(ProductModel.Products);
                //SelectedProduct = Products.First();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                MessageBox.Show("Edycja produktu nie powiodła się: " + e.Message, "Błąd edycji");
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
