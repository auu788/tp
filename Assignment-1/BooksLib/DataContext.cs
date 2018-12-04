using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLib
{
    public class DataContext
    {
        public List<IPerson> personalInfoData;
        public Dictionary<string, Book> booksData;
        public ObservableCollection<Rental> rentalData;
        public List<BookItem> bookPurchaseData;

        public DataContext()
        {
            personalInfoData = new List<IPerson>();
            booksData = new Dictionary<string, Book>();
            rentalData = new ObservableCollection<Rental>();
            bookPurchaseData = new List<BookItem>();

            rentalData.CollectionChanged += new NotifyCollectionChangedEventHandler(RentalChanged);
        }

        public void RentalChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Dodano nowe wypożyczenie!");
            }

            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Usunięto wypożyczenie!");
            }
        }
    }
}
