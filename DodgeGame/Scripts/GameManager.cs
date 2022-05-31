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
using Windows.UI.Popups;


namespace DodgeGame
{
    internal class GameManager : Page
    {
        public Rectangle _playerSprite;
        public Rectangle _enemySprite;
        public Rectangle[] enemies;

        public Player player { get; set; }
        public Enemy[] enemiesArr { get; set; }

        public double _boardWidth, _boardHeight;

        Random random = new Random();

        //Universal game settings
        private static int enemyNum = 10;
        public float MoveSpeed = 1f;
        private int _lifes = 3;
        private int enemiesCounter = enemyNum;
        public int LifesLeft
        {
            get { return _lifes; }
            set { _lifes = value; }
        }
        public int EnemiesCounter
        {
            get { return enemiesCounter; }
            set { enemiesCounter = value; }
        }


        public GameManager(double boardWidth, double boardHeight)
        { 
            _boardHeight = boardHeight;
            _boardWidth = boardWidth;

            player = new Player((int)_boardHeight, (int)_boardWidth);

            enemiesArr = new Enemy[enemyNum]; // Enemies array
            for (int i = 0; i < 10; i++)
            {
                enemiesArr[i] = new Enemy(random.Next(30, (int)_boardWidth - 30), random.Next(30, (int)_boardHeight - 30));
            }          
        }

        public async void StartGameMessage()
        {
            MessageDialog msg = new MessageDialog("WELCOME TO THE GAME!");
            msg.Title = "Dodge Game - Made by Bar Mashiach";
            UICommand okBtn = new UICommand("Start");
            msg.Commands.Add(okBtn);
            await msg.ShowAsync();
        }
    }
}
