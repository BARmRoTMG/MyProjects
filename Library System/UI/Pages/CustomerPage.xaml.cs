using Logic_Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Microsoft.Toolkit.Uwp;
using Windows.UI.Popups;

namespace UI.Pages
{
    public sealed partial class CustomerPage : Page
    {
        Manager manager = new Manager();
        MainPage mainPage = new MainPage();
        MessageDialog messageDialog;

        //string filePath = $@"{Windows.Storage.ApplicationData.Current.LocalFolder.Path}\ItemsList.xml";

        public CustomerPage()
        {
            this.InitializeComponent();
            grid.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/windows.jpg")) };

            foreach (Items item in manager.list)
                itemDataGrid.ItemsSource = item.ToString();

            mainPage.UpdateListView(collectionListView);

            //if (File.Exists(filePath))
            //{
            //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
            //    FileStream stream = new FileStream(filePath, FileMode.Open);
            //    manager.list = (List<Items>)xmlSerializer.Deserialize(stream);
            //    stream.Close();
            //}
            //else
            //{
            //    manager.list = new List<Items>();
            //    foreach (Items item in manager.list)
            //        manager.list.Add(item);

            //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
            //    FileStream stream = new FileStream(filePath, FileMode.Create);
            //    xmlSerializer.Serialize(stream, manager.list);
            //    stream.Close();
            //}


            //mainPage.UpdateListView(collectionListView);
        }


        private async void leaseBtn_Click(object sender, RoutedEventArgs e)
        {

            messageDialog = new MessageDialog("Action not added yet.");
            await messageDialog.ShowAsync();
            //mainPage.UpdateListView(collectionListView);

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));

            //FileStream stream = new FileStream(filePath, FileMode.Create);
            //xmlSerializer.Serialize(stream, manager.list);
            //stream.Close();
        }

        private async void returnBtn_Click(object sender, RoutedEventArgs e)
        {
            messageDialog = new MessageDialog("Action not added yet.");
            await messageDialog.ShowAsync();
        }
    }
}
