using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLib
{
    public interface IDataFiller
    {
        void Fill(DataContext context);
    }
}
