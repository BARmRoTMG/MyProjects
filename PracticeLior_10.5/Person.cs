using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLior_10._5
{
    public class Person
    {
        //fields
        public string _name;
        public int _age;
        public int _socialSecurityNumber;
        public string _job;
        public double _height;
        public double _weight;
        double _bmi;

        public Person(string Name, int Age, int SocialSecurityNumber, string Job, double Height, double Weight)
        {
            _name = Name;
            _age = Age; 
            _socialSecurityNumber = SocialSecurityNumber;
            _job = Job;
            _height = Height;
            _weight = Weight;
        }

        public void Description()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{_name},\n{_age} years old,\nSocial security number: {_socialSecurityNumber}\nWorks at {_job},\nEstimated BMI: {_bmi}");
        }

        public void CalculateBMI()
        {
            _bmi = _weight / (Math.Pow(_height, 2));
        }

        public string ChangeJob()
        {
            Console.Write("What is your new job? ");
            _job = Console.ReadLine();
            return _job;
        }
    }
}
