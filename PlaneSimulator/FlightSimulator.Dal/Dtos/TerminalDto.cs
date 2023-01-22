using FlightSimulator.Dal.Entities;

namespace FlightControl.Dal.Dtos
{
    public class TerminalDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public double WaitTime { get; set; }
        public Flight? Flight { get; set; }
    }
}