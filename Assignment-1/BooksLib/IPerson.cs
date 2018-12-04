using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLib
{
    public abstract class IPerson
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public Guid Guid { get; private set; }

        public IPerson(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Guid = Guid.NewGuid();
        }

        public override string ToString()
        {
            return String.Format("{0} {1} [{2}]", this.FirstName, this.LastName, this.Guid);
        }
    }
}
