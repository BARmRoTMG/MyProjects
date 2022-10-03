using System;
using System.Windows;
using System.Windows.Controls;
using BooksDelegate.Models;

namespace BookStoreUI
{

    public partial class InterfaceControls : UserControl
    {
        
        public InterfaceControls() => InitializeComponent();

        private void Button_Click(object sender, RoutedEventArgs e) // Add Book
        {
            DataService.Init.AddBook(new Book { Title = bookTitletb.Text, Author = authorTb.Text });
        }
    }
}
