using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSimulator.Entities
{
    [Table("Logger")]
    public class Logger
    {
        public int Id { get; set; }

        //public virtual Terminal? Terminal { get; set; }
        public string? CurrentTerminal { get; set; }

        [Required]
        //public virtual Flight Flight { get; set; }
        public string FlightNumber { get; set; }

        [Required]
        public DateTime EnterToTerminal { get; set; }

        public DateTime? ExitFromTerminal { get; set; }
    }
}
