using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModels.ProductCommands
{
    public class RemoveProductCommand : ICommand
    {
        public ProductViewModel ProductViewModel { get; set; }
        public event EventHandler CanExecuteChanged;

        public RemoveProductCommand(ProductViewModel productViewModel)
        {
            Console.WriteLine("RemoveProduct");
            ProductViewModel = productViewModel;
        }

        public bool CanExecute(object parameter)
        {
            Console.WriteLine("can");
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine("REMOVE");
            ProductViewModel.RemoveProduct();
        }
    }
}
