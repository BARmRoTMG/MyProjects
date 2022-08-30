using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3.Model
{
    public class Base
    {
        public int Age { get; set; }
        public string Color { get; set; }

        public Base(int age, string color)
        {
            Age = age;
            Color = color;
        }
    }
}
