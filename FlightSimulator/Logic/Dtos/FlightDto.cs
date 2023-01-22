using System;

namespace Logic.Dtos
{
    public class FlightDto
    {
        public string FlightId { get; set; }

        public string FlightCompany { get; set; }

        public TimeSpan TimeSpan { get; set; }

        public DateTime FlightTime { get; set; }
    }
}
