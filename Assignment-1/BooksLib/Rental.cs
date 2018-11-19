using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLib
{
    // Zdarzenie
    public class Rental
    {
        private Reader Reader;
        private BookItem BookItem;
        private DateTime RentalDateStart;
        private DateTime RentalDateEnd;
        public Guid Guid { get; private set; }

        public Rental(Reader reader, BookItem bookItem)
        {
            this.Reader = reader;
            this.BookItem = bookItem;
            this.RentalDateStart = DateTime.Now;
            this.Guid = new Guid();
        }

        public Rental(Reader reader, BookItem bookItem, DateTime rentalDateStart, DateTime rentalDateEnd)
        {
            this.Reader = reader;
            this.BookItem = bookItem;
            this.RentalDateStart = rentalDateStart;
            this.RentalDateEnd = rentalDateEnd;
        }

        public void finish()
        {
            this.RentalDateEnd = DateTime.Now;
        }

        public bool isFinished()
        {
            if (this.RentalDateEnd != null)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return String.Format("{0}\n{1}\nData rozpoczecia wypozyczenia: {2} {3}\nData zakonczenia wypozyczenia: {4} {5}",
                this.Reader,
                this.BookItem,
                this.RentalDateStart.ToLongDateString(),
                this.RentalDateStart.ToLongTimeString(),
                this.RentalDateEnd.ToLongDateString(),
                this.RentalDateEnd.ToLongTimeString());
        }
    }
}
