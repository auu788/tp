﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLib
{
    public class DataRepository
    {
        private DataContext context;

        public DataRepository() {
            context = new DataContext();
        }
  
        public DataRepository(IDataFiller dataFiller)
        {
            context = new DataContext();
            dataFiller.Fill(context);
        }

        // Person
        public List<IPerson> GetAllPeople()
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
            int index = context.personalInfoData.FindIndex(bi => bi.Guid == guid);
            if (index > -1)
                context.personalInfoData[index] = person;
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
        public List<BookItem> GetAllBookItems()
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
            int index = context.bookPurchaseData.FindIndex(bi => bi.Guid == guid);
            if (index > -1)
                context.bookPurchaseData[index] = bookItem;
        }

        public void DeleteBookItem(BookItem bookItem)
        {
            context.bookPurchaseData.Remove(bookItem);
        }

        // Rental
        public ObservableCollection<Rental> GetAllRentals()
        {
            return context.rentalData;
        }

        public Rental GetRental(Guid guid)
        {
            return context.rentalData.SingleOrDefault(r => r.Guid == guid);
        }

        public void AddRental(Rental rental)
        {
            context.rentalData.Add(rental);
        }

        public void UpdateRental(Guid guid, Rental rental)
        {
            Rental rentalToUpdate = context.rentalData.SingleOrDefault(r => r.Guid == guid);

            if (rentalToUpdate != null)
            {
                int index = context.rentalData.IndexOf(rentalToUpdate);
                context.rentalData[index] = rental;
            }
        }

        public void DeleteRental(Rental rental)
        {
            context.rentalData.Remove(rental);
        }

        private void CollectionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {

                Rental newRental = e.NewItems[0] as Rental;
                Console.WriteLine("Nowe wypozyczenie: " + newRental);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Rental newRental = e.OldItems[0] as Rental;
                Console.WriteLine("Anulowano wypozyczenie: " + newRental);
            }
        }
    }
}
