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

namespace SmokingChecker
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        int menIsSmoking = 0;
        int menNoSmoking = 0;
        int womenIsSmoking = 0;
        int womenNoSmoking = 0;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int userInput1;
            int userInput2;

            if (int.TryParse(menWomen.Text, out userInput1) && int.TryParse(smoking.Text, out userInput2))
            {
                if (userInput1 == 1 || userInput1 == 2 && userInput2 == 1 || userInput2 == 2)
                {
                    if (userInput1 == 1 && userInput2 == 1) //smoking men
                    {
                        menIsSmoking++;
                    }
                    if (userInput1 == 1 && userInput2 == 2) //non smoking men
                    {
                        menNoSmoking++;
                    }

                    if (userInput1 == 2 && userInput2 == 1) //smoking women
                    {
                        womenIsSmoking++;
                    }
                    if (userInput1 == 2 && userInput2 == 2) //non smoking women
                    {
                        womenNoSmoking++;
                    }
                } else
                {
                    var messageDialog = new MessageDialog("Please enter 1 or 2!");
                    var result = await messageDialog.ShowAsync();
                    Console.WriteLine("Please enter 1 or 2!");
                }
            } else
            {          
                var messageeDialog = new MessageDialog("Invalid data type!");
                var resultt = await messageeDialog.ShowAsync();
                Console.WriteLine("Invalid data type!");
            }
            menSmoker.Text = Convert.ToString(menIsSmoking);
            menNoSmoker.Text = Convert.ToString(menNoSmoking);
            womenSmoker.Text = Convert.ToString(womenIsSmoking);
            womenNoSmoker.Text = Convert.ToString(womenNoSmoking);
        }
    }
}
