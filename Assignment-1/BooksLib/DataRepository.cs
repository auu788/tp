﻿using System;
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
    }
}
