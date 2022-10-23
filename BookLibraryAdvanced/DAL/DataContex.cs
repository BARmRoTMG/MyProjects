using System.Data.Entity.SqlServer;
using System.Data.Entity;
using BookLibraryAdvanced.Models;

namespace BookLibraryAdvanced.DAL
{
    public class DataContex : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DataContex() : base("LibrarySystem")
        {
            _ = SqlProviderServices.Instance;
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContex>());
        }

    }
}