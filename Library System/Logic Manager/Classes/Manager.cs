using System;
using Logic_Manager.Classes;
using Logic_Manager.Enums;
using Logic_Manager.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic_Manager
{
    public class Manager : IManager
    {
        Database database = new Database();
        string itemName = "item";

        public List<Items> list = new List<Items>();
        public Manager()
        {
            list = new List<Items>();
            list.Add(new Book("2666", "Roberto Bolaño", Genre.Adventure, "MACMILLAN PUBLISHING SERVICES", 19, 2));
            list.Add(new Book("All About Love: New Visions", "Bell Hooks", Genre.Drama, "HARPERCOLLINS PUBLISHERS", 15, 1));
            list.Add(new Book("The Shining", "Stephen King", Genre.Horror, "	Doubleday", 12, 0));
            list.Add(new Journal("Desert Solitaire", Genre.Crime, "POCKET BOOKS", 25, 4));
            list.Add(new Journal("If on a winter's night a traveler", Genre.Historical, "CLARION & MARINER", 56, 10));
            list.Add(new Journal("The Mega Book", Genre.Action, "Mega Productions", 150, 20));
        }

        public async Task AddBook(Book book)
        {
            try
            {
                await database.AddItem(itemName, book.ToString());
            } catch (Exception)
            {
                throw new ServerErrorException();
            }
        }

        public async Task<List<Book>> GetBooks()
        {
            try
            {
                var books = await database.ReadFile(itemName);
                List<Book> listBooks = new List<Book>();
                for (int i = 0; i < books.Count; i++)
                {
                    string[] splitedBooks = books[i].Split(",");
                    string name = splitedBooks[0];
                    string author = splitedBooks[1];
                    Genre genre = (Genre)Enum.Parse(typeof(Genre), splitedBooks[2].ToString());
                    double leasePrice = double.Parse(splitedBooks[3].ToString());
                    int amount = int.Parse(splitedBooks[4]);
                    string publishingCompany = splitedBooks[5];
                    DateTime publishDate = DateTime.Parse(splitedBooks[6].ToString());
                    Book book = new Book(name, author, Genre.Adventure, publishingCompany, leasePrice, 0);
                    listBooks.Add(book);
                }
                return listBooks;
            } catch (Exception)
            {
                throw new ServerErrorException();
            }
        }

        public async Task UpdateBook(Book updatedBook)
        {
            try
            {
                List<Book> books = await GetBooks();

                for (int i = 0; i < books.Count; i++)
                    if (books[i].Equals(updatedBook))
                        books[i] = updatedBook;

                string[] arr = ChangeBookToString(books);
                await database.WriteLines(itemName, arr);
            } catch (Exception)
            {
                throw new ServerErrorException();
            }
        }

        private string[] ChangeBookToString(List<Book> books)
        {
            string[] arr = new string[books.Count];

            for (int i = 0; i < books.Count; i++)
                arr[i] = books[i].ToString();

            return arr;
        }



        //public List<Book> Search(SeachBy searchBy, string filter)
        //{
        //    List<Book> result = new List<Book>();
        //    filter = filter.ToLower();
        //    string currentItem = string.Empty;

        //    foreach(Book book in list)
        //    {
        //        switch (searchBy)
        //        {
        //            case SeachBy.Name:
        //                //currentItem = book.Name;
        //                break;
        //            case SeachBy.Author:
        //                //currentItem = book.Author;
        //                break;
        //            case SeachBy.Genre:
        //                //currentItem = book.Genre
        //                break;
        //            case SeachBy.Publish:
        //                //currentItem = book.Publish
        //                break;
        //        }

        //        currentItem = currentItem.ToLower();
        //        if (currentItem.Contains(filter))
        //            result.Add(currentItem);
        //    }
        //}

    }
}
