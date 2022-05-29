using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DodgeGame.Scripts;
using Windows.UI.Xaml.Controls;


namespace DodgeGame
{
    internal class Enemy : PlayerController
    {
        //Enemy fields
        GameManager gameManager;
        public Enemy(int x, int y) : base(x, y, 60, 60)
        {
        }
    }
}
