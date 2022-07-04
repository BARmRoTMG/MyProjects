using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOriented
{
    class Student : Person
    {
        private enum EducationYears { Freshman, Sophemore, Junior, Senior};
        public int Degree { get; set; }

        public Student(string name, int educationYears) : base(name)
        {
            Degree = educationYears;
        }
    }
}
