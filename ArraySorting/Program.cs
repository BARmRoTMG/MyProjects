using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Bubble sorting
            int _temp;
            int[] arr = { 60, 27, 3, 87, 62 ,22};
            string[] stri = new string[5];

            //for (int i = (arr.Length - 1); i >= 0; i--)
            //{
            //    for (int j = 1; j <= i; j++)
            //    {
            //        if (arr[j - 1] > arr[j])
            //        {
            //            _temp = arr[j -1];
            //            arr[j -1] = arr[j];
            //            arr[j] = _temp;
            //        }
            //    }
            //}

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}

            for (int i = 0; i < stri.Length; i++)
            {
                Console.WriteLine(stri[i]);
            }
            Console.ReadLine();
        }
    }
}
