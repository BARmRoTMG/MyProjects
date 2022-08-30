using System;

namespace Logic
{
    public class Calc
    {
        public double GetRootSquare(string numStr)
        {
            //var num = double.Parse(numStr);
            if (!double.TryParse(numStr, out double num))
                throw new Exception("Format Error");

            if (num < 0)
                throw new Exception("Minus Error");

            return Math.Sqrt(num);
            //return (int)Math.Sqrt(num);
            //return 0.5;
        }

        private void Test()
        {
            var st1 = StyleType.Gold;
            var st2 = (StyleType)3;
            var st3 = StyleType.Gold | StyleType.Silver;
            //if (st2 == st3)
            //    throw new Exception("Wrong");

            var mon1 = Months.Sep;
            var mon2 = Months.Jan | Months.Feb;
            var mon3 = Months.Mar;
            var mon4 = Months.Apr | Months.May | Months.August | Months.Oct;
            var mon5 = (Months)67;

            if (mon5.HasFlag(Months.May))
                throw new Exception("Wrong");

            mon4 |= Months.Jan;
            mon4 -= Months.August;
        }
    }
}