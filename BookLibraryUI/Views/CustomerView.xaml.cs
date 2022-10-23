using System;
using System.Collections.Generic;
using System.Windows;
using BookLibraryAdvanced.DAL;
using BookLibraryAdvanced.Models;

namespace BookLibraryUI.Views
{
    public partial class CustomerView : Window
    {
        readonly Repository data = new Repository();
        public CustomerView()
        {
            InitializeComponent();
            lvcCstomerView.ItemsSource = data.Books.ToString();
        }
    }
}
