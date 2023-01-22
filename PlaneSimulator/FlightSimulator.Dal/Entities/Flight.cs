using FlightSimulator.Data.Context;
using System.ComponentModel.DataAnnotations;

namespace FlightSimulator.Dal.Entities
{
    public class Flight
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string SerialNumber { get; set; } = Guid.NewGuid().ToString();
        public BrandType Brand { get; set; }
        public int PassangerCount { get; set; }
        public bool IsLanding { get; set; } = true;

        
        public virtual Terminal Terminal { get; set; }
        public void NextTerminal(DataContext data)
        {
            Terminal.IsFree = true;
            Terminal.NextTerminal(this, data);
        }
    }

    public enum BrandType
    {
        ElAl,
        Arkia,
        Israir,
        EasyJet
    }
}
