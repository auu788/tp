using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLib
{
    public class DataRepository
    {
        private DataContext context;

        public DataRepository(IDataFiller dataFiller)
        {
            context = new DataContext();
            dataFiller.Fill(context);
        }

        // Person
        public IEnumerable<IPerson> GetAllPeople()
        {
            return context.personalInfoData;
        }

        public IPerson GetPerson(Guid guid)
        {
            return context.personalInfoData.Find(p => p.Guid == guid);
        }

        public void AddPerson(IPerson person)
        {
            context.personalInfoData.Add(person);
        }

        public void UpdatePerson(Guid guid, IPerson person)
        {
            context.personalInfoData.Insert(
                context.personalInfoData.FindIndex(p => p.Guid == guid),
                person);
        }

        public void DeletePerson(IPerson person)
        {
            context.personalInfoData.Remove(person);
        }

        // Book
        public Dictionary<string, Book> GetAllBooks()
        {
            return context.booksData;
        }

        public Book GetBook(string isbn)
        {
            return context.booksData[isbn];
        }

        public void AddBook(Book book)
        {
            context.booksData.Add(book.IsbnNumber, book);
        }

        public void UpdateBook(string isbnNumber, Book book)
        {
            context.booksData[isbnNumber] = book;
        }

        public void DeleteBook(string isbnNumber)
        {
            context.booksData.Remove(isbnNumber);
        }

        // Book Item
        public IEnumerable<BookItem> GetAllBookItems()
        {
            return context.bookPurchaseData;
        }

        public BookItem GetBookItem(Guid guid)
        {
            return context.bookPurchaseData.Find(bi => bi.Guid == guid);
        }

        public void AddBookItem(BookItem bookItem)
        {
            context.bookPurchaseData.Add(bookItem);
        }

        public void UpdateBookItem(Guid guid, BookItem bookItem)
        {
            context.bookPurchaseData.Insert(
                context.bookPurchaseData.FindIndex(bi => bi.Guid == guid),
                bookItem);
        }

        public void DeleteBookItem(BookItem bookItem)
        {
            context.bookPurchaseData.Remove(bookItem);
        }

        // Rental
        public IEnumerable<Rental> GetAllRentals()
        {
            return context.rentalData;
        }

        public Rental GetRental(Guid guid)
        {
            return context.rentalData.Single(r => r.Guid == guid);
        }

        public void AddBookItem(Rental rental)
        {
            context.rentalData.Add(rental);
        }

        public void UpdateRental(Guid guid, Rental rental)
        {
            context.rentalData.Insert(
                context.rentalData.IndexOf(
                    context.rentalData.Single(r => r.Guid == guid)), rental);
        }

        public void DeleteRental(Rental rental)
        {
            context.rentalData.Remove(rental);
        }
    }
}
