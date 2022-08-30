using Logic_Manager;
using Logic_Manager.Enums;
using Logic_Manager.Exceptions;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace UI
{
    public partial class LibrarianAdd : Page
    {
        Manager manager = new Manager();
        MessageDialog messageDialog;

        public LibrarianAdd()
        {
            this.InitializeComponent();
            grid.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/windows.jpg")) };

            var enumValueList = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList();
            genreInput.ItemsSource = enumValueList;
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LibrarianEdit));
        }

        private async void enterBtn_Click(object sender, RoutedEventArgs e) //Insert Button
        {
            var selectedItem = genreInput.SelectedItem;

            try
            {
                if (!isJournalToggle.IsOn && selectedItem != null)
                {
                    Book book = new Book(nameInput.Text, authorInput.Text, (Genre)Enum.Parse(typeof(Genre), selectedItem.ToString()), publishingCompanyInput.Text, double.Parse(priceInput.Text), double.Parse(discountInput.Text));
                    manager.list.Add(book);
                    messageDialog = new MessageDialog("Book added successfully");
                    await messageDialog.ShowAsync();
                    ClearFields();
                } else if (isJournalToggle.IsOn && selectedItem != null)
                {
                    Journal journal = new Journal(nameInput.Text, (Genre)Enum.Parse(typeof(Genre), selectedItem.ToString()), publishingCompanyInput.Text, double.Parse(priceInput.Text), double.Parse(discountInput.Text));
                    manager.list.Add(journal);
                    messageDialog = new MessageDialog("Journal added successfully");
                    await messageDialog.ShowAsync();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling(ex);
                return;
            }
        }

        private async void ExceptionHandling(Exception exception)
        {
            if (exception.GetType() == typeof(Exception)
                || exception.GetType() == typeof(ItemAlreadyExistsException)
                || exception.GetType() == typeof(ServerErrorException) || exception.GetType() == typeof(AmountMinException)
                || exception.GetType() == typeof(PriceMinOrMaxException) || exception.GetType() == typeof(ArgumentNullException)
                || exception.GetType() == typeof(FormatException))
            {
                messageDialog = new MessageDialog(exception.Message);
                await messageDialog.ShowAsync();
                return;
            }
        }

        private void ClearFields()
        {
            nameInput.Text = "";
            authorInput.Text = "";
            genreInput.SelectedItem = null;
            publishingCompanyInput.Text = "";
            priceInput.Text = "";
            discountInput.Text = "";
        }
    }
}
