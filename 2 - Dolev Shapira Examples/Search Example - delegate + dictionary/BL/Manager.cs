using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Manager
    {
        public delegate string PropertyRetriever(Book book);

        PropertyRetriever SearchDelegate;


        public string SearchByWriter(Book book)
        {
            return book.Writer;
        }

        public string SearchByName(Book book)
        {
            return book.Name;
        }

        Dictionary<SearchByEnum, PropertyRetriever> PropertyRunner = new Dictionary<SearchByEnum, PropertyRetriever>();
        public List<Book> bookList = new List<Book>();


        public Manager()
        {
            bookList = new List<Book>();
            bookList.Add(new Book("The books in the moon","Nick"));
            bookList.Add(new Book("Earthquake", "Dolev"));
            bookList.Add(new Book("My lovely Guitar", "Ran"));
            bookList.Add(new Book("On the horizon", "Omer"));
            bookList.Add(new Book("My lovely Cat", "Itzik"));

            PropertyRunner.Add(SearchByEnum.Name, SearchByName);
            PropertyRunner.Add(SearchByEnum.Writer, SearchByWriter);
        }

        

        public List<Book> Search(SearchByEnum searchBy, string filter)
        {

            List<Book> result = new List<Book>();
            filter = filter.ToLower();
            string CurrentItem = string.Empty;

            foreach (Book book in bookList)
            {
                CurrentItem = PropertyRunner[searchBy](book);

                CurrentItem = CurrentItem.ToLower();
                if (CurrentItem.Contains(filter))
                    result.Add(book);
            }

            return result;
        }



    }
}
