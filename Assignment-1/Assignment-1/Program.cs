using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksLib;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Author author = new Author("George", "Orwell");
            Book book = new Book("1984", new List<Author> { author }, "1984-11-123", "Opis książki");
            Console.WriteLine(book);

            Console.ReadKey();
        }
    }
}
