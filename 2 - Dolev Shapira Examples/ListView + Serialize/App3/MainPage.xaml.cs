using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;
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
        string filePath = $@"{Windows.Storage.ApplicationData.Current.LocalFolder.Path}\ItemsList.xml";

        List<string> items = new List<string>();


        public void RefreshList()
        {
            BooksListView.Items.Clear();

            foreach (string item in items)
            {
                BooksListView.Items.Add(item);
            }
        }


        public MainPage()
        {
            this.InitializeComponent();

            if (File.Exists(filePath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
                FileStream stream = new FileStream(filePath, FileMode.Open);
                items = (List<string>)xmlSerializer.Deserialize(stream);
                stream.Close();
            }
            else
            {
                items = new List<string>();
                items.Add("a1");
                items.Add("a2");
                items.Add("a3");

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
                FileStream stream = new FileStream(filePath, FileMode.Create);
                xmlSerializer.Serialize(stream, items);
                stream.Close();
            }
            RefreshList();
        }

        public void SaveAndRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshList();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
            
            FileStream stream = new FileStream(filePath, FileMode.Create);
            xmlSerializer.Serialize(stream, items);
            stream.Close();
        }
    }
}
