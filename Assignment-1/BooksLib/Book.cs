using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLib
{
    // Katalog
    public class Book
    {
        private string Title;
        private List<Author> Authors;
        private string Description;
        public string IsbnNumber { get; private set; }

        public Book(string title, List<Author> authors, string isbnNumber, string description)
        {
            this.Title = title;
            this.Authors = authors;
            this.IsbnNumber = isbnNumber;
            this.Description = description;
        }

        public override string ToString()
        {
            return string.Format("{0} by {1} [{2}] - {3}", this.Title, string.Join(", ", this.Authors), this.IsbnNumber, this.Description);
        }
    }
}
