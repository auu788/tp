﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLib
{
    // Wykaz
    public class Reader : IPerson
    {
        public Reader(string firstName, string lastName) : base(firstName, lastName) { }
    }
}
