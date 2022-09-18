using System;

namespace ConsoleStackHeap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 9;   //original

            //c1 = 0x222 (Stack)
            //value = 0x333 (Heap)
            var c1 = new Customer { Name = "First" };

            IncreaseNumber(num1);
            Console.WriteLine(num1);    //print original

            IncreaseNumber(ref num1);
            Console.WriteLine(num1);    //print original

            UpdateName(c1);
            Console.WriteLine(c1.Name); //print original (0x333)

            UpdateName(ref c1);
            Console.WriteLine(c1.Name);

            UpdateName(c1.Name);
            Console.WriteLine(c1.Name);

            string str = "ok";
            UpdateName(ref str);
            Console.WriteLine(str);

            UpdateName(ref c1.Family);
            Console.WriteLine(c1.Family);

            //IncreaseNumber(ref c1.Age);
            //Console.WriteLine(c1.Age);

            //UpdateName(ref c1.Name);
            //Console.WriteLine(c1.Name);

            //Console.WriteLine(c1.Name);
            //c1 = null;

            //for (int i = 0; i < 1e9; i++)
            //{
            //    Console.WriteLine("OK");
            //}
        }

        //copy of value = 9
        static void IncreaseNumber(int i) => i++;   //update copy to 10

        //copy of ref = 9
        static void IncreaseNumber(ref int i) => i++; //update original to 10

        //copy of value = 0x333
        static void UpdateName(Customer c)
        {
            c = new Customer(); //new = 0x444 (update value)
            c.Name = "Updated"; //0x444.Name 
        }

        //copy of ref = 0x222
        static void UpdateName(ref Customer c)
        {
            c = new Customer(); //new = 0x555 (update ref)
            c.Name = "Updated"; //0x555.Name
        }

        static void UpdateName(string name) => name = "Changed";
        static void UpdateName(ref string name) => name = "Changed";
    }

    class Customer
    {
        public int Age { get; set; }

        private string name;  //0x888
        public string Name { get => name; set => name = value; }

        public string Family; //0x777        
    }
}
 