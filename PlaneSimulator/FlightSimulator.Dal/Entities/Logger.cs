using System.ComponentModel.DataAnnotations;

namespace FlightSimulator.Dal.Entities
{
    public class Logger
    {
        public int Id { get; set; }

        [Required]
        public Flight Flight { get; set; }
        public Terminal? Terminal { get; set; }

        [Required]
        public DateTime In { get; set; }
        public DateTime? Out { get; set; }
    }
}
