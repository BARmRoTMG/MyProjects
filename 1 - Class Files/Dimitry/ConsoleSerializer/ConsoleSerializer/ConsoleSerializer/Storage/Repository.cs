using ConsoleSerializer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleSerializer.Storage
{
    public class Repository
    {
        public T Load<T>()
        {
            var formatter = new XmlSerializer(typeof(T));
            using (var file = File.Open("data.xml", FileMode.Open))
                return (T)formatter.Deserialize(file);
        }

        public void Save<T>(T data)
        {
            var formatter = new XmlSerializer(typeof(T));
            using (var file = File.Create("data.xml"))
                formatter.Serialize(file, data);
        }

        public void SaveJson<T>(T data)
        {
            var formatter = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter("data.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                formatter.Serialize(writer, data);
            }
        }
    }
}
