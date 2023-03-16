using FlightSimulator.Context;
using FlightSimulator.Entities;
using FlightSimulator.Enums;
using System;
using System.Net.Http.Json;
using System.Text;
using t = System.Timers;

namespace ConsoleAirs
{
    internal class Program
    {
        private static readonly DataContext _context = new DataContext();

        #region Fields/Properties
        private static HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7126") };

        private readonly static Random _rnd = new Random();
        private static DateTime _minDateTime;
        private static double _spaceBetweenFlight = 8;
        private static string[] _flightCompanies = new string[]
        {
                    "ISRAIR AIRLINES", "EL AL ISRAEL AIRLINES",
                    "FLYDUBAI", "EMIRATES AIRWAYS",
                    "ARKIA ISRAELI AIRLINES", "AIR FRANCE"
        };
        #endregion

        static void Main(string[] args)
        {
            SetTerminals();
            AutoFlightGen();

            Console.ReadLine();
        }

        private static void PrintFlight(Flight flight)
        {
            if (flight.CurrentTerminal == null)
                Console.WriteLine($"{flight.FlightNumber} - {flight.FlightCompany} - WAITING TO LAND - {flight.Type} - {DateTime.Now} - {flight.Status}");
            else
                Console.WriteLine($"{flight.FlightNumber} - {flight.FlightCompany} - {flight.CurrentTerminal} - {flight.Type} - {DateTime.Now} - {flight.Status}");
        }

        private static void AutoFlightGen()
        {
            var flightTimer = new t.Timer();
            flightTimer.Interval = _spaceBetweenFlight * 1000;
            flightTimer.Elapsed += (s, e) => GenerateFlights();
            flightTimer.Start();
        }

        private async static Task PostNewFlight(Flight plane)
        {
            var response = await httpClient.PostAsJsonAsync("api/airport/processFlights", plane);
            PrintFlight(plane);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        #region Starter
        private static void SetTerminals()
        {
            var t2 = Terminal_2.Init;
            _context.Terminals.Add(t2);
            _context.SaveChanges();
        }

        private async static void GenerateFlights()
        {
            if (_minDateTime == default) _minDateTime = DateTime.Now;
            _minDateTime = _minDateTime.AddSeconds(_spaceBetweenFlight);

            var flight = new Flight
            {
                FlightNumber = GenerateFlightNumber(),
                FlightCompany = _flightCompanies[_rnd.Next(_flightCompanies.Length)],
                FlightTime = _minDateTime,
                Type = FlightType.Landing,
                Status = FlightStatus.Future,
                PassengersCount = _rnd.Next(1, 200)
            };
            //await _context.Flights.AddAsync(flight);
            //await _context.SaveChangesAsync();
            await PostNewFlight(flight);
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
        #endregion
    }
}