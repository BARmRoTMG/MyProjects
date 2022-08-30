using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Manager
    {
        public List<Book> bookList = new List<Book>();

        public Manager()
        {
            bookList = new List<Book>();
            bookList.Add(new Book("The books in the moon","Nick"));
            bookList.Add(new Book("Earthquake", "Dolev"));
            bookList.Add(new Book("My lovely Guitar", "Ran"));
            bookList.Add(new Book("On the horizon", "Omer"));
            bookList.Add(new Book("My lovely Cat", "Itzik"));
        }

        public List<Book> Search(SearchByEnum searchBy, string filter)
        {
            List<Book> result = new List<Book>();
            filter = filter.ToLower();
            string CurrentItem = string.Empty;

            foreach (Book book in bookList)
            {

                switch (searchBy)
                {
                    case SearchByEnum.Name:
                        CurrentItem = book.Name;
                        break;
                    case SearchByEnum.Writer:
                        CurrentItem = book.Writer;
                        break;
                }

                CurrentItem = CurrentItem.ToLower();
                if (CurrentItem.Contains(filter))
                    result.Add(book);
            }

            return result;
        }



    }
}
