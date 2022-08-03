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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace UI
{
    public sealed partial class LibrarianAdd : Page
    {
        public LibrarianAdd()
        {
            this.InitializeComponent();
            grid.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/windows.jpg")) };
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            frame.Visibility = Visibility.Visible;
            frame.Navigate(typeof(LibrarianEdit));
        }
    }
}
