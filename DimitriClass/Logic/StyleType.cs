using System;

namespace Logic
{
    public enum StyleType
    {
        Platinum = 1,
        Gold,
        Silver,
        Bronze
    }

    [Flags]

    public enum Months : long
    {
        Jan = 1,
        Feb = 2,
        Mar = 4,
        Apr = 8,
        May = 16,
        June = 0x10000,
        July,
        August,
        Sep,
        Oct,
        Nove,
        December
    }
}
