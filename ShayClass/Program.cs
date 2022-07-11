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
            //int[] a = { 1, 3, 4, 6, 8 , 9 };
            //int[] b = { 2, 4, 7, 10, 12 };
            //int[] c = new int[a.Length + b.Length];

            ////BubbleSort(a);
            ////SortK(a, 3);
            ////MaxSort(a);
            ////InsertionSort(a);
            ////Merge(a, b, c);
            //MergeSort(a, 9, 5);


            //Console.WriteLine(f(a, b, 9));

            int[] arr = { 1, 2, 3, 4, 6, 3, 5, 7, 8 };
            MergeSort(arr, 0, arr.Length - 1);

            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
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




        // 11/07/2022

        public static void Merge(int[] a, int[] b, int[] c)
        {
            int i, j, k;
            i = j = k = 0;

            while (i < a.Length && i < b.Length)
            {
                if (a[i] < b[j])
                {
                    c[k] = a[i];
                    i++;
                } else
                {
                    c[k] = b[j];
                    j++;
                }
                k++;
            }

            int[] temp;
            int index;

            if (i == a.Length)
            {
                temp = b;
                index = j;
            } else
            {
                temp = a;
                index = i;
            }

            for (; index < a.Length; index++)
                c[k] = temp[index];
        }

        public static void MergeSort(int[] a, int begin, int end)
        {
            if (begin >= end)
                return;

            MergeSort(a, begin, (begin + end) / 2);
            MergeSort(a, 1 + (begin + end) / 2, end);
            Merge(a, begin, end);
        }

        public static void Merge(int[] a, int begin, int end)
        {
            int[] b = new int[(end - begin) + 1];
            int mid = 1 + (begin + end) / 2;
            int i, k;
            i = begin;
            k = 0;

            while(i < 1 + (begin + end) / 2 && mid <= end)
            {
                if (a[i] < a[mid])
                {
                    b[k] = a[i];
                    i++;
                } else
                {
                    b[k] = a[mid];
                    mid++;
                }
                k++;
            }

            if (i == 1 + (begin + end) / 2)
                for (; mid <= end; mid++, k++)
                    b[k] = a[mid];
            else
                for (; i < 1 + (begin + end) / 2; i++, k++)
                    b[k] = a[i];
            for (i = begin, k = 0; k < b.Length; i++, k++)
                a[i] = b[k];
        }
    }
}

