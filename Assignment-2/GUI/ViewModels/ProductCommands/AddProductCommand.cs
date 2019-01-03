using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModels.ProductCommands
{
    public class AddProductCommand : ICommand
    {
        public ProductViewModel ProductViewModel { get; set; }
        public event EventHandler CanExecuteChanged;

        public AddProductCommand(ProductViewModel productViewModel)
        {
            Console.WriteLine("AddProductCommand");
            ProductViewModel = productViewModel;
        }

        public bool CanExecute(object parameter)
        {
            Console.WriteLine("can");
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine("ASDF");
            ProductViewModel.AddProduct();
        }
    }
}
