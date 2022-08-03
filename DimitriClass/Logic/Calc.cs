using System;

namespace Logic
{
    public class Calc
    {
        public double GetSquareRoot(string numStr)
        {
            if (!double.TryParse(numStr, out double num))
                throw new Exception("Format Error");

            if (num < 0)
                throw new Exception("Minus Error");

            return (int)Math.Sqrt(num);
        }
    }
}
