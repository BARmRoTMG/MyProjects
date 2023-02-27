using App3.Model;
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

namespace App3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Base savedSelection;

        public MainPage()
        {
            this.InitializeComponent();
        }

        public void ViewAllItems_Click(object sender, RoutedEventArgs e)
        {
            BooksListView.Items.Clear();


            List<Base> items = new List<Base>();
            items.Add(new Child("Dolev"));
            items.Add(new Base(47, "Green"));
            items.Add(new Child("Ron"));


            foreach (Base item in items)
            {
                BooksListView.Items.Add(item);
            }
        }

        private void BooksListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            savedSelection = (Base)e.AddedItems[0];

            Frame.Navigate(typeof(BlankPage1), savedSelection);
        }
    }
}
