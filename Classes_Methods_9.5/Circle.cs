using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Methods_9._5
{
    public class Circle
    {
        public double _radius;
        public string _color;
        public string _name;

        public Circle(string Name, string Color, double Radius)
        {
            _name = Name;
            _radius = Radius;
            _color = Color;
        }

        public void Description()
        {
            Console.WriteLine($"The Circle {_name} is {_color} nad the size of it is " + Math.Pow(_radius, 2));
        }
    }
}
