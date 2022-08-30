using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Logic_Manager;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.ObjectModel;

namespace UI
{
    public sealed partial class MainPage : Page
    {
        Manager manager = new Manager();

        public MainPage()
        {
            this.InitializeComponent();
            ScreenSettings();
        }

        private void ScreenSettings()
        {
            frame.Navigate(typeof(MainMenu));
            ApplicationView view = ApplicationView.GetForCurrentView();
            view.Title = "The Grand Library";
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(Pages.CustomerPage));
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(LibrarianAdd));
        }

        public void UpdateListView(ListView listView)
        {
            listView.Items.Clear();

            foreach (Items item in manager.list)
                listView.Items.Add(item);
        }
    }
}
