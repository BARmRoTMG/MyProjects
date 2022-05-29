using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DodgeGame.Scripts;

namespace DodgeGame
{
    internal class Player : PlayerController
    {
        //Player fields
        private int _lifes;
        public int LifesLeft
        {
            get { return _lifes; }
            set { _lifes = value; }
        }

        public Player(int x, int y) : base (x, y, 50, 50)
        {

        }
    }
}
