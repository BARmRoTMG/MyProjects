using System;

namespace VendingMachine
{
    abstract class Cup
    {
        public abstract string Name { get; }
        public abstract double Price { get; set; }

        Size _size;
        public Size Size { get { return _size; } set { _size = value; } }

        public Cup(Size size)
        {
            _size = size;
        }
        public abstract void Prepare();
        public override sealed string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return $"Here's your {Name}, your bill is {Price} USD.";
        }
    }
}
