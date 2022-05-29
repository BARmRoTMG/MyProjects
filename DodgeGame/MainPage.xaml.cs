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
        Rectangle _playerSprite;
        Rectangle _enemySprite;
        Rectangle[] enemies;
        DispatcherTimer _timer;


        //SETTINGS FIELDS
        private bool gameRunning = false;
        private bool isIdle;
        
        public MainPage()
        {
            this.InitializeComponent();
            InitializeScreen();
            //gameManager.StartGameMessage();        
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
            _playerSprite = new Rectangle();
            _playerSprite.Width = 90;
            _playerSprite.Height = 70;
            _playerSprite.Fill = new ImageBrush { ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Player.png")) };
            Canvas.SetTop(_playerSprite, 400);
            Canvas.SetLeft(_playerSprite, 450);
            canvas.Children.Add(_playerSprite);
        }

        public void InitializeEnemy()
        {
            //Spawn Enemy
            enemies = new Rectangle[10];
            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy currentEnemy = gameManager.enemiesArr[i];
                enemies[i] = AddSprite(currentEnemy);
            }
        }

        //USER INPUT
        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs e)
        {          
            switch (e.VirtualKey)
            {
                case VirtualKey.W:
                    Canvas.SetTop(_playerSprite, Canvas.GetTop(_playerSprite) - 10);
                    gameManager.player.X = (int)Canvas.GetTop(_playerSprite) - 10;
                    break;
                case VirtualKey.S:
                    Canvas.SetTop(_playerSprite, Canvas.GetTop(_playerSprite) + 10);
                    gameManager.player.X = (int)Canvas.GetTop(_playerSprite) + 10;
                    break;
                case VirtualKey.A:
                    Canvas.SetLeft(_playerSprite, Canvas.GetLeft(_playerSprite) - 10);
                    gameManager.player.Y = (int)Canvas.GetLeft(_playerSprite) - 10;
                    break;
                case VirtualKey.D:
                    Canvas.SetLeft(_playerSprite, Canvas.GetLeft(_playerSprite) + 10);
                    gameManager.player.Y = (int)Canvas.GetLeft(_playerSprite) + 10;
                    break;
                default:
                    isIdle = true;
                    break;
            }
        }

        public Rectangle AddSprite(PlayerController playerController)
        {
            _enemySprite = new Rectangle();
            _enemySprite.Fill = new ImageBrush { ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/scorpion.png")) };

            _enemySprite.Width = playerController.Width;
            _enemySprite.Height = playerController.Height;

            Canvas.SetLeft(_enemySprite, playerController.X);
            Canvas.SetTop(_enemySprite, playerController.Y);

            canvas.Children.Add(_enemySprite);

            return _enemySprite;
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
            CheckBounds();
            Collision();
        }
        public void EnemyMove()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (Canvas.GetTop(_playerSprite) < Canvas.GetTop(enemies[i]))
                    Canvas.SetTop(enemies[i], Canvas.GetTop(enemies[i]) -1);
                else if (Canvas.GetTop(_playerSprite) > Canvas.GetTop(enemies[i]))
                    Canvas.SetTop(enemies[i], Canvas.GetTop(enemies[i]) + 1);

                if (Canvas.GetLeft(_playerSprite) < Canvas.GetLeft(enemies[i]))
                    Canvas.SetLeft(enemies[i], Canvas.GetLeft(enemies[i]) - 1);
                else if (Canvas.GetLeft(_playerSprite) > Canvas.GetLeft(enemies[i]))
                    Canvas.SetLeft(enemies[i], Canvas.GetLeft(enemies[i]) + 1);
            }
        }
        public void CheckBounds()
        {
            //Player bounds
            if (Canvas.GetLeft(_playerSprite) > Window.Current.Bounds.Width)
                Canvas.SetLeft(_playerSprite, -30);
            else if (Canvas.GetLeft(_playerSprite) < -50)
                Canvas.SetLeft(_playerSprite, Window.Current.Bounds.Width);
            else if (Canvas.GetTop(_playerSprite) > Window.Current.Bounds.Height)
                Canvas.SetTop(_playerSprite, 0);
            else if (Canvas.GetTop(_playerSprite) < -50)
                Canvas.SetTop(_playerSprite, Window.Current.Bounds.Height);

            //Enemy bounds
            if (Canvas.GetLeft(_enemySprite) > Window.Current.Bounds.Width)
                Canvas.SetLeft(_enemySprite, -30);
            else if (Canvas.GetLeft(_enemySprite) < -50)
                Canvas.SetLeft(_enemySprite, Window.Current.Bounds.Width);
            else if (Canvas.GetTop(_enemySprite) > Window.Current.Bounds.Height)
                Canvas.SetTop(_enemySprite, 0);
            else if (Canvas.GetTop(_enemySprite) < -50)
                Canvas.SetTop(_enemySprite, Window.Current.Bounds.Height);
        }

        public void Collision()
        {
            for (int i = 0; i < gameManager.enemiesArr.Length; i++)
            {
                for (int j = 1; j < gameManager.enemiesArr.Length; j++)
                {
                    if (gameManager.enemiesArr[i].Y == gameManager.enemiesArr[j].Y && gameManager.enemiesArr[i].X == gameManager.enemiesArr[j].X)
                        healthText.Text = "CONTACT";
                }
            }
        }

        public void DestroyAll()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                canvas.Children.Remove(enemies[i]);
            }
        }

        #region COMMAND BAR BUTTONS
        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (pause_play.Symbol.Equals(Symbol.Play))
            {
                pause_play.Symbol = Symbol.Pause;
                _timer.Start();
                gameRunning = true;
            }
            else if (pause_play.Symbol.Equals(Symbol.Pause))
            {
                pause_play.Symbol = Symbol.Play;
                _timer.Stop();
                gameRunning = false;
            }
        }

        private void startNewButton_Click(object sender, RoutedEventArgs e)
        {
            StartTimer();
            InitializePlayer();
            InitializeEnemy();
            //if (!gameRunning)
            //{
            //    InitializeEnemy();
            //    gameRunning = true;
            //} else
            //{
            //    DestroyAll();
            //    InitializeEnemy();
            //    gameRunning = false;
            //}
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e) // Easy B
        {
            //playerController.moveSpeed = 1;
        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e) // Normal B
        {
            //playerController.moveSpeed = 3;
        }

        private void MenuFlyoutItem_Click_2(object sender, RoutedEventArgs e) // HARD B
        {
            //playerController.moveSpeed = 6;
        }
        #endregion
    }
}
