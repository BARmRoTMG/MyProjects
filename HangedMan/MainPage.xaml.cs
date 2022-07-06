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
        int difficultyLevel = 0;

        public int DifficultyLevel
        {
            get { return difficultyLevel; }
            set { difficultyLevel = value; }
        }

        public MainPage()
        {
            this.InitializeComponent();
            IntializeGame();
        }

        public void IntializeGame() //New Game Creation
        {
            InitializeWindow();
            _images = new List<BitmapImage>();
            LoadImage();
            CreateWordArea();
        }

        public void InitializeWindow() //UI/Screen Initializer
        {
            ApplicationView view = ApplicationView.GetForCurrentView();
            view.Title = "Bar Mashiach";
            ApplicationView.PreferredLaunchViewSize = new Size(1920, 1080);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            canvas.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/background.jpg")) };
        }

        private void CreateKeyboard() //Screen Keyboard
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

        private void LoadImage() //Image changer
        {
            for (int i = 0; i < 11; i++)
            {
                var image = new BitmapImage(new Uri(@"ms-appx:/HangedManImages/H" + i.ToString() + ".png"));
                _images.Add(image);
            }
        }

        private string WordGenerator()
        {
            string[] easy = { "chicken", "football", "house", "television", "sugar", "elephant" };
            string[] normal = { "conversation", "strength", "production", "eliminate", "suspect", "character" };
            string[] hard = { "achievement", "violation", "continuous", "exhibition", "pedestrian", "atmosphere" };

            Random rnd = new Random();

            if (difficultyLevel == 0)
                return easy[rnd.Next(easy.Length)];
            else if (difficultyLevel == 1)
                return normal[rnd.Next(normal.Length)];
            else if (difficultyLevel == 2)
                return hard[rnd.Next(hard.Length)];

            return easy[rnd.Next(easy.Length)];
        } //Word generator by difficulty
        
        private void CreateWordArea() //Initializing words
        {
            _counter = 0;
            CreateKeyboard();
            this._word = WordGenerator();
            imageHolder.Source = _images[0];
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
        private void Keyboard_Click(object sender, RoutedEventArgs e) //Keybaord Input
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
                imageHolder.Source = _images[_counter];
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

        private void Button_Click(object sender, RoutedEventArgs e) //New Game Button
        {
            CreateWordArea();
        }

        private async void MessageToUserAsync(string s)
        {
            MessageDialog messageDialog = new MessageDialog("Play again", s);
            await messageDialog.ShowAsync();
            CreateWordArea(); // Starts new game
        } //General Play Again Button to Dialog Box
        private void difficulty_Click(object sender, RoutedEventArgs e)
        {
            difficultyLevel++;
            textHolder.Text = "Click on 'New Game' for the difficulty change to take effect.";

            switch (difficultyLevel)
            {
                case 0:
                    difficulty.Content = "Easy";
                    difficultyLevel = 0;
                    break;
                case 1:
                    difficulty.Content = "Normal";
                    difficultyLevel = 1;
                    break;
                case 2:
                    difficulty.Content = "Hard";
                    difficultyLevel = 2;
                    break;
                default:
                    difficulty.Content = "Easy";
                    difficultyLevel = 0;
                    break;
            }
        } //Dynamic Difficulty Button

        private void Button_Click_1(object sender, RoutedEventArgs e) //Hint Button
        {
            Random r = new Random();
            _charField[r.Next(this._word.Length)].Text = this._word[r.Next(this._word.Length - 1)].ToString();
        }
    }
}
