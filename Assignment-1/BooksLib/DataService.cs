using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLib
{
    class DataService
    {
        private DataRepository dataRepository;

        public DataService(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public Dictionary<string, Book> GetAllBooks()
        {
            return dataRepository.GetAllBooks();
        }

        public List<Reader> GetReaderByLastName(String lastName)
        {
            List<Reader> readers = new List<Reader>();

            foreach (Reader reader in dataRepository.GetAllPeople())
            {
                if (reader.LastName.Contains(lastName))
                    readers.Add(reader);
            }
            return readers;
        }

        public ObservableCollection<Rental> GetRentalsBetweenDates(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            ObservableCollection<Rental> result = new ObservableCollection<Rental>();

            foreach (Rental rental in dataRepository.GetAllRentals())
            {
                if (rental.RentalDateStart >= startDate && rental.RentalDateEnd <= endDate)
                    result.Add(rental);
            }
            return result;
        }

        public ObservableCollection<Rental> GetRentalsByReadersName(String firstName, String lastName)
        {
            ObservableCollection<Rental> rentals = new ObservableCollection<Rental>();

            foreach (Rental rental in dataRepository.GetAllRentals())
            {
                if (rental.Reader.FirstName.Equals(firstName) && rental.Reader.LastName.Equals(lastName))
                    rentals.Add(rental);
            }
            return rentals;
        }

        public ObservableCollection<Rental> GetInProgressRentals()
        {
            ObservableCollection<Rental> result = new ObservableCollection<Rental>();

            foreach (Rental rental in dataRepository.GetAllRentals())
            {
                if (rental.RentalDateEnd == null)
                    result.Add(rental);
            }
            return result;
        }

        public List<Book> GetBooksByAuthor(String firstName, String lastName)
        {
            List<Book> result = new List<Book>();

            foreach (KeyValuePair<string, Book> book in dataRepository.GetAllBooks())
            {
                foreach (Author author in book.Value.Authors)
                {
                    if (author.FirstName.Contains(firstName) && author.LastName.Contains(lastName))
                        result.Add(book.Value);
                }
            }
            return result;
        }

        public ObservableCollection<Rental> GetRentalsByReader(Reader reader)
        {
            ObservableCollection<Rental> Result = new ObservableCollection<Rental>();
            foreach (Rental rental in dataRepository.GetAllRentals())
            {
                if (rental.Reader.Equals(reader))
                    Result.Add(rental);
            }
            return Result;
        }

        public string PrintReaderWithRentalsInfo(List<Reader> readers)
        {
            ObservableCollection<Rental> rentals;
            StringBuilder sb = new StringBuilder();

            foreach (Reader reader in readers)
            {
                sb.Append(reader.ToString());

                rentals = GetRentalsByReader(reader);
                sb.Append("\n\nWypożyczenia: (");
                sb.Append(rentals.Count());
                sb.Append(")\n");

                foreach (Rental rental in rentals)
                {
                    sb.Append(rental.ToString());
                }
            }

            return sb.ToString();
        }

        public string PrintInfo(List<Reader> readers)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Reader reader in readers)
            {
                sb.Append(reader.ToString());
                sb.Append("\n");
            }

            return sb.ToString();
        }

        public string PrintInfo(List<BookItem> bookItems)
        {
            StringBuilder sb = new StringBuilder();

            foreach (BookItem bookItem in bookItems)
            {
                sb.Append(bookItem.ToString());
                sb.Append("\n");
            }

            return sb.ToString();
        }

        public string PrintInfo(Dictionary<string, Book> books)
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, Book> book in books)
            {
                sb.Append(book.ToString());
                sb.Append("\n");
            }

            return sb.ToString();
        }

        public string PrintInfo(ObservableCollection<Rental> rentals)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Rental rental in rentals)
            {
                //info o czytelniku
                sb.Append(rental.ToString());
                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}
