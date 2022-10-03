using BooksDelegate.DAL;
using BooksDelegate.Models;
using System;
using System.Linq;
using System.Windows.Controls;

namespace BookStoreUI
{
    public partial class BooksListViewUC : UserControl
    {
        readonly DataContext data = new DataContext();
        public BooksListViewUC()
        {
            InitializeComponent();
            lvBooks.ItemsSource = data.Books.ToList();

            DataService.Init.UpdateBooksAction = UpdateBooksList;
        }

        private void UpdateBooksList(Book book) => lvBooks.ItemsSource = data.Books.ToList();
    }
}
