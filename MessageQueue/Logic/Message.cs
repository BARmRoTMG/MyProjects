using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Message
    {
        string _message;
        string _adressee;
        DateTime _date;

        public Message(string message, string adressee, DateTime date)
        {
            _message = message;
            _adressee = adressee;
            _date = date;
        }

        public override string ToString()
        {
            return $"\n\n\nContent: {_message} \nAdressee: {_adressee} \nDate Sent: {_date}";
        }
    }
}
