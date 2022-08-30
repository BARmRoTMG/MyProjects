using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Father f = new Father();
            f.Action(37);
            Console.ReadLine();
        }
    }
}
