using System;

namespace DataStructures
{
    public class DoubleLinkedList<T>
    {
        Node start;
        Node end;

        public DoubleLinkedList()
        {
            start = end = null;
        }

        public void AddFirst(T value) //O(1)
        {
            Node n = new Node(value);
            n.next = start;
            start = n;

            if (end == null) // the very first item to add
                end = n;
        }

        public void AddLast(T value)
        {
            if(!IsEmpty())
            {
                AddFirst(value);
                return;
            }

            Node n = new Node(value);
            end.next = n;
            end = n;
        }

        public void RemoveFirst()
        {
            if (!IsEmpty())
            {
                T x = start.data;
                start = start.next;

                if (start == null)
                    end = null;
            }
        }

        public T RemoveLast()
        {
            if (start != null)
            {
                T temp = start.data;
                RemoveFirst();
                return temp;
            }
            return end.data;
        }

        public void AddAt(int index, T value)
        {
            Node n = new Node(value);

            if (n.prev != null)
            {
                n.next = n.prev;
                //n.prev = value;
            }

            if (n.next != null)
                n.next.prev = n;
        }

        //public void RemoveAt(Node n)
        //{
        //    if (n == end)
        //        RemoveLast();
        //    else if (n == start)
        //        RemoveFirst();
        //}

        public bool IsEmpty()
        {
            if (start == null)
                return true;

            return false;
        }

        public class Node
        {
            public T data;
            public Node next;
            public Node prev;

            public Node(T data)
            {
                this.data = data;
                this.next = null;
                this.prev = null;
            }
        }
    }
}
