using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShayClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 10, 12, 3, 9, 7 , 2, 8};
            int[] b = { 7, 45, 33, 4, 23, 9, 1 };

            //BubbleSort(a);
            //SortK(a, 3);
            //MaxSort(a);
            InsertionSort(a);

            Console.WriteLine(f(a, b, 9));

            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + " ");
        }

        public static void BubbleSort(int[] a)
        {
            for (int i = a.Length - 1; i > 0; i--)
            {
                bool wasSwapped = false;
                for (int j = 0; j < a.Length - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        Swap(a, j, j + 1);
                        wasSwapped = true;
                    }
                }
                if (!wasSwapped)
                    break;
            }
        }

        public static void Swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        public static void SortK(int[] a, int k)
        {
            for (int i = a.Length - 1; i > a.Length - 1 - k; i--)
            {
                bool wasSwapped = false;
                for (int j = 0; j < i; j++)
                {
                    if (a[j] < a[j + 1])
                    {
                        Swap(a, j, j + 1);
                        wasSwapped = true;
                    }
                }
                if (!wasSwapped)
                    break;
            }

            for (int i = 0; i < k; i++)
            {
                Swap(a, i, a.Length - 1 - i);
            }
        }

        public static void MaxSort(int[] a)
        {
            for (int i = a.Length - 1; i > 0; i--)
            {
                int maxInd = 0;
                for (int j = 0; j <= i; j++)
                    if (a[j] > a[maxInd])
                        maxInd = j;
                Swap(a, i, maxInd);
            }
        }

        public static void InsertionSort(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                for (int j = i; j > 0; j--)
                    if (a[j] < a[j - 1])
                        Swap(a, j, j - 1);
                    else
                        break;
            }
        }

        public static int BinarySearch(int[] a, int x)
        {
            int top, bot, mid;
            top = a.Length - 1;
            bot = 0;

            while(top >= bot)
            {
                mid = (top + bot) / 2;

                if (x > a[mid])
                    bot = mid + 1;
                else if (x < a[mid])
                    top = mid - 1;
                else 
                    return mid;
            }
            return -1;
        }


        public static bool f(int[] a, int[] b, int num)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (BinarySearch(b, num - a[i]) != -1)
                    return true;
            }
            return false;
        }

        public static bool f2(int[] a, int[] b, int num)
        {
            int left , right;
            left = 0;
            right = b.Length - 1;

            while (left < right && right >= 0)
            {
                if (a[left] + b[right] > num)
                    right--;
                else if (a[left] + b[right] < num)
                    left++;
                else
                    return true;
            }

            return false;
        }

        public static bool SumOfPair(int[] a, int num)
        {
            int top, bot, mid;
            top = a.Length - 2;
            bot = 0;

            while (top >= bot)
            {
                mid = (top + bot) / 2;

                if (num > a[mid] + a[mid + 1])
                    bot = mid + 1;
                else if (num < a[mid] + a[mid + 1])
                    top = mid - 1;
                else
                    return true;
            }
            return false;
        }
    }
}

