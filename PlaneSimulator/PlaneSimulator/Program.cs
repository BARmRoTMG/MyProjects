using FlightControl.Dal.Dtos;
using System.Net.Http.Json;

HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7066") };

Random rnd = new Random();

System.Timers.Timer timer = new System.Timers.Timer(rnd.Next(1, 1000));
timer.Elapsed += (s, e) => PostPlane();
timer.Start();

Console.ReadLine();

async void PostPlane()
{
    Random rnd = new Random();
    var plane = new FlightDto 
    {
        Brand = (BrandTypeDto)rnd.Next(0,5),
        PassangerCount = rnd.Next(100, 700),
    };
    await httpClient.PostAsJsonAsync("api/planes", plane);

    Console.WriteLine($"{DateTime.Now.ToString("mm:ss")}: {plane.Number} - {plane.Brand} - {plane.PassangerCount}");

    timer.Interval = rnd.Next(1, 1000);
}