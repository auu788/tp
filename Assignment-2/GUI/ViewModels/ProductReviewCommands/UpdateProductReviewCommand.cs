using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModels.ProductReviewCommands
{
    public class UpdateProductReviewCommand : ICommand
    {
        public ProductReviewViewModel ProductReviewViewModel { get; set; }
        public event EventHandler CanExecuteChanged;

        public UpdateProductReviewCommand(ProductReviewViewModel productViewModel)
        {
            ProductReviewViewModel = productViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProductReviewViewModel.UpdateReview();
        }
    }
}
