﻿using System;
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
            ProductViewModel = productViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProductViewModel.AddProduct();
        }
    }
}
