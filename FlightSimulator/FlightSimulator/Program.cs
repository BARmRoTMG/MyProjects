using FlightSimulator.Context;
using FlightSimulator.Entities;
using FlightSimulator.Entities.Extentions;
using FlightSimulator.Enums;
using System.Net.Http.Json;
using System.Text;
using t = System.Timers;

namespace FlightSimulator
{
    class Program
    {
        private static HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7066") };
        private static readonly DataContext _context = new DataContext();

        static t.Timer _timer = new t.Timer(1000);
        private readonly static Random _rnd = new Random();
        private static DateTime _minDateTime;
        private static double _spaceBetweenFlight = 5;
        private static string[] _flightCompanies = new string[]
        {
            "ISRAIR AIRLINES", "EL AL ISRAEL AIRLINES",
            "FLYDUBAI", "EMIRATES AIRWAYS",
            "ARKIA ISRAELI AIRLINES", "AIR FRANCE"
        };

        static void Main(string[] args)
        {
            SetTerminals();

            while (true)
            {
                FlightCreatorLoop();
                Running();
            }
        }

        private static void Running()
        {
            var flight = GetFlightFromAir();    //from here start U web API [HttpPost]
            foreach (var f in flight)
            {
                if (flight != null)
                {
                    FromAirToTerminal2(flight);
                    _timer.Elapsed += (s, e) => GoNextTerminal(f);
                    UpdateInterval(f);
                    _timer.Start();
                }
            }
        }

        private static void FlightCreatorLoop()
        {
            int flightCount = 5;
            bool isLanding = false;

            Console.WriteLine("How many flights would you like to generate?");

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out flightCount))
                    Console.WriteLine("Invalid input, please try again...");
                else break;
            }

            for (int i = 0; i < flightCount; i++)
            {
                if (isLanding == true)
                     PostNewFlight(GenerateFlight(FlightType.Landing));
                else
                     PostNewFlight(GenerateFlight(FlightType.Departure));

                isLanding = !isLanding; //if it was true becomes false and other way around.
                _minDateTime.AddSeconds(_spaceBetweenFlight);
                Thread.Sleep(TimeSpan.FromSeconds(_spaceBetweenFlight));
            }
        }

        private static Flight GenerateFlight(FlightType flightType)
        {
            if (_minDateTime == default) _minDateTime = DateTime.Now;
            _minDateTime = _minDateTime.AddSeconds(_spaceBetweenFlight);

            var flight = new Flight
            {
                FlightNumber = GenerateFlightNumber(),
                FlightTime = _minDateTime,
                FlightCompany = _flightCompanies[_rnd.Next(_flightCompanies.Length)],
                Type = flightType,
                Status = FlightStatus.Future,
                PassengersCount = 0
            };
            //return new Flight
            //{
            //    FlightNumber = GenerateFlightNumber(),
            //    FlightTime = _minDateTime,
            //    FlightCompany = _flightCompanies[_rnd.Next(_flightCompanies.Length)],
            //    Type = flightType
            //};
            _context.Flights.Add(flight);
            _context.AddLog(flight);
            _context.SaveChanges();
            return flight;
        }

        private static string GenerateFlightNumber()
        {
            string sbCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-";

            StringBuilder sbRandomFlight = new StringBuilder();
            int rndLenght = _rnd.Next(4, 8);
            for (int i = 0; i < rndLenght; i++)
            {
                sbRandomFlight.Append(sbCharacters[_rnd.Next(sbCharacters.Length)]);
            }

            return sbRandomFlight.ToString();
        }

        private async static Task PostNewFlight(Flight plane)
        {
            PrintFlight(plane);
            var response = await httpClient.PostAsJsonAsync("api/airport", plane);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        private static void PrintFlight(Flight flight)
        {
            Console.WriteLine($"{flight.FlightNumber} - {flight.FlightCompany} - {flight.FlightTime}  - {flight.Type} - {flight.Status}");
        }

        private static void SetTerminals()
        {
            var t2 = Terminal_2.Init;
            _context.Terminals.Add(t2);
            _context.SaveChanges();
        }

        private static void UpdateInterval(Flight flight)
        {
            if (flight.CurrentTerminal != null)
                _timer.Interval = flight.CurrentTerminal.WaitTime * 1000;
            else
                _timer.Stop();
        }

        private static void GoNextTerminal(Flight flight)
        {
            Next(flight);
            UpdateInterval(flight);
            PrintFlight(flight);
        }

        private static void Next(Flight flight)
        {
            if (flight.CurrentTerminal != null)
            {
                flight.CurrentTerminal.NextTerminal(flight);
                _context.UpdateLog(flight);
            }
            else
                _timer.Stop();
        }

        private static List<Flight> GetFlightFromAir()
        {
            var flight = _context.Flights.ToList();//.FirstOrDefault(f => f.IsDeparture == null);
            return flight;
        }

        private static void FromAirToTerminal2(List<Flight> flights)
        {
            foreach (var flight in flights)
            {
                flight.Type = FlightType.Landing;
                flight.CurrentTerminal = _context.Terminals.First(t => t.TerminalNumber == 2);
                _context.UpdateLog(flight);

                PrintFlight(flight);
            }
        }
    }
}