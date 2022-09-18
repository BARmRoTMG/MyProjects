using CustomerDatabase.Models;
using MyDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace CustomerDatabase
{
    public partial class MainWindow : Window
    {
        readonly DataContex data = new DataContex();

        public MainWindow()
        {
            InitializeComponent();
            lvCustomers.ItemsSource = data.Customers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //order by first name
        {
            try
            {
                lvCustomers.ItemsSource = data.Customers.OrderBy(x => x.Name).ToList();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //order by surname
        {
            try
            {
                lvCustomers.ItemsSource = data.Customers.OrderBy(x => x.Surname).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //add new customer
        {
            try
            {
                if (newNametb.Text != "" || newSurnametb.Text != "")
                {
                    using (data)
                    {
                        var newC = new Customer { Name = newNametb.Text, Surname = newSurnametb.Text };
                        data.Customers.Add(new Customer { Name = newNametb.Text, Surname = newSurnametb.Text });
                        data.SaveChanges();
                        lvCustomers.ItemsSource = data.Customers.ToList();
                        MessageBox.Show("Customer added.");
                    }
                }
                else
                    MessageBox.Show("Missing fields.");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) // change excisting customer
        {
            data.SaveChanges();
        }
    }
}
