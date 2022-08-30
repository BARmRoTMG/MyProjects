using DataStructures;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageQueue
{
    internal class Program
    {
        private static Manager manager = new Manager();

        private static string _messageData;
        private  static string _adressee;
        private static bool _sendMessage;

        static void Main(string[] args)
        {
            _sendMessage = true;

            do
            {
                RequestMessage();
                CheckStatus();

            } while (_sendMessage);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Message Queue has stopped, please restart.");
            Console.ReadLine();
        }

        public static void RequestMessage()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter a message: ");
            _messageData = Console.ReadLine();

            Console.WriteLine("Enter adressee: ");
            _adressee = Console.ReadLine();

            Message message = new Message(_messageData, _adressee, DateTime.Now);
            manager.SendMessage(_messageData, _adressee);

            Console.WriteLine(message.ToString());
        }

        public static void CheckStatus()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nDo you wish to send any more messages? \nType Y/N");
            string answer = Console.ReadLine();

            if (answer == "Y" || answer == "y")
                _sendMessage = true;
            else if (answer == "N" || answer == "n")
                _sendMessage = false;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please answer using Y or N.");
                CheckStatus();
            }
        }
    }
}
