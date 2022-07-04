using System;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;
using Windows.Foundation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Popups;
using System.Collections.Generic;

namespace HangedMan
{
    public sealed partial class MainPage : Page
    {
        List<Button> _buttons;
        List<BitmapImage> _images;
        List<TextBlock> _charField;

        string _word;
        int _counter = 0;

        public MainPage()
        {
            this.InitializeComponent();
            IntializeGame();
        }

        public void IntializeGame()
        {
            InitializeWindow();
            _images = new List<BitmapImage>();
            LoadImage();
            CreateWordArea();
        }

        public void InitializeWindow()
        {
            ApplicationView view = ApplicationView.GetForCurrentView();
            view.Title = "Bar Mashiach";
            ApplicationView.PreferredLaunchViewSize = new Size(1920, 1080);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            canvas.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/chalkboard.png")) };
        }

        private void CreateKeyboard()
        {
            _buttons = new List<Button>();

            firstRow.Children.Clear();
            secondRow.Children.Clear();
            thirdRow.Children.Clear();

            for (int i = 65; i < 91; i++) //A-Z
            {
                Button button = new Button()
                {
                    Content = ((char)i).ToString(),
                    FontSize = 35,
                    Width = 80,
                    Height = 80,
                    Margin = new Thickness(2)
                };
                button.Click += Keyboard_Click;
                if (i % 65 < 8)
                    firstRow.Children.Add(button);
                else if (i % 65 >= 8 && i % 65 < 16)
                    secondRow.Children.Add(button);
                else
                    thirdRow.Children.Add(button);

                _buttons.Add(button);
            }
        }

        private void LoadImage()
        {
            for (int i = 0; i < 11; i++)
            {
                var image = new BitmapImage(new Uri(@"ms-appx:/HangedManImages/H" + i.ToString() + ".png"));
                _images.Add(image);
            }
        }

        private string WordGenerator()
        {
            string[] _words = { "cat", "dog", "house", "apple", "banana", "elephant" };
            Random rnd = new Random();
            return _words[rnd.Next(_words.Length)];
        }
        
        private void CreateWordArea()
        {
            _counter = 0;
            CreateKeyboard();
            this._word = WordGenerator();
            imageMiss.Source = _images[0];
            _charField = new List<TextBlock>();
            wordArea.Children.Clear(); 
            
            for (int i = 0; i < this._word.Length; i++)
            {
                TextBlock textBlock = new TextBlock()
                {
                    Text = "_",
                    Margin = new Thickness(10),
                    FontSize = 50
                };
                wordArea.Children.Add(textBlock);
                _charField.Add(textBlock);
            }
            _charField[0].Text = this._word[0].ToString(); // First char of word
            _charField[this._word.Length - 1].Text = this._word[this._word.Length - 1].ToString(); // Last char of word
        }
        private void Keyboard_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string character = button.Content.ToString();
            bool hit = false;

            for (int i = 1; i < this._word.Length - 1; i++) // Without first and last letters
            {
                if (this._word[i].ToString().ToLower() == character.ToLower())
                {
                    hit = true;
                    _charField[i].Text = character.ToLower();
                }
            }

            if (hit == false)
            {
                _counter += 1;
                imageMiss.Source = _images[_counter];
            }

            // Lose
            if (_counter == 10)
            {
                MessageToUserAsync("You lost!");
            }

            //Win
            int count = 0;
            for (int i = 0; i < this._word.Length; i++)
            {
                if (_charField[i].Text != "_")
                    count++;
            }

            if (count == this._word.Length)
            {
                MessageToUserAsync("You win!");
            }
            button.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateWordArea();
        }

        private async void MessageToUserAsync(string s)
        {
            MessageDialog messageDialog = new MessageDialog("Play again", s);
            await messageDialog.ShowAsync();
            CreateWordArea(); // Starts new game
        }
    }
}
