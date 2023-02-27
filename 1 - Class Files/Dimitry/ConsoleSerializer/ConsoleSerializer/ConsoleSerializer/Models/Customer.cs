using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ConsoleSerializer.Models
{
    public class Customer
    {
        [JsonProperty("cuId")]
        [XmlElement("custId")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlArray("ords")]
        [XmlArrayItem("or")]
        public List<Order> Orders { get; set; }


        [OnSerializing]
        public void MySerializing(StreamingContext context)
        {
            if (string.IsNullOrEmpty(Name))
                throw new Exception("ERROR because the name is EMPTY");
            Console.WriteLine($"{Name} before save");
        }

        [OnSerialized]
        public void MySerialized(StreamingContext context) => Console.WriteLine($"{Name} after save");

        [OnDeserializing]
        public void MyDeserializing(StreamingContext context) => Console.WriteLine($"{Name} before load");

        [OnDeserialized]
        public void MyDeserialized(StreamingContext context) => Console.WriteLine($"{Name} after load");
    }
}