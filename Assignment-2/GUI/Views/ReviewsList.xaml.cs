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
    /// Logika interakcji dla klasy ReviewsList.xaml
    /// </summary>
    public partial class ReviewsList : UserControl
    {
        public ReviewsList()
        {
            InitializeComponent();
        }

        private void AddReview_Click(object sender, RoutedEventArgs e)
        {
            AddReview addReviewWindow = new AddReview();
            addReviewWindow.DataContext = this.DataContext;
            addReviewWindow.Show();
        }

        private void EditReview_Click(object sender, RoutedEventArgs e)
        {
            EditReview editReviewWindow = new EditReview();
            editReviewWindow.DataContext = this.DataContext;
            editReviewWindow.Show();
        }
    }
}
