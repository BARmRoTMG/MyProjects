using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyQueue<T>
    {
        DoubleLinkedList<T> queue = new DoubleLinkedList<T>();

        public void First()
        {

        }

        public void EnQueue(T value)
        {
            queue.AddLast(value);
        }

        public void DeQueue(T value)
        {
            queue.RemoveFirst();
        }

        public void IsEmpty()
        {
            queue.IsEmpty();
        }
    }
}
