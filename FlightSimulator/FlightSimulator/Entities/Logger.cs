using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSimulator.Entities
{
    [Table("Logger")]
    public class Logger
    {
        [Key]
        public int Id { get; set; }

        public virtual Terminal? Terminal { get; set; }

        [Required]
        public virtual Flight Flight { get; set; }

        [Required]
        public DateTime EnterToTerminal { get; set; }

        public DateTime? ExitFromTerminal { get; set; }
    }
}
