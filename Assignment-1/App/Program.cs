using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksLib;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataFiller dataFiller = new JsonDataFiller();
            DataRepository dataRepository = new DataRepository(dataFiller);

            Console.ReadKey();
        }
    }
}
