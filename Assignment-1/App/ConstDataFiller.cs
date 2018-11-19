using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLib
{
    public class ConstDataFiller : IDataFiller
    {
        public void Fill(DataContext context)
        {
            Author author = new Author("George", "Orwell");
            Book book = new Book("1984", new List<Author> { author }, "1984-11-123", "Opis książki");
            BookItem bookItem = new BookItem(book, DateTime.Today);
            Reader reader = new Reader("Jan", "Kowal");
            Rental rental = new Rental(reader, bookItem);

            context.bookPurchaseData.Add(bookItem);
            context.booksData.Add(book.IsbnNumber, book);
            context.personalInfoData.Add(reader);
            context.personalInfoData.Add(author);
            context.rentalData.Add(rental);
        }
    }
}
