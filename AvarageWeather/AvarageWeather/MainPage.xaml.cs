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
using System.Drawing;
//using Windows.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AvarageWeather
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double Day1 = double.Parse(day1.Text);
            double Day2 = double.Parse(day2.Text);
            double Day3 = double.Parse(day3.Text);
            double sum = Day1 + Day2 + Day3;
            double weatherSum = sum / 3;

            if (weatherSum <= 15)
            {
                resultTxt.Text = "It was cold!";
                //resultTxt.Foreground = new SolidColorBrush(Color.AliceBlue);
            }
            else
            {
                resultTxt.Text = "It was hot!";
            }
        }
    }
}
