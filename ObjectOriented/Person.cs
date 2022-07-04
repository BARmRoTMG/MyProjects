using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOriented
{
    internal class Person
    {
        private string _name;
        private int _age;

        private const int STARTER_ID = 100000000;
        private readonly int _id;
        private static int _counter;

        public static int Counter
        {
            get { return _counter; }
            private set { _counter = value; }
        }


        public Person(string name, int age)
        {
            _name = name;
            _age = age;
            _counter++;
            _id = STARTER_ID + _counter;
        }

        public Person(string name) : this(name, 30)
        {
        }

        public override string ToString()
        {
            return $"Name: {_name}, Age: {_age}, ID: {_id}";
        }

        public override bool Equals(object obj)
        {           
            //if (obj.GetType() != typeof(Person))
            //    return false;

            if (!(obj is Person))
                return false;

            //Down cast
            Person temp = (Person)obj;

            return _name.Equals(temp._name);
        }
    }
}
