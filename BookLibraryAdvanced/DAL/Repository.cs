using System;
using System.Collections.Generic;
using BookLibraryAdvanced.Models;

namespace BookLibraryAdvanced.DAL
{
    public class Repository : IDisposable
    {
        readonly DataContex context = new DataContex();

        public IEnumerable<Book> Books => context.Books;
        public IEnumerable<Journal> Journals => context.Journals;

        public void AddBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void AddJournal(Journal journal)
        {
            context.Journals.Add(journal);
            context.SaveChanges();
        }

        public void Dispose() => context.Dispose();
    }
}
