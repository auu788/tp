using BooksLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class JsonDataFiller : IDataFiller
    {
        public void Fill(DataContext context)
        {
            using (StreamReader r = new StreamReader("../../../data.json"))
            {
                string json = r.ReadToEnd();
                JsonWrapper jsonWrapper = JsonConvert.DeserializeObject<JsonWrapper>(json);

                foreach (Reader reader in jsonWrapper.readers)
                    context.personalInfoData.Add(reader);
                foreach (Book book in jsonWrapper.books)
                    context.booksData.Add(Guid.NewGuid().ToString(), book);
                foreach (BookItem bookItem in jsonWrapper.bookItems)
                    context.bookPurchaseData.Add(bookItem);
                foreach (Rental rental in jsonWrapper.rentals)
                    context.rentalData.Add(rental);
            }
        }

        private class JsonWrapper
        {
            public List<Reader> readers;
            public List<Book> books;
            public List<BookItem> bookItems;
            public List<Rental> rentals;
        }
    }
}
