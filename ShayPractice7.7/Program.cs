using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShayPractice7._7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(M1(4));
            Console.WriteLine(allEven(216));
            Console.WriteLine(fibo(100));

            Console.ReadKey();
        }

        public static bool allEven(int n)
        {
            if (n == 0)
                return true;
            if ((n % 10) % 2 == 1)
                return false;
            else
                return allEven(n / 10);
        }

        public static int M1(int n)
        {
            if (n == 1)
                return 3;
            else
                return (3 * n + M1(n-1));
        }
        public static bool areEqual(int[] a, int[] b)
        {
            if (a.Length != b.Length)
                return false;

            return areEqual(a, b, 0);
        }

        private static bool areEqual(int[] a, int[] b, int i)
        {
            if (i == a.Length)
                return true;

            if (a[i] != b[i])
                return false;

            return areEqual(a, b, i + 1);
        }

        public static int fibo(int n)
        {
            if (n <= 0)
                return n;
            return fibo(n - 1) + (n - 2);
        }

        public static int minOp(int x, int y)
        {
            if (x == y)
                return 0;
            if (x > y)
                return -1;

            int plus1 = minOp(x + 1, y) + 1;
            int mult2 = minOp(x * 2, y) + 1;

            if (plus1 > mult2 || mult2 == 0)
                return plus1;
            return mult2;
        }
    }
}
