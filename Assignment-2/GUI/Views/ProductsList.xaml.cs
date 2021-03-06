﻿using GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ProductsList.xaml
    /// </summary>
    public partial class ProductsList : UserControl
    {
        public ProductsList()
        {
            InitializeComponent();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProductWindow = new AddProduct();
            addProductWindow.DataContext = this.DataContext;
            addProductWindow.Show();
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            EditProduct editProductWindow = new EditProduct();
            editProductWindow.DataContext = this.DataContext;
            editProductWindow.Show();
        }
    }
}
