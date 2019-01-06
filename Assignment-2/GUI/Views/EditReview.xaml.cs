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
using System.Windows.Shapes;

namespace GUI.Views
{
    /// <summary>
    /// Logika interakcji dla klasy EditReview.xaml
    /// </summary>
    public partial class EditReview : Window
    {
        public EditReview()
        {
            InitializeComponent();
        }

        private void ClickButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
