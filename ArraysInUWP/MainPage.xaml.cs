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
using Windows.UI.Popups;

namespace ArraysInUWP
{
    public sealed partial class MainPage : Page
    {
        private const int _NUMBER_OF_STUDENTS = 5;
        private int _counter = 0;
        private string[] _namesList;
        private int[] _gradesList;

        public MainPage()
        {
            this.InitializeComponent();
            _namesList = new string[_NUMBER_OF_STUDENTS];
            _gradesList = new int[_NUMBER_OF_STUDENTS];
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameInput.Text) && int.TryParse(gradeInput.Text, out _gradesList[_counter]))
            {
                listOutput.Items.Add(nameInput.Text + "\t\t" + gradeInput.Text);
                _namesList[_counter] = nameInput.Text;
                _counter++;
                gradeInput.Text = "";
                nameInput.Text = "";
                nameInput.Focus(FocusState.Keyboard);
            } else
            {
                MessageDialog msg = new MessageDialog("ERROR:\nThe name or the grade you entered are incorect.");
                msg.ShowAsync();
            }
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            if (listOutput.SelectedIndex != -1)
                nameInput.Text = listOutput.SelectedItem.ToString();
        }

        private void RemoveSelected_Click(object sender, RoutedEventArgs e)
        {
            if (listOutput.SelectedIndex != -1)
                listOutput.Items.RemoveAt(listOutput.SelectedIndex);
        }

        private void RemoveFirst_Click(object sender, RoutedEventArgs e)
        {
            if (listOutput.Items.Count > 0)
                listOutput.Items.RemoveAt(0);
        }

        private void RemoveLast_Click(object sender, RoutedEventArgs e)
        {
            if (listOutput.Items.Count > 0)
                listOutput.Items.RemoveAt(listOutput.Items.Count - 1);
        }

        private void listOutput_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_counter < _NUMBER_OF_STUDENTS)
                enterButton.IsEnabled = true;
            else
                enterButton.IsEnabled = false;
        }

        private void sortButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
