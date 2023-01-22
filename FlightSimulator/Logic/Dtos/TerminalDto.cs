using FlightSimulator.Entities;
using FlightSimulator.Enums;
using System;

namespace Logic.Dtos
{
    public class TerminalDto
    {
        public int TerminalNumber { get; set; }
        public Flight Plane { get; set; }
    }
}
