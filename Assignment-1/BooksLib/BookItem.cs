using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLib
{
    // OpisStanu
    public class BookItem
    {
        private Book Book;
        private DateTime PurchaseDate;
        public Guid Guid { get; private set; }

        public BookItem(Book book, DateTime purchaseDate)
        {
            this.Book = book;
            this.PurchaseDate = purchaseDate;
            this.Guid = Guid.NewGuid();
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}]", this.Book, this.Guid);
        }

    }
}
