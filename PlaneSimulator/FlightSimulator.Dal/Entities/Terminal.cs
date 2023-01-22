using FlightSimulator.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FlightSimulator.Dal.Entities
{
    public class Terminal
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public double WaitTime { get; set; }
        public Flight? Flight { get; set; }
        public bool IsFree { get; set; } = true;
        public virtual void NextTerminal(Flight currentFlight, DataContext data) { }
    }
}
