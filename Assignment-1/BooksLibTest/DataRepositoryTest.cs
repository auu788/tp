using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BooksLib;
using System.Collections.Generic;

namespace BooksLibTest
{
    [TestClass]
    public class DataRepositoryTest
    {   
        [TestMethod]
        public void GetAllPeopleTest()
        {
            Reader reader = new Reader("First", "Last");
            Author author = new Author("Auth", "Or");
            DataRepository dataRepository = new DataRepository();
            dataRepository.AddPerson(reader);
            dataRepository.AddPerson(author);

            List<IPerson> people = dataRepository.GetAllPeople();
            Assert.AreEqual(2, people.Count);
        }

        [TestMethod]
        public void GetPersonTest()
        {
            Reader reader = new Reader("First", "Last");
            Author author = new Author("Auth", "Or");
            DataRepository dataRepository = new DataRepository();
            dataRepository.AddPerson(reader);
            dataRepository.AddPerson(author);

            IPerson expectedPerson = dataRepository.GetPerson(reader.Guid);
            Assert.AreEqual(reader, expectedPerson);
        }

        [TestMethod]
        public void AddPersonTest()
        {
            Reader reader = new Reader("First", "Last");
            DataRepository dataRepository = new DataRepository();

            int peopleCountBefore = dataRepository.GetAllPeople().Count;

            dataRepository.AddPerson(reader);
            int peopleCountAfter = dataRepository.GetAllPeople().Count;

            Assert.AreEqual(peopleCountBefore + 1, peopleCountAfter);
        }

        [TestMethod]
        public void UpdatePersonTest()
        {
            Reader reader = new Reader("First", "Last");
            DataRepository dataRepository = new DataRepository();
            dataRepository.AddPerson(reader);

            IPerson personBefore = dataRepository.GetPerson(reader.Guid);
            Assert.AreEqual(String.Format("First Last [{0}]", reader.Guid), personBefore.ToString());

            dataRepository.UpdatePerson(reader.Guid, new Reader("Updated", "Person"));
            IPerson personAfter = dataRepository.GetPerson(reader.Guid);
            Assert.AreEqual(1, dataRepository.GetAllPeople().Count);
            Assert.AreEqual(String.Format("Updated Person [{0}]", reader.Guid), personAfter.ToString());
        }

        [TestMethod]
        public void DeletePersonTest()
        {
            Reader reader = new Reader("First", "Last");
            Author author = new Author("Auth", "Or");
            DataRepository dataRepository = new DataRepository();
            dataRepository.AddPerson(reader);
            dataRepository.AddPerson(author);

            List<IPerson> peopleBefore = dataRepository.GetAllPeople();
            Assert.AreEqual(2, peopleBefore.Count);

            dataRepository.DeletePerson(reader);
            List<IPerson> peopleAfter = dataRepository.GetAllPeople();
            Assert.AreEqual(1, peopleAfter.Count);
        }

        [TestMethod]
        public void GetAllBooksTest()
        {
            DataRepository dataRepository = new DataRepository();
            Author author = new Author("George", "Orwell");
            dataRepository.AddBook(new Book("Title 1", new List<Author> { author }, "1234_1", "Desc"));
            dataRepository.AddBook(new Book("Title 2", new List<Author> { author }, "1234_2", "Desc"));

            Dictionary<string, Book> books = dataRepository.GetAllBooks();
            Assert.AreEqual(2, books.Count);
        }

        [TestMethod]
        public void GetBookTest()
        {
            DataRepository dataRepository = new DataRepository();
            Author author = new Author("George", "Orwell");
            Book expectedBook = new Book("Title 1", new List<Author> { author }, "1234_1", "Desc");
            dataRepository.AddBook(expectedBook);
            dataRepository.AddBook(new Book("Title 2", new List<Author> { author }, "1234_2", "Desc"));

            Book actualBook = dataRepository.GetBook("1234_1");
            Assert.AreEqual(expectedBook, actualBook);
        }

        [TestMethod]
        public void AddBookTest()
        {
            Author author = new Author("George", "Orwell");
            Book book = new Book("Title 1", new List<Author> { author }, "1234_1", "Desc");
            DataRepository dataRepository = new DataRepository();

            int booksCountBefore = dataRepository.GetAllBooks().Count;

            dataRepository.AddBook(book);
            int booksCountAfter = dataRepository.GetAllBooks().Count;

            Assert.AreEqual(booksCountBefore + 1, booksCountAfter);
        }

        [TestMethod]
        public void UpdateBookTest()
        {
            Author author = new Author("George", "Orwell");
            Book book = new Book("Title 1", new List<Author> { author }, "1234_1", "Desc");
            DataRepository dataRepository = new DataRepository();
            dataRepository.AddBook(book);

            Book bookBefore = dataRepository.GetBook(book.IsbnNumber);
            Assert.AreEqual(String.Format("Title 1 by George Orwell [{0}] - Desc", book.IsbnNumber), bookBefore.ToString());

            dataRepository.UpdateBook(book.IsbnNumber, new Book("Title Updated", new List<Author> { author }, "1234_1", "Desc"));
            Book personAfter = dataRepository.GetBook(book.IsbnNumber);
            Assert.AreEqual(1, dataRepository.GetAllBooks().Count);
            Assert.AreEqual(String.Format("Title 1 by George Orwell [{0}] - Desc", book.IsbnNumber), personAfter.ToString());
        }

