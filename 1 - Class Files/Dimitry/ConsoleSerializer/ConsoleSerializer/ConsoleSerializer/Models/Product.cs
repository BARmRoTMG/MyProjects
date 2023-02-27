using System;

namespace ConsoleSerializer.Models
{
    ///new XmlSerializer(typeof(Product))
    ///
    /// <xml>
    ///     <Product>
    ///         <Valid>True</Valid>
    ///         <Price>555.6</Price>
    ///     </Product>
    /// </xml>
    
    [Serializable]
    public class Product
    {
        public bool? Valid { get; set; }
        public double Price { get; set; }
    }
}