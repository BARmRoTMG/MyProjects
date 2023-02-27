using System;

namespace ConsoleDelegateEvent
{
    class MyClass
    {
        internal Action MyPrintAction { get; set; } 

        
        internal event Action MyPrintEvent;         //default address = NULL
        internal void RunEvent() => MyPrintEvent?.Invoke(); //if (MyPrintEvent != null) MyPrintEvent();


        internal event Func<int> MyFuncEvent;
        internal event Func<int, string> MyFuncMsgEvent;
        internal int? RunFuncEvent() => MyFuncEvent?.Invoke();
        internal string RunFuncMsgEvent() { return MyFuncMsgEvent?.Invoke(123); }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //SimpleExamples();

            //ActionAsEvent();

            ComplexExaples();
        }

        private static void ComplexExaples()
        {
            MyClass myClass = new MyClass();

            //myClass.MyPrintAction = Print;
            //myClass.MyPrintAction += () => Print("Added");
            //myClass.MyPrintAction += () => Print("Continue: ", 12);
            //myClass.MyPrintAction = Print;

            //myClass.MyPrintAction();

            myClass.MyPrintEvent += Print;
            myClass.MyPrintEvent += () => Print("Added");
            myClass.MyPrintEvent += () => Print("Continue: ", 12);
            myClass.MyPrintEvent += Print;

            myClass.RunEvent();
        }

        private static void ActionAsEvent()
        {
            Action act1 = Print;
            act1 += () => Print("Added");
            act1 += () => Print("Continue: ", 12);
            act1 = Print;

            act1();

            int i = 10;
            i += 12;
            i += 33;
            i = 11;
            Console.WriteLine(i);
        }

        private static void SimpleExamples()
        {
            //Print();    //call or invoke 0x111

            Action act1 = Print;            //act1 = 0x111
            act1();     //call or invoke 0x111

            Action<string> act2 = Print;    //act2 = 0x222
            act2("Good");

            Action<string, int> act3 = Print;
            act3("Num: ", 13);

            Func<int> func1 = GetNumber;    //func1 = 0x444
            var res1 = func1();             //call or invoke 0x444      
            Console.WriteLine(res1);

            Func<string, int> func2 = GetNumber;    //func2 = 0x555
            //var res2 = GetNumber("33");
            var res2 = func2("33");         //call or invoke 0x555      
            Console.WriteLine(res2);
        }

        //0x111
        static void Print() => Console.WriteLine("OK");

        //0x222
        static void Print(string msg) => Console.WriteLine(msg);

        //0x333
        static void Print(string msg, int i) => Console.WriteLine(msg + i);

        //0x444
        static int GetNumber() => 12;

        //0x555
        static int GetNumber(string num) => int.Parse(num);
    }
}
