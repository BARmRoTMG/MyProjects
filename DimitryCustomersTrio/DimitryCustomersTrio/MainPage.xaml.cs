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

namespace DimitryCustomersTrio
{
    public sealed partial class MainPage : Page
    {
        int page = 0;
        int pageCount = 3;
        readonly DataService service = new DataService();

        public MainPage()
        {
            this.InitializeComponent();
            SetCustomersToListView();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Back
        {
            page--;
            SetCustomersToListView();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //Next
        {
            page++;
            SetCustomersToListView();
        }

        private void SetCustomersToListView()
        {
            lvCustomers.Items.Clear();
            var customers = service.Customers
                                    .Skip(page * pageCount)
                                    .Take(pageCount)
                                    .ToList();

            customers.ForEach(c => lvCustomers.Items.Add(c));

            tbAverageAge.Text = customers.Average(c => c.Age).ToString();
        }
    }
}
