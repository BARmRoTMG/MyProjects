using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Book
    {
        public string Name { get; set; }
        public string Writer { get; set; }

        public Book(string name, string writer)
        {
            Name = name;
            Writer = writer;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
