using System;

namespace CalcTest
{
    internal class Support
    {
        public const double PI = 3.14;
        public string Code { get; set; }

        public Support()
        {
            Code = Guid.NewGuid().ToString();
        }
    }
}
