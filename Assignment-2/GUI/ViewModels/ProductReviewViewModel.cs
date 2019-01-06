using Data;
using GUI.Models;
using GUI.ViewModels.ProductReviewCommands;
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
    public class ProductReviewViewModel : INotifyPropertyChanged
    {
        public ProductReviewModel ProductReviewModel { get; set; }
        public AddProductReviewCommand AddProductReviewCommand { get; set; }
        public UpdateProductReviewCommand UpdateProductReviewCommand { get; set; }
        public RemoveProductReviewCommand RemoveProductReviewCommand { get; set; }
        public ProductReview AddedReview { get; set; }

        public ProductReviewViewModel() { }

        public ProductReviewViewModel(Product SelectedProduct)
        {
            AddProductReviewCommand = new AddProductReviewCommand(this);
            UpdateProductReviewCommand = new UpdateProductReviewCommand(this);
            RemoveProductReviewCommand = new RemoveProductReviewCommand(this);
            AddedReview = new ProductReview();

            this.ProductReviewModel = new ProductReviewModel(SelectedProduct);
            Reviews = new ObservableCollection<ProductReview>(ProductReviewModel.ProductReviews);
        }


        ProductReview _selectedReview;
        public ProductReview SelectedReview
        {
            get
            {
                return _selectedReview;
            }
            set
            {
                _selectedReview = value;
                if (_selectedReview != null)
                {
                    SetUpdatedReview();
                }
                OnPropertyChanged("SelectedProduct");
            }
        }

        ProductReview _updatedReview;
        public ProductReview UpdatedReview
        {
            get
            {
                return _updatedReview;
            }
            set
            {
                _updatedReview = value;
            }
        }

        private ObservableCollection<ProductReview> _reviews;
        public ObservableCollection<ProductReview> Reviews
        {
            get
            {
                return _reviews;
            }

            set
            {
                _reviews = value;
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
            try
            {
                ProductReviewModel.AddReview(AddedReview);
                Reviews = new ObservableCollection<ProductReview>(ProductReviewModel.ProductReviews);
                SelectedReview = Reviews.Last();
                AddedReview = new ProductReview();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                MessageBox.Show("Dodanie recenzji nie powiodło się: " + e.Message, "Błąd dodawania");
            }
        }

        public void UpdateReview()
        {
            try
            {
                ProductReviewModel.UpdateReview(UpdatedReview);
                Reviews = new ObservableCollection<ProductReview>(ProductReviewModel.ProductReviews);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                MessageBox.Show("Aktualizacja recenzji nie powiodło się: " + e.Message, "Błąd edytowania");
            }
        }

        public void RemoveReview()
        {
            try
            {
                ProductReviewModel.DeleteReview(SelectedReview);
                Reviews = new ObservableCollection<ProductReview>(ProductReviewModel.ProductReviews);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                MessageBox.Show("Usunięcie recenzji nie powiodło się: " + e.Message, "Błąd usuwania");
            }
        }

        private void SetUpdatedReview()
        {
            UpdatedReview = new ProductReview();
            UpdatedReview.ProductReviewID = SelectedReview.ProductReviewID;
            UpdatedReview.Rating = SelectedReview.Rating;
            UpdatedReview.Comments = SelectedReview.Comments;
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
