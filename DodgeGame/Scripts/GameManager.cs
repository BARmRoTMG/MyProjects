using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DodgeGame.Scripts;
using Windows.UI.Popups;
using Windows.UI.Xaml;


namespace DodgeGame
{
    internal class GameManager
    {
        //Collision
        //Game win / loose conditions

        public Player player { get; set; }
        public Enemy[] enemiesArr { get; set; }

        public double _boardWidth, _boardHeight;
        Random random = new Random();

        public GameManager(double boardWidth, double boardHeight)
        { 
            _boardHeight = boardHeight;
            _boardWidth = boardWidth;

            player = new Player((int)_boardHeight, (int)_boardWidth);
            enemiesArr = new Enemy[10];
            for (int i = 0; i < 10; i++)
            {
                enemiesArr[i] = new Enemy(random.Next(30, (int)_boardWidth - 30), random.Next(30, (int)_boardHeight - 30));
            }
        }

        //NEW GAME
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
