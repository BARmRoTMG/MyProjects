﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
            if (!string.IsNullOrWhiteSpace(nameInput.Text) && int.TryParse(gradeInput.Text, out _gradesList[_counter]) && _gradesList[_counter] > -1 && _gradesList[_counter] < 101)
            {
                listOutput.Items.Add($"{_counter + 1}) { nameInput.Text} \t:\t {gradeInput.Text} ");
                _namesList[_counter] = nameInput.Text;
                _counter++;
                gradeInput.Text = "";
                nameInput.Text = "";
                nameInput.Focus(FocusState.Keyboard);

                if (_counter == _NUMBER_OF_STUDENTS)
                    enterButton.IsEnabled = false;
            } else
            {
                MessageDialog msg = new MessageDialog("ERROR:\nThe name or the grade you entered are incorect.");
                await msg.ShowAsync();
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
            BubbleSortArray(_gradesList, _namesList);

            for (int i = 0; i < _gradesList.Length; i++)
            {
                if (_gradesList[i] != 0)
                    listOutput.Items.Add($"{i + 1}) {_namesList[i]} \t:\t {_gradesList[i]}");
            }
        }

        private void BubbleSortArray(int[] arr, string[] stringArr) 
        {
            listOutput.Items.Clear();

            int _temp;
            string _temp2;

            for (int i = (arr.Length - 1); i >= 0; i--)
            {
                bool swap = false;
                for (int j = 1; j <= i; j++)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        _temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = _temp;

                        _temp2 = stringArr[j - 1];
                        stringArr[j - 1] = stringArr[j];
                        stringArr[j] = _temp2;

                        swap = true;
                    }
                }
                if (swap == false)
                    break;
            }
        }
    }
}
