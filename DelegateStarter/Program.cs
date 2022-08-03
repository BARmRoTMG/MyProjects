using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateEmployees
{
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public Customer(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }
        public override string ToString()
        {
            return $"Customer Name: {Name}, Balance: {Balance}";
        }
    }

    public class ParameterTest
    {
        public static void IncDouble(double a)
        {
            a = a + 1;
        }
        public static void IncDouble(ref double a)
        {
            a = a + 1;
        }
        public static void IncBalance(Customer cust)
        {
            cust.Balance = cust.Balance + 1;
        }
        public static void ChangeString(string s)
        {
            if (s != null)
                s.ToUpper();
        }
        public static void ChangeString(ref string s)
        {
            if (s != null)
                s.ToUpper();
        }
        public static void ChangeName(Customer cust)
        {
            if (cust.Name != null)
                cust.Name.ToUpper();
        }
        public static void ChangeLower(string s)
        {
            if (s != null)
                s = s.ToLower();
        }
        public static void ChangeLower(ref string s)
        {
            if (s != null)
                s = s.ToLower();
        }


        public static void ChangeNameToLower(Customer cust)
        {
            if (cust.Name != null)
                cust.Name = cust.Name.ToLower();
        }
        public static void ChangeNameToLower(ref Customer cust)
        {
            if (cust.Name != null)
                cust.Name = cust.Name.ToLower();
        }
        public static void ChangeCustomer(Customer cust)
        {
            cust = new Customer(cust.Name, cust.Balance + 20);
        }
        public static void ChangeCustomer(ref Customer cust)
        {
            cust = new Customer(cust.Name, cust.Balance + 20);
        }
    }

    public delegate T operate<T>(T val1, T val2);

    class Program
    {

        public static int add(int a, int b)
        {
            Console.WriteLine("in int version of add method");
            return a + b;
        }

        public static string add(string a, string b)
        {
            Console.WriteLine("in string version of add");
            return a + " " + b;
        }

        public static int sub(int a, int b)
        {
            Console.WriteLine("In Sub of int ");
            return (a - b);
        }

        static void Main(string[] args)
        {
            operate<int> op = Program.sub;
            Console.WriteLine(op.Invoke(1, 2));
            op += Program.add;
            Console.WriteLine(op.Invoke(3, 4));

            operate<string> op2 = Program.add;
            Console.WriteLine(op2.Invoke("hi", "bye"));
        }

    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //EmployeeManager manager = new EmployeeManager();
    //        //manager.Add(new Employee() { Name = "Shlomo", Salary = 7000 });
    //        //manager.Add(new Employee() { Name = "Noam", Salary = 17000 });
    //        //manager.Add(new Employee() { Name = "Yossi", Salary = 5000 });
    //        //manager.Add(new Employee() { Name = "Tomer", Salary = 2000 });

    //        //manager.Print();

    //        string s4 = "HI";
    //        ParameterTest.ChangeLower(ref s4);
    //        Console.WriteLine(s4);
    //    }
    //}

    //public class Employee
    //{
    //    public string Name { get; set; }
    //    public float Salary { get; set; }

    //    public override string ToString()
    //    {
    //        return string.Format("Name {0}, Salary {1}", Name, Salary);
    //    }
    //}

    //public class EmployeeManager
    //{
    //    private List<Employee> _employees = new List<Employee>();

    //    public void Add(Employee emp)
    //    {
    //        _employees.Add(emp);
    //    }

    //    public void Print()
    //    {
    //        foreach (var item in _employees)
    //        {
    //            Console.WriteLine(item);
    //        }
    //    }

//#if test
//        // show how one can sort elements using simple non efficient sort
//        public void SortByName()
//        {
//            for (int i = 0; i < _employees.Count; i++)
//            {
//                for (int j = 0; j < _employees.Count - 1; j++)
//                {
//                    if (_employees[j].Name.CompareTo(_employees[j + 1].Name) == 1)
//                    {
//                        var tmp = _employees[j];
//                        _employees[j] = _employees[j + 1];
//                        _employees[j + 1] = tmp;
//                    }
//                }
//            }
//        }
//#endif
  //  }
}
