using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Popups;


namespace DodgeGame
{
    internal class GameManager : Page
    {
        public Rectangle _playerSprite { get; set; }
        public Rectangle _enemySprite { get; set; }
        public Player player { get; set; }
        public Enemy[] enemiesArr { get; set; }

        public Rectangle[] enemies;
        public double _boardWidth, _boardHeight;

        public Random random = new Random();

        //Universal game settings
        public static int enemyNum = 10;
        public float MoveSpeed = 1f;
        private int _lifes = 3;
        private int _enemiesCounter = 0;

        //Alternative to file save (saving internaly with variables)
        public double playerLastX, playerLastY;
        public double[] enemyLastX = new double[enemyNum];
        public double[] enemyLastY = new double[enemyNum];

        public int LifesLeft
        {
            get { return _lifes; }
            set { _lifes = value; }
        }
        public int EnemiesCounter
        {
            get { return _enemiesCounter; }
            set { _enemiesCounter = value; }
        }


        public GameManager(double boardWidth, double boardHeight)
        { 
            _boardHeight = boardHeight;
            _boardWidth = boardWidth;

            player = new Player((int)_boardHeight, (int)_boardWidth);

            RandomizeEnemyLoc();
        }

        public void RandomizeEnemyLoc()
        {
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
