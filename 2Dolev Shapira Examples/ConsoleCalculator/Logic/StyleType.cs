using System;

namespace Logic
{
    public enum StyleType //: byte
    {
        Gold = 1,
        Silver = 2,
        Bronze = 3,
        Platinum
    }

    [Flags]
    public enum Months //: long
    {
        Jan = 1,
        Feb = 2,
        Mar = 4,
        Apr = 8,
        May = 16,
        June = 32,
        July = 64,
        August = 128,
        Sep = 256,
        Oct = 512,
        Nove = 1024,
        December = 2048,
    }

    class Abc
    {
        public bool A => C && B;
        public bool B => !C;
        public bool C { get; set; }

        public void Test()
        {
            //A = true;
            //B = true;
            C = true;

            if (A || (B && C))
                Console.WriteLine("OK");
            else
                Console.WriteLine("NOK");
        }
    }
}