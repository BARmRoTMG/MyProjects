using FlightSimulator.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSimulator.Entities
{
    [Table("Flights")]
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        public string FlightNumber { get; set; }

        public string FlightCompany { get; set; }

        public DateTime FlightTime { get; set; }

        public FlightType Type { get; set; }
        
        public FlightStatus? Status { get; set; }

        public virtual Terminal? CurrentTerminal { get; set; }

        [Column("CurrentTerminalId")]
        public int? CurrentTerminalId { get; set; }

        public int PassengersCount { get; set; }
    }
}