        [TestMethod]
        public void DeleteBookTest()
        {
            Author author = new Author("George", "Orwell");
            Book book = new Book("Title 1", new List<Author> { author }, "1234_1", "Desc");
            Author author2 = new Author("Adam", "Mickiewicz");
            Book book2 = new Book("Dziady", new List<Author> { author2 }, "1234_3", "Desc");
            DataRepository dataRepository = new DataRepository();
            dataRepository.AddBook(book);
            dataRepository.AddBook(book2);

            Dictionary<string, Book> booksBefore = dataRepository.GetAllBooks();
            Assert.AreEqual(2, booksBefore.Count);

            dataRepository.DeleteBook(book.IsbnNumber);
            Dictionary<string, Book> booksAfter = dataRepository.GetAllBooks();
            Assert.AreEqual(1, booksAfter.Count);
        }

        [TestMethod]
        public void GetAllBooksItemsTest()
        {
            DataRepository dataRepository = new DataRepository();
            Author author = new Author("George", "Orwell");
            Book book = new Book("1984", new List<Author> { author }, "1984-11-123", "Opis książki");
            BookItem bookItem = new BookItem(book, DateTime.Today);
            BookItem bookItem2 = new BookItem(book, DateTime.Today.AddDays(5));
            dataRepository.AddBookItem(bookItem);
            dataRepository.AddBookItem(bookItem2);

            List<BookItem> bookItems = dataRepository.GetAllBookItems();
            Assert.AreEqual(2, bookItems.Count);
        }

        [TestMethod]
        public void GetBookItemTest()
        {
            DataRepository dataRepository = new DataRepository();
            Author author = new Author("George", "Orwell");
            Book book = new Book("1984", new List<Author> { author }, "1984-11-123", "Opis książki");
            BookItem expectedBookItem = new BookItem(book, DateTime.Today);
            BookItem bookItem2 = new BookItem(book, DateTime.Today.AddDays(5));
            dataRepository.AddBookItem(expectedBookItem);
            dataRepository.AddBookItem(bookItem2);

            BookItem actualBookItem = dataRepository.GetBookItem(expectedBookItem.Guid);
            Assert.AreEqual(expectedBookItem, actualBookItem);
        }

        [TestMethod]
        public void AddBookItemTest()
        {
            DataRepository dataRepository = new DataRepository();
            Author author = new Author("George", "Orwell");
            Book book = new Book("1984", new List<Author> { author }, "1984-11-123", "Opis książki");
            BookItem bookItem = new BookItem(book, DateTime.Today);

            Assert.AreEqual(0, dataRepository.GetAllBookItems().Count);

            dataRepository.AddBookItem(bookItem);

            Assert.AreEqual(1, dataRepository.GetAllBookItems().Count);
        }

        [TestMethod]
        public void UpdateBookItemTest()
        {
            DataRepository dataRepository = new DataRepository();
            Author author = new Author("George", "Orwell");
            Book book = new Book("1984", new List<Author> { author }, "1984-11-123", "Opis książki");
            BookItem bookItemBefore = new BookItem(book, DateTime.Today);
            dataRepository.AddBookItem(bookItemBefore);

            Assert.AreEqual(String.Format("1984 by George Orwell [{0}] - Desc [{1}]", book.IsbnNumber, bookItemBefore.Guid), bookItemBefore.ToString());
            Book bookAfter = new Book("1985", new List<Author> { author }, "1984-11-123", "Opis książki");
            BookItem bookItemAfter = new BookItem(bookAfter, DateTime.Today);

            dataRepository.UpdateBookItem(bookItemBefore.Guid, bookItemAfter);
            BookItem updatedBookItem = dataRepository.GetBookItem(bookItemBefore.Guid);
            Assert.AreEqual(1, dataRepository.GetAllBooks().Count);
            Assert.AreEqual(String.Format("1985 by George Orwell [{0}] - Desc [{1}]", book.IsbnNumber, bookItemBefore.Guid), updatedBookItem.ToString());

        }

        [TestMethod]
        public void DeleteBookItemTest()
        {
            DataRepository dataRepository = new DataRepository();
            Author author = new Author("George", "Orwell");
            Book book = new Book("1984", new List<Author> { author }, "1984-11-123", "Opis książki");
            BookItem bookItem = new BookItem(book, DateTime.Today);
            BookItem bookItem2 = new BookItem(book, DateTime.Today.AddDays(5));
            dataRepository.AddBookItem(bookItem);
            dataRepository.AddBookItem(bookItem2);

            List<BookItem> bookItemsBefore = dataRepository.GetAllBookItems();
            Assert.AreEqual(2, bookItemsBefore.Count);

            dataRepository.DeleteBookItem(bookItem);
            List<BookItem> bookItemsAfter = dataRepository.GetAllBookItems();
            Assert.AreEqual(1, bookItemsAfter.Count);
        }
    }
}
