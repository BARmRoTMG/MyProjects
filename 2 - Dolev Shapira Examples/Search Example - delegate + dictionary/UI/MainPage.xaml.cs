using BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Manager manager = new Manager();
        SearchByEnum searchByEnum;

        public MainPage()
        {
            this.InitializeComponent();

            foreach (string item in Enum.GetNames(typeof(SearchByEnum)))
            {
                SearchByComboBox.Items.Add(item);
            }
            
            Refresh(manager.bookList);
        }

        public void Refresh(List<Book> bookList)
        {
            BooksListView.Items.Clear();

            foreach (Book item in bookList)
            {
                BooksListView.Items.Add(item);
            }
        }


        public void Search_Click(object sender, RoutedEventArgs e)
        {
            List<Book> filteredBooks = manager.Search(searchByEnum, SearchByTextBox.Text);
            Refresh(filteredBooks);
        }


        private void SearchBy(object sender, SelectionChangedEventArgs e)
        {
            searchByEnum = (SearchByEnum)Enum.Parse(typeof(SearchByEnum), ((string)e.AddedItems[0]));
        }
    }
}
