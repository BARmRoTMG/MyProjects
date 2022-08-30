using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Manager
    {
        Dictionary<string, MyQueue<DoubleLinkedList<Message>.Node>> dictionary = new Dictionary<string, MyQueue<DoubleLinkedList<Message>.Node>>();
        DoubleLinkedList<Message> messageByTime = new DoubleLinkedList<Message>();

        public void SendMessage(string messageData, string adressee)
        {
            Message message = new Message(messageData, adressee, DateTime.Now);
            if (!dictionary.ContainsKey(adressee))
                dictionary.Add(adressee, new MyQueue<DoubleLinkedList<Message>.Node>());

            //dictionary[adressee].EnQueue(messageByTime.AddLast(message)); replace excisting message with current
        }

        public string ShowKeys()
        {
            if (dictionary.Keys.Count == 0)
                return "No data.";
            return String.Join(", ", dictionary.Keys);
        }

        public string GetMessageByKey(string adressee)
        {
            if (!dictionary.ContainsKey(adressee))
                return "Key does not exist;";

            return dictionary[adressee].ToString();
        }

        public string GetLastMessage()
        {
            if (dictionary.Keys.Count == 0)
                throw new Exception("No data.");

            return dictionary.Last().ToString();
        }
    }
}
