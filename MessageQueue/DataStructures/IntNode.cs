using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
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
}
