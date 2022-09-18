using System;
using System.Collections.Generic;

namespace BooksDelegate.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
