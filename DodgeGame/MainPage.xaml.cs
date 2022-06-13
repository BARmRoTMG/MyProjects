using System;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;
using Windows.Foundation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using DodgeGame.Scripts;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Popups;

namespace DodgeGame
{
    public sealed partial class MainPage : Page
    {
        GameManager gameManager;
        DispatcherTimer _timer;
        
        //SETTINGS FIELDS
        private bool isStarted = false;
        private bool isIdle;
        
        public MainPage()
        {
            this.InitializeComponent();

            Rect windowRectangle = ApplicationView.GetForCurrentView().VisibleBounds;
            gameManager = new GameManager(windowRectangle.Width, windowRectangle.Height);

            InitializeScreen();  

            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
        }

        public void InitializeScreen()
        {
            //Game Screen Settings
            Rect windowRectangle = ApplicationView.GetForCurrentView().VisibleBounds;
            gameManager = new GameManager(windowRectangle.Width, windowRectangle.Height);
            ApplicationView.PreferredLaunchViewSize = new Size(1000, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            canvas.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Background.jpg")) };
        }

        public void InitializePlayer()
        {
            //Player Settings
            gameManager._playerSprite = new Rectangle();
            gameManager._playerSprite.Width = 90;
            gameManager._playerSprite.Height = 70;
            gameManager._playerSprite.Fill = new ImageBrush { ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Player.png")) };
            Canvas.SetTop(gameManager._playerSprite, 400);
            Canvas.SetLeft(gameManager._playerSprite, 450);
            canvas.Children.Add(gameManager._playerSprite);
        }

        public void InitializeEnemy()
        {
            //Spawn Enemy
            gameManager.enemies = new Rectangle[10]; 

            for (int i = 0; i < gameManager.enemies.Length; i++)
            {
                Enemy currentEnemy = gameManager.enemiesArr[i];    
                gameManager.enemies[i] = AddSprite(currentEnemy);
                gameManager.RandomizeEnemyLoc();
            }
        }

        //USER INPUT
        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs e)
        {          
            switch (e.VirtualKey)
            {
                case VirtualKey.W:
                    if (Canvas.GetTop(gameManager._playerSprite) <= 0)
                    {
                        Canvas.SetTop(gameManager._playerSprite, Canvas.GetTop(gameManager._playerSprite));
                        PlayerCollision();
                    } else
                    {
                        Canvas.SetTop(gameManager._playerSprite, Canvas.GetTop(gameManager._playerSprite) - 10);
                        gameManager.player.X = (int)Canvas.GetTop(gameManager._playerSprite) - 10;
                        PlayerCollision();
                    }
                    break;
                case VirtualKey.S:
                    if (Canvas.GetTop(gameManager._playerSprite) >= Window.Current.Bounds.Height - 70)
                    {
                        Canvas.SetTop(gameManager._playerSprite, Canvas.GetTop(gameManager._playerSprite));
                        PlayerCollision();
                    } else
                    {
                        Canvas.SetTop(gameManager._playerSprite, Canvas.GetTop(gameManager._playerSprite) + 10);
                        gameManager.player.X = (int)Canvas.GetTop(gameManager._playerSprite) + 10;
                        PlayerCollision();
                    }
                    break;
                case VirtualKey.A:                   
                        if (Canvas.GetLeft(gameManager._playerSprite) <= 0)
                        {
                            Canvas.SetLeft(gameManager._playerSprite, Canvas.GetLeft(gameManager._playerSprite));
                            PlayerCollision();
                        }
                        else
                        {
                             Canvas.SetLeft(gameManager._playerSprite, Canvas.GetLeft(gameManager._playerSprite) - 10);
                             gameManager.player.Y = (int)Canvas.GetLeft(gameManager._playerSprite) - 10;
                             PlayerCollision();
                        }
                    break;
                case VirtualKey.D:
                    if (Canvas.GetLeft(gameManager._playerSprite) >= Window.Current.Bounds.Width - 70)
                    {
                        Canvas.SetLeft(gameManager._playerSprite, Canvas.GetLeft(gameManager._playerSprite));
                        PlayerCollision();
                    }
                    else
                    {
                        Canvas.SetLeft(gameManager._playerSprite, Canvas.GetLeft(gameManager._playerSprite) + 10);
                        gameManager.player.Y = (int)Canvas.GetLeft(gameManager._playerSprite) + 10;
                        PlayerCollision();
                    }
                    break;
                default:
                    if (isIdle)
                        Canvas.SetLeft(gameManager._playerSprite, Canvas.GetLeft(gameManager._playerSprite));
                    break;
            }
        }

        public Rectangle AddSprite(PlayerController playerController)
        {
            gameManager._enemySprite = new Rectangle();
            gameManager._enemySprite.Fill = new ImageBrush { ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/scorpion.png")) };

            gameManager._enemySprite.Width = playerController.Width;
            gameManager._enemySprite.Height = playerController.Height;

            Canvas.SetLeft(gameManager._enemySprite, playerController.X);
            Canvas.SetTop(gameManager._enemySprite, playerController.Y);

            canvas.Children.Add(gameManager._enemySprite);

            return gameManager._enemySprite;
        }
        public void StartTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(0.01);
            _timer.Tick += TimeManagment;
            _timer.Start();
        }

        public void TimeManagment(object sender, object e)
        {   
            EnemyMove();
            Collision();
            PlayerCollision();
            CheckWinLoose();
        }

        public void EnemyMove()
        {
            for (int i = 0; i < gameManager.enemies.Length; i++)
            {
                if (Canvas.GetTop(gameManager._playerSprite) < Canvas.GetTop(gameManager.enemies[i]))
                    Canvas.SetTop(gameManager.enemies[i], Canvas.GetTop(gameManager.enemies[i]) - gameManager.MoveSpeed);
                else if (Canvas.GetTop(gameManager._playerSprite) > Canvas.GetTop(gameManager.enemies[i]))
                    Canvas.SetTop(gameManager.enemies[i], Canvas.GetTop(gameManager.enemies[i]) + gameManager.MoveSpeed);

                if (Canvas.GetLeft(gameManager._playerSprite) < Canvas.GetLeft(gameManager.enemies[i]))
                    Canvas.SetLeft(gameManager.enemies[i], Canvas.GetLeft(gameManager.enemies[i]) - gameManager.MoveSpeed);
                else if (Canvas.GetLeft(gameManager._playerSprite) > Canvas.GetLeft(gameManager.enemies[i]))
                    Canvas.SetLeft(gameManager.enemies[i], Canvas.GetLeft(gameManager.enemies[i]) + gameManager.MoveSpeed);
            }
        }

        public void Collision()
        {
            for (int i = 0; i < gameManager.enemies.Length; i++)
            {
                for (int j = 0; j < gameManager.enemies.Length; j++)
                {
                    if (i != j)
                    {
                        if (Math.Pow(Canvas.GetTop(gameManager.enemies[i]) - (Canvas.GetTop(gameManager.enemies[j])), 2) + Math.Pow(Canvas.GetLeft(gameManager.enemies[i]) - (Canvas.GetLeft(gameManager.enemies[j])), 2) <= Math.Pow(gameManager._enemySprite.Width, 2))
                        {
                            gameManager.EnemiesCounter++;
                            Canvas.SetLeft(gameManager.enemies[i], 500000);
                            Canvas.SetTop(gameManager.enemies[i], 500000);
                            canvas.Children.Remove(gameManager.enemies[i]);
                        }
                    }

                }
            }
        }

        public void PlayerCollision()
        {
            for (int i = 0; i < gameManager.enemies.Length; i++)
            {
                for (int j = 0; j < gameManager.enemies.Length; j++)
                {
                    if (i != j)
                    {
                        if (Math.Pow(Canvas.GetTop(gameManager.enemies[i]) - (Canvas.GetTop(gameManager._playerSprite)), 2) + Math.Pow(Canvas.GetLeft(gameManager.enemies[i]) - (Canvas.GetLeft(gameManager._playerSprite)), 2) <= Math.Pow(gameManager._playerSprite.Width, 2))
                        {
                            Canvas.SetLeft(gameManager._playerSprite, 500000);
                            Canvas.SetTop(gameManager._playerSprite, 50000);
                            gameManager.LifesLeft--;
                        }
                    }

                }
            }
        }

        public void DestroyAll()
        {
            for (var i = 0; i < gameManager.enemies.Length; i++)
            {
                canvas.Children.Remove(gameManager.enemies[i]);
            }
            canvas.Children.Remove(gameManager._playerSprite);
        }

        public void StartNewGame()
        {
            StartTimer();
            InitializePlayer();
            InitializeEnemy();
            healthText.Text = Convert.ToString(gameManager.LifesLeft);
        }

        public async void CheckWinLoose()
        {
            if (Canvas.GetLeft(gameManager._playerSprite) == 500000)
            {
                _timer.Stop();
                MessageDialog lost = new MessageDialog("PLAYER DIED!\nTry again..."); await lost.ShowAsync();
                DestroyAll();
                StartNewGame();
            }
            else if (gameManager.EnemiesCounter == 9) // canvas.Children.Count == 2 && canvas.Children.Contains(gameManager._playerSprite)
            {
                _timer.Stop();
                MessageDialog won = new MessageDialog("YOU WON!!\nTry it on hard mode..."); await won.ShowAsync();
                DestroyAll();
                StartNewGame();
            }
        }

        private void SavingMethod_2()
        {
            //SAVING PLAYER LOCATION
            gameManager.playerLastX = Canvas.GetTop(gameManager._playerSprite);
            gameManager.playerLastY = Canvas.GetLeft(gameManager._playerSprite);

            //SAVING ENEMY LOCATION
            for (int i = 0; i < gameManager.enemies.Length; i++)
            {
                gameManager.enemyLastX[i] = Canvas.GetTop(gameManager.enemies[i]);
                gameManager.enemyLastY[i] = Canvas.GetLeft(gameManager.enemies[i]);
            }
        }

        private void LoadingMethod_2()
        {
            //PLACING PLAYER LOCATION
            Canvas.SetTop(gameManager._playerSprite, gameManager.playerLastX);
            Canvas.SetLeft(gameManager._playerSprite, gameManager.playerLastY);

            //PLACING ENEMY LOCATION
            for (int i = 0; i < gameManager.enemies.Length; i++)
            {
                Canvas.SetTop(gameManager.enemies[i], gameManager.enemyLastX[i]);
                Canvas.SetLeft(gameManager.enemies[i], gameManager.enemyLastY[i]);
            }
        }

        #region COMMAND BAR BUTTONS
        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (pause_play.Symbol.Equals(Symbol.Play))
            {
                pause_play.Symbol = Symbol.Pause;
                _timer.Start();
                startNewButton.IsEnabled = true;
            }
            else if (pause_play.Symbol.Equals(Symbol.Pause))
            {
                pause_play.Symbol = Symbol.Play;
                _timer.Stop();
                isIdle = true;
                startNewButton.IsEnabled = false;
            }
        }

        private void startNewButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isStarted)
            {
                StartNewGame();
                startNewButton.Content = "RESTART";
                isStarted = true;
            } else 
            {
                DestroyAll();
                InitializePlayer();
                InitializeEnemy();
                healthText.Text = Convert.ToString(gameManager.LifesLeft);
            }

        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e) // Easy B
        {
            gameManager.MoveSpeed = 1f;
        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e) // Normal B
        {
            gameManager.MoveSpeed = 1.5f;
        }

        private void MenuFlyoutItem_Click_2(object sender, RoutedEventArgs e) // HARD B
        {
            gameManager.MoveSpeed = 2f;
        }

        private void saveGameButton_Click(object sender, RoutedEventArgs e)
        {
            SavingMethod_2();
            Storage.CreateFile(); //not working
        }

        private void loadGameButton_Click(object sender, RoutedEventArgs e)
        {
            LoadingMethod_2();
            Storage.ReadFile(); // not working
        }
        #endregion

    }
}
