using FlightSimulator.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace FlightSimulator.Entities
{
    [Table("Terminals")]
    public abstract class Terminal
    {
        [Key]
        public int Id { get; set; }
        public int TerminalNumber { get; set; }
        public bool IsFree { get; set; } = true;
        public int WaitTime { get; set; }
        public abstract void NextTerminal(Flight flight);
    }

    public class Terminal_2 : Terminal
    {
        private Terminal_2() { TerminalNumber = 2; WaitTime = 2; }
        public static Terminal Init { get; } = new Terminal_2();
        public override void NextTerminal(Flight flight)
        {
            IsFree = true;
            flight.CurrentTerminal = Terminal_3.Init;
            flight.CurrentTerminal.IsFree = false;
        }
    }

    public class Terminal_3 : Terminal
    {
        private Terminal_3() { TerminalNumber = 3; WaitTime = 4; }
        public static Terminal Init { get; } = new Terminal_3();
        public override void NextTerminal(Flight flight)
        {
            IsFree = true;
            flight.CurrentTerminal = Terminal_4.Init;
            flight.CurrentTerminal.IsFree = false;
        }
    }

    public class Terminal_4 : Terminal
    {
        private Terminal_4() { TerminalNumber = 4; WaitTime = 6; }
        public static Terminal Init { get; } = new Terminal_4();
        public override void NextTerminal(Flight flight)
        {
            IsFree = true;

            if (flight.Type == FlightType.Departure)
            {
                flight.Status = FlightStatus.Past;
                flight.CurrentTerminal = null;
            }
            else
            {
                flight.CurrentTerminal = Terminal_5.Init;
                flight.CurrentTerminal.IsFree = false;
            }
        }
    }

    public class Terminal_5 : Terminal
    {
        private Terminal_5() { TerminalNumber = 5; WaitTime = 2; }
        public static Terminal Init { get; } = new Terminal_5();
        public override void NextTerminal(Flight flight)
        {
            IsFree = true;
            flight.CurrentTerminal = Terminal_6.Init;
            flight.CurrentTerminal.IsFree = false;
        }
    }

    public class Terminal_6 : Terminal
    {
        private Terminal_6() { TerminalNumber = 6; WaitTime = 2; }
        public static Terminal Init { get; } = new Terminal_6();
        public override void NextTerminal(Flight flight)
        {
            IsFree = true;
            flight.CurrentTerminal = Terminal_7.Init;
            flight.CurrentTerminal.IsFree = false;
        }
    }

    public class Terminal_7 : Terminal
    {
        private Terminal_7() { TerminalNumber = 7; WaitTime = 2; }
        public static Terminal Init { get; } = new Terminal_7();
        public override void NextTerminal(Flight flight)
        {
            IsFree = true;
            flight.CurrentTerminal = Terminal_8.Init;
            flight.CurrentTerminal.IsFree = false;
        }
    }

    public class Terminal_8 : Terminal
    {
        private Terminal_8() { TerminalNumber = 8; WaitTime = 2; }
        public static Terminal Init { get; } = new Terminal_8();
        public override void NextTerminal(Flight flight)
        {
            IsFree = true;
            flight.CurrentTerminal = Terminal_4.Init;
            flight.CurrentTerminal.IsFree = false;
            flight.Type = FlightType.Departure;
        }
    }
}
