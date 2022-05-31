using System;
using System.IO;
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Shapes;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DodgeGame.Scripts;
using Windows.UI.Xaml.Media.Imaging;

namespace DodgeGame
{
    public sealed partial class MainPage : Page
    {
        GameManager gameManager;
        DispatcherTimer _timer;
        

        bool isRight = false;

        //SETTINGS FIELDS
        private bool isPaused = false;
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
                    isIdle = true;
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
            for (int i = 0; i < gameManager.enemiesArr.Length; i++)
            {
                for (int j = 0; j < gameManager.enemiesArr.Length; j++)
                {
                    if (i != j)
                    {
                        if (Math.Pow(Canvas.GetTop(gameManager.enemies[i]) - (Canvas.GetTop(gameManager.enemies[j])), 2) + Math.Pow(Canvas.GetLeft(gameManager.enemies[i]) - (Canvas.GetLeft(gameManager.enemies[j])), 2) <= Math.Pow(gameManager._enemySprite.Width, 2))
                        {
                            Canvas.SetLeft(gameManager.enemies[i], 5000);
                            Canvas.SetTop(gameManager.enemies[i], 5000);
                            gameManager.EnemiesCounter--;
                        }
                    }

                }
            }
        }

        public void PlayerCollision()
        {
            for (int i = 0; i < gameManager.enemiesArr.Length; i++)
            {
                for (int j = 0; j < gameManager.enemiesArr.Length; j++)
                {
                    if (i != j)
                    {
                        if (Math.Pow(Canvas.GetTop(gameManager.enemies[i]) - (Canvas.GetTop(gameManager._playerSprite)), 2) + Math.Pow(Canvas.GetLeft(gameManager.enemies[i]) - (Canvas.GetLeft(gameManager._playerSprite)), 2) <= Math.Pow(gameManager._playerSprite.Width, 2))
                        {
                            if (gameManager.LifesLeft > 0)
                                healthText.Text = Convert.ToString(gameManager.LifesLeft--);
                            else if (gameManager.LifesLeft <= 0)
                                healthText.Text = "YOU LOST";

                        }
                    }

                }
            }
        }

        public void CheckWinLoose()
        {
            if (gameManager.LifesLeft == 0)
            {
                healthText.Text = "LOST";
            }
            else if (gameManager.LifesLeft > 0 && gameManager.EnemiesCounter == 1)
            {
                healthText.Text = "YOU WON";
            }
        }

        public void DestroyAll()
        {
            for (var i = 0; i < gameManager.enemies.Length; i++)
            {
                Canvas.SetLeft(gameManager.enemies[i], 5000);
                Canvas.SetTop(gameManager.enemies[i], 5000);

                canvas.Children.Remove(gameManager._playerSprite);
            }
        }

        public void StartNewGame()
        {
            StartTimer();
            InitializePlayer();
            InitializeEnemy();
            healthText.Text = Convert.ToString(gameManager.LifesLeft);
        }

        #region COMMAND BAR BUTTONS
        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (pause_play.Symbol.Equals(Symbol.Play))
            {
                pause_play.Symbol = Symbol.Pause;
                _timer.Start();
                isPaused = true;
                startNewButton.IsEnabled = true;
            }
            else if (pause_play.Symbol.Equals(Symbol.Pause))
            {
                pause_play.Symbol = Symbol.Play;
                _timer.Stop();
                isPaused = false;
                startNewButton.IsEnabled = false;
            }
        }

        private void startNewButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isPaused)
            {
                StartNewGame();
                startNewButton.Content = "RESTART";
            } else if (isPaused)
            {
                //DestroyAll();
                //StartNewGame();
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
        #endregion
    }
}
