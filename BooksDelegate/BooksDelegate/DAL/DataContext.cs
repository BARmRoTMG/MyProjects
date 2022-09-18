using BooksDelegate.Models;
using System;
using System.Data.Entity;


namespace BooksDelegate.DAL
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }

        public DataContext() : base("Book_Shop")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }
    }
}
