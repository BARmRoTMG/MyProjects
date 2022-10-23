using System;
using System.Collections.Generic;
using System.Windows;
using BookLibraryAdvanced.DAL;
using BookLibraryAdvanced.Models;

namespace BookLibraryUI.Views
{
    public partial class WorkerView : Window
    {
        readonly Repository data = new Repository();
        public WorkerView()
        {
            InitializeComponent();
        }

        private void AddItemBtn(object sender, RoutedEventArgs e)
        {
            data.AddBook(new Book { Title = tbTitle.Text, Author = tbAuthor.Text, Price = double.Parse(tbPrice.Text) });
        }
    }
}
