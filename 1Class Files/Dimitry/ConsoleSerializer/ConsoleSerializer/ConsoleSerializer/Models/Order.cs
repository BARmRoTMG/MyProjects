using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ConsoleSerializer.Models
{
    public class Order
    {
        public string Code { get; set; }
        public StatusType Status { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Product> Products { get; set; }

        [XmlIgnore]
        public int CountChecks { get; set; }

        public Order() => Code = Guid.NewGuid().ToString();
    }
}