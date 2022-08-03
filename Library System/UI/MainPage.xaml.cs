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

namespace UI
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ScreenSettings();

            Manager library = new Manager();
        }

        private void ScreenSettings()
        {
            frame.Navigate(typeof(MainMenu));
            ApplicationView view = ApplicationView.GetForCurrentView();
            view.Title = "The Grand Library";
            ApplicationView.PreferredLaunchViewSize = new Size(900, 600);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            //canvas.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/LibraryBackground.png")) };
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(CustomerPage));
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(LibrarianAdd));
        }
    }
}
