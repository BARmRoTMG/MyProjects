using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3.Model
{
    public class Child : Base
    {
        public string Name { get; set; }

        public Child(string name) : base(37, "red")
        {
            Name = name;
        }
    }
}
