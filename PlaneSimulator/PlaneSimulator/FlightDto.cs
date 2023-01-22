namespace FlightControl.Dal.Dtos
{
    public class FlightDto
    {
        public int Number { get; set; }
        public BrandTypeDto Brand { get; set; }
        public int PassangerCount { get; set; }

        static int number;
        public FlightDto() => Number = ++number;
    }

    public enum BrandTypeDto
    {
        ElAl,
        Arkia,
        Israir,
        EasyJet,
        BritishAirLines
    }
}
