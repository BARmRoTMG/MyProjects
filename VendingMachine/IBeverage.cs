using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface IBeverage
    {
        string Name { get; set; }

        void Prepare(); 
    }
}
