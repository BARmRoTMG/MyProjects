using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Manager.Classes
{
    public interface IManager
    {
        Task<List<Book>> GetBooks();
        Task AddBook(Book book);
        Task UpdateBook(Book book);
    }
}
