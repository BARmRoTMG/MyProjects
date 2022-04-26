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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void plus_Click(object sender, RoutedEventArgs e)
        {
            double num1Input;
            bool bnum1 = double.TryParse(num1.Text, out num1Input);

            double num2Input;
            bool bnum2 = double.TryParse(num2.Text, out num2Input);

            double mathResult = num1Input + num2Input;

            if (bnum1 && bnum2)
            {
                result.Text = Convert.ToString(mathResult);
            }
            else
            {
                var messageDialog = new MessageDialog("That's not how you do math!");
                var result = await messageDialog.ShowAsync();
            }
        }

        private async void minus_Click(object sender, RoutedEventArgs e)
        {
            double num1Input;
            bool bnum1 = double.TryParse(num1.Text, out num1Input);

            double num2Input;
            bool bnum2 = double.TryParse(num2.Text, out num2Input);

            double mathResult = num1Input - num2Input;

            if (bnum1 && bnum2)
            {
                result.Text = Convert.ToString(mathResult);
            }
            else
            {
                var messageDialog = new MessageDialog("That's not how you do math!");
                var result = await messageDialog.ShowAsync();
            }
        }

        private async void times_Click(object sender, RoutedEventArgs e)
        {
            double num1Input;
            bool bnum1 = double.TryParse(num1.Text, out num1Input);

            double num2Input;
            bool bnum2 = double.TryParse(num2.Text, out num2Input);

            double mathResult = num1Input * num2Input;

            if (bnum1 && bnum2)
            {
                result.Text = Convert.ToString(mathResult);
            }
            else
            {
                var messageDialog = new MessageDialog("That's not how you do math!");
                var result = await messageDialog.ShowAsync();
            }
        }

        private async void devide_Click(object sender, RoutedEventArgs e)
        {
            double num1Input;
            bool bnum1 = double.TryParse(num1.Text, out num1Input);

            double num2Input;
            bool bnum2 = double.TryParse(num2.Text, out num2Input);

            double mathResult = num1Input / num2Input;

            if (bnum1 && bnum2)
            {
                result.Text = Convert.ToString(mathResult);
            }
            else
            {
                var messageDialog = new MessageDialog("That's not how you do math!");
                var result = await messageDialog.ShowAsync();
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            result.Text = Convert.ToString(0);
        }
    }
}
