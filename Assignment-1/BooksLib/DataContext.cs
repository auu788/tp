using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLib
{
    public class DataContext
    {
        public List<IPerson> personalInfoData = new List<IPerson>();
        public Dictionary<string, Book> booksData = new Dictionary<string, Book>();
        public ObservableCollection<Rental> rentalData = new ObservableCollection<Rental>();
        public List<BookItem> bookPurchaseData = new List<BookItem>();
    }
}
