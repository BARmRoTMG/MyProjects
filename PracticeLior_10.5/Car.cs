using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLior_10._5
{
    public class Car
    {
        //fields
        public int _wheels;
        public string _carType;
        public string wheelType;
        public int _fuel;

        public Car(string carType, int wheels, int fuel)
        {
            _carType = carType;
            _wheels = wheels;
            _fuel = fuel;
        }

        public void startEngine()
        {
            Console.WriteLine("Engine started!");
        }

        public void pitStop()
        {           
            wheelType = "Soft Tires";
        }
    }
}
