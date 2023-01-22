namespace FlightSimulator.Dal.Entities
{
    public class FlightQueues
    {
        public int Id { get; set; }
        public virtual ICollection<Flight>? Flights { get; set; }
    }
}
