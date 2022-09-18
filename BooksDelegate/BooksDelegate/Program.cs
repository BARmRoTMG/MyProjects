using BooksDelegate.DAL;
using BooksDelegate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDelegate
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var data = new DataContext())
            {
                //data.Books.Add(new Book { Title = "The Second Book", Author = "Max Verstappen"});
                //data.Books.Add(new Book { Title = "The Third Book", Author = "Daniel Ricciardo" });
                //data.Books.Add(new Book { Title = "The Fourth Book", Author = "Lando Norris" });
                data.SaveChanges();
            }
        }
    }
}
