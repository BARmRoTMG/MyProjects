using System;
using System.Collections;
using System.Collections.Generic;

class HelloWorld
{
    class IntNode
    {
        private int data;
        private IntNode next;

        public IntNode(int data, IntNode next)
        {
            this.data = data;
            this.next = next;
        }

        public int Data { get { return data; } set { this.data = value; } }
        public IntNode Next { get { return next; } set { this.next = value; } }
    }

    class IntList
    {
        private IntNode head;

        public IntList()
        {
            head = null;
        }

        public void Shift()
        {
            if (head == null || head.Next == null)
                return;

            IntNode p, prev;
            p = head;
            prev = null;


            while(p.Next != null)
            {
                prev = p;
                p = p.Next;
            }

            if (prev != null)
            {
                p.Next = head;
                prev.Next = null;
                head = p;
            }
        } // Move every item in the list forward once
        
        public void Reverse()
        {
            IntNode rev = null, curr = head;

            while (head != null)
            {
                head = head.Next;
                curr.Next = rev;
                rev = curr;
                curr = head;
            }
            head = rev;
        }

        public void Concat(IntList other)
        {
            if (head == null)
                head = other.head;
            else
            {
                IntNode p;
                for (p = head; p.Next != null; p = p.Next) ;

                p.Next = other.head;
            }
        }

        public void addToStart(int num)
        {
            head = new IntNode(num, head);
        }

        public void addToEnd(int num)
        {
            IntNode p = head;
            for (; p.Next != null; p = p.Next) ;

            IntNode temp = new IntNode(num, null);
            p.Next = temp;
        }

        public override string ToString()
        {
            string res = "";

            for (IntNode p = head; p != null; p = p.Next)
                res += p.Data + " --> ";
            res += "null";
            return res;
        }

        //  returns true if the list has no elements O(1)
        public bool IsEmpty()
        {
            if (head == null)
                return true;

            return false;
        }

        //  returns number of elements in the list O(n)
        public int Length()
        {
            int count = 0;

            for (IntNode p = head; p != null; p = p.Next)
                count++;

            return count;
        }

        public void Remove(int num)
        {
            IntNode curr, prev;
            curr = head;
            prev = null;

            while (curr.Data != num && curr != null)
            {
                prev = curr;
                curr = curr.Next;
            }

            if (curr != null)
            {
                if (prev == null)
                    head = head.Next;
                else
                    prev.Next = curr.Next;
            }
        }
    }

    class ArrayStack
    {
        private int[] elements;
        private int top;

        public ArrayStack(int size)
        {
            elements = new int[size];
            top = 0;
        }

        public bool isEmpty()
        {
            if (top == 0)
                return true;
            return false;
        }

        public void Push(int x)
        {
            if (top < elements.Length)
            {
                elements[top] = x;
                top++;
            }
        }

        public int Pop()
        {
            if (!isEmpty())
            {
                top--;
                return elements[top];
            } else
                return -1;
        }
    }

    class ListStack
    {
        private IntNode top;

        public ListStack()
        {
            top = null;
        }

        public bool isEmpty()
        {
            if (top == null)
                return true;
            return false;
        }

        public void Push(int x)
        {
            top = new IntNode(x, top);
        }

        public int Pop()
        {
            if (!isEmpty())
            {
                int X = top.Data;
                top = top.Next;
                return X;
            } else
                return -1;
        }
    }

    class ListQueue
    {
        private IntNode front, back;

        public ListQueue()
        {
            front = back = null;
        }

        public bool isEmpty()
        {
            if (front == null)
                return true;
            return false;
        }

        public void Enqueue(int x)
        {
            IntNode temp = new IntNode(x, null);

            if (!isEmpty())
            {
                back.Next = temp;
                back = temp;
            }
            else
                back = front = temp;
        }

        public int Dequeue()
        {
            if (!isEmpty())
            {
                int x = front.Data;
                front = front.Next;

                if (front == null)
                    back = null;

                return x;
            }
            else
                return -1;
        }
    }

    class ArrayQueue
    {

    }

    static void Main()
    {
        // IntNode list = null;
        // list = new IntNode(3, list);
        // list = new IntNode(1, list);
        // list = new IntNode(8, list);

        // IntNode temp = new IntNode(2, null);
        // IntNode p;
        // for (p = list; p.Next != null; p = p.Next) ;
        // p.Next = temp;

        // // print the list
        // for (p = list; p != null; p = p.Next)
        //     Console.Write(p.Data + " --> ");

        // Console.WriteLine("null");

        //// print backwards
        // IntNode last = null;
        // while (last != list)
        // {
        //     for (p = list; p.Next != last; p = p.Next) ;

        //     Console.Write(p.Data + " --> ");
        //     last = p;
        // }

        // // count how many even numbers are in the list
        // int count = 0;
        // for (p = list; p != null; p = p.Next)
        //     if (p.Data % 2 == 0)
        //         count++;
        // Console.WriteLine("Even counter: " + count);


        //IntList list1 = new IntList();
        //list1.addToStart(6);
        //list1.addToStart(1);
        //list1.addToStart(4);

        //IntList list2 = new IntList();
        //list2.addToStart(2);
        //list2.addToStart(5);

        //Console.WriteLine(list1);
        //list1.Concat(list2);
        //Console.WriteLine(list1);

        //Stack s = new Stack();
        //s.Push(1);
        //s.Push(2);
        //s.Push(3);
        //Console.WriteLine(s.Pop());
        //Console.WriteLine(s.Pop());
        //s.Push(4);
        //s.Push(5);
        //Console.WriteLine(s.Pop());
        //s.Push(6);
        //Console.WriteLine(s.Pop());
        //Console.WriteLine(s.Pop());
        //Console.WriteLine(s.Pop());

        //ArrayStack a = new ArrayStack(10);
        //ListStack a = new ListStack();
        //a.Push(6);
        //a.Push(4);
        //a.Push(7);
        //Console.WriteLine(a.Pop());
        //for (int i = 10; i <= 14; i++)
        //    a.Push(i);

        //while (!a.isEmpty())
        //    Console.WriteLine(a.Pop());


        ListQueue q = new ListQueue();

        q.Enqueue(5);
        q.Enqueue(6);
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(7);

        while (!q.isEmpty())
            Console.WriteLine(q.Dequeue());
    }
}
