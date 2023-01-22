using FlightSimulator.Entities;
using System;
using System.Collections.Generic;
using t = System.Timers;

namespace Logic.Logic
{
    public static class TimerLogic
    {
        public static bool CanStartTimer(Queue<Flight> flightsQueue)
        {
            if (flightsQueue.Count > 0) return false;
            return true;
        }

        public static void StartTimer(Queue<Flight> flightsQueue, t.Timer timer)
        {
            if (flightsQueue.Count > 0)
            {
                var futureFlight = flightsQueue.Peek();
                var distance = futureFlight.FlightTime - DateTime.Now;
                timer.Interval = distance.TotalMilliseconds;
                timer.Enabled = true;

            }
            else return;
        }
       
        public static Flight GetFlightTurn(Queue<Flight> flightsQueue, t.Timer timer)
        {
            timer.Enabled = false;
            if (flightsQueue.Count > 0) return flightsQueue.Dequeue();
            return default;
        }
    }
}
