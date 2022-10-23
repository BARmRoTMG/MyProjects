using BookLibraryAdvanced.DAL;
using BookLibraryAdvanced.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookLibraryUIAdvanced
{
    /// <summary>
    /// Interaction logic for WorkerView.xaml
    /// </summary>
    public partial class WorkerView : Page
    {
        readonly Repository data = new Repository();

        public WorkerView()
        {
            InitializeComponent();
        }

        private void AddItemBtn(object sender, RoutedEventArgs e)
        {
            data.AddBook(new Book { Title = tbTitle.Text, Author = tbAuthor.Text, Price = double.Parse(tbPrice.Text) });
        }
    }
}
