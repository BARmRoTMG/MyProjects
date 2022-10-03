using ConsoleSerializer.Models;
using ConsoleSerializer.Services;
using ConsoleSerializer.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleSerializer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BinaryFormat();

            //XmlFormat();

            //WebClientXml();

            //WebClientJson();

            Repository repository = new Repository();
            DataService data = new DataService();
            var customers = data.GetCustomers();

            repository.Save(customers);
            repository.SaveJson(customers);
        }

        private static void WebClientJson()
        {
            WebClient client = new WebClient();
            Console.WriteLine("Insert City:");
            var city = Console.ReadLine();
            try
            {
                var json = client.DownloadString($@"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid=a0057f440991bfa0a5e22c2f64a3c1a9");
                //Console.WriteLine(json);
                //var jsonFormat = JsonConvert.DeserializeObject(json);
                //Console.WriteLine(jsonFormat);          
                var jsonObject = JsonConvert.DeserializeObject<MyWeather>(json);
                Console.WriteLine($"Temp = {jsonObject.main.temp} C`");
            }
            catch
            {
                Console.WriteLine($"{city} is not exists");
            }
        }

        private static void WebClientXml()
        {
            WebClient client = new WebClient();
            var xml = client.DownloadString(@"https://www.w3schools.com/xml/note.xml");
            Console.WriteLine(xml);
        }

        private static void XmlFormat()
        {
            Repository repository = new Repository();
            Product prod = null;

            prod = new Product { Price = 53.6, Valid = true };
            //repository.Save(prod);

            var order = new Order
            {
                CreationDate = DateTime.Now,
                Status = StatusType.Silver,
                Products = new List<Product> { prod, new Product { Price = 76.6 } }
            };
            repository.Save(order);

            //prod = repository.Load();
            //Console.WriteLine($"{prod.Price} - {prod.Valid}");
        }

        private static void BinaryFormat()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Product prod = null;

            prod = new Product { Price = 53.6, Valid = true };
            using (var file = File.Create("product.txt"))
                formatter.Serialize(file, prod);

            //using (var file = File.Open("product.txt", FileMode.Open))
            //    prod = (Product)formatter.Deserialize(file);

            //Console.WriteLine($"{prod.Price} - {prod.Valid}");
        }
    }
}