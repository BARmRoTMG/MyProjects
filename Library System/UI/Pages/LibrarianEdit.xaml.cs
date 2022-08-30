using System;
using Logic_Manager.Enums;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Logic_Manager;
using Windows.UI.Popups;

namespace UI
{
    public sealed partial class LibrarianEdit : Page
    {
        Manager manager = new Manager();
        MessageDialog messageDialog;
        public LibrarianEdit()
        {
            this.InitializeComponent();
            grid.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/windows.jpg")) };

            var enumValueList = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList();
            genreInput.ItemsSource = enumValueList;


        }

        private void hyperBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LibrarianAdd));
        }

        private void SetFirstItem()
        {
            nameTxt.Text = manager.list.ToString();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            messageDialog = new MessageDialog("Action not added yet.");
            await messageDialog.ShowAsync();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            messageDialog = new MessageDialog("Action not added yet.");
            await messageDialog.ShowAsync();
        }
    }
}
