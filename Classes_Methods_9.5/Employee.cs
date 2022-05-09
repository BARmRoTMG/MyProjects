using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Methods_9._5
{
    public class Employee
    {
        public double _hourlySalary;
        public double _totalHours;
        public double calculateSalary()
        {
            return _hourlySalary * _totalHours;
        }
    }
}
