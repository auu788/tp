using Data;
using GUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModels
{
    public class ProductReviewViewModel : INotifyPropertyChanged
    {
        ProductReviewModel ProductReviewModel { get; set; }

        public ProductReviewViewModel()
        {

        }

        public ProductReviewViewModel(Product SelectedProduct)
        {
            this.ProductReviewModel = new ProductReviewModel(SelectedProduct);
            //this.AddedProduct = new Product();
            Reviews = new ObservableCollection<ProductReview>(ProductReviewModel.ProductReviews);
        }

        private ObservableCollection<ProductReview> reviews;
        public ObservableCollection<ProductReview> Reviews
        {
            get
            {
                return reviews;
            }

            set
            {
                reviews = value;
                OnPropertyChanged("Reviews");

            }
        }

        public void RefreshReviews(Product selectedProduct)
        {
            this.ProductReviewModel.Product = selectedProduct;
            Reviews = new ObservableCollection<ProductReview>(ProductReviewModel.ProductReviews);
        }

        public void AddReview()
        {

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
