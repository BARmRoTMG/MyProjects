using BooksDelegate.DAL;
using BooksDelegate.Models;
using System;
using System.Windows;

namespace BookStoreUI
{
    public class DataService
    {
        readonly DataContext data = new DataContext();

        #region Singleton
        public static DataService Init { get; } = new DataService();
        #endregion


        public Action<Book> UpdateBooksAction { get; set; }

        public void AddBook(Book book)
        {
            if (!string.IsNullOrEmpty(book.Title) || !string.IsNullOrEmpty(book.Author))
            {
                data.Books.Add(book);
                data.SaveChanges();
                UpdateBooksAction?.Invoke(book);
            }
            else
                MessageBox.Show("Fields can not be empty.");
        }
    }
}
