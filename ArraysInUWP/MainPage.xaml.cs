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

namespace ArraysInUWP
{
    public sealed partial class MainPage : Page
    {
        private const int _NUMBER_OF_STUDENTS = 5;
        private int _counter = 0;
        private string[] _namesList;

        public MainPage()
        {
            this.InitializeComponent();
            _namesList = new string[_NUMBER_OF_STUDENTS];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _namesList[_counter] = nameInput.Text + "\t" + gradeInput.Text;
            nameInput.Text = "";
            gradeInput.Text = "";
            listOutput.Items.Add(_namesList[_counter]);
            _counter++;

            if (_counter == _NUMBER_OF_STUDENTS)
                    enterButton.IsEnabled = false;
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            if (listOutput.SelectedIndex != -1)
                nameInput.Text = listOutput.SelectedItem.ToString();
        }

        private void RemoveSelected_Click(object sender, RoutedEventArgs e)
        {
            if (listOutput.SelectedIndex != -1)
                //listOutput.SelectedItems.Clear();
        }

        private void RemoveFirst_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveLast_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
