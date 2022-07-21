using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree_DataStructures
{
    class Node
    {
        private int data;
        private Node left, right;

        public Node(int data, Node left, Node right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        public Node Left
        {
            get { return left; }
            set { left = value; }
        }
        public Node Right
        {
            get { return right; }
            set { right = value; }
        }
    }

    class BTree
    {
        private Node root;
        public BTree()
        {
            root = null;
        }

        public void addNode(int data, string path)
        {
            if (root == null)
                root = new Node(data, null, null);
            else
            {
                Node p = root;
                for (int i = 0; i < path.Length - 1; i++)
                {
                    if (path[i] == 'L')
                        p = p.Left;
                    else
                        p = p.Right;
                }

                if (path[path.Length - 1] == 'L')
                    p.Left = new Node(data, null, null);
                else
                    p.Right = new Node(data, null, null);
            }
        }

        public void pre()
        {
            pre(root);
        }

        private void pre(Node t)
        {
            if (t != null)
            {
                Console.Write(t.Data + " ");
                pre(t.Left);
                pre(t.Right);
            }
        }

        public void inOrder()
        {
            inOrder(root);
        }

        public void inOrder(Node t)
        {
            if (t != null)
            {
                inOrder(t.Left);
                Console.Write(t.Data + " ");
                inOrder(t.Right);
            }
        }

        public void post()
        {
            post(root);
        }
        private void post(Node t)
        {
            if (t != null)
            {
                post(t.Left);
                post(t.Right);
                Console.Write(t.Data + " ");
            }
        }
        public int countNodes()
        {
            return countNodes(root);
        }

        private int countNodes(Node t)
        {
            if (t == null)
                return 0;

            return countNodes(t.Left) + countNodes(t.Right) + 1;
        }

        public int countLeaves()
        {
            return countLeaves(root);
        }

        private int countLeaves(Node t)
        {
            if (t == null)
                return 0;
            else if (t.Right == null && t.Left == null)
                return 1;

            return countLeaves(t.Left) + countLeaves(t.Right);
        }
    }

    class BST
    {
        private Node root;

        public BST()
        {
            root = null;
        }

        public void addNode(int x)
        {
            if (root == null)
                root = new Node(x, null, null);
            else
                addNode(x, root);
        }

        private void addNode(int x, Node t)
        {
            if (x < t.Data)
            {
                if (t.Left == null)
                    t.Left = new Node(x, null, null);
                else
                    addNode(x, t.Left);
            } else
            {
                if (t.Right == null)
                    t.Right = new Node(x, null, null);
                else
                    addNode(x, t.Right);
            }
        }

        public bool find(int x)
        {
            return find(x, root);
        }

        private bool find(int x, Node t)
        {
            if (t == null)
                return false;
            if (t.Data == x)
                return true;
            if (x < t.Data)
                return find(x, t.Left);
            return find(x, t.Right);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Node root = null;
            //root = new Node(9, null, null);
            //root.Left = new Node(2, null, null);
            //root.Right = new Node(4, null, null);
            //Node temp = root.Left;
            //temp.Left = new Node(3, null, null);
            //temp = root.Right;
            //temp.Right = new Node(5, null, null);

            //temp = root.Left;
            //temp.Right = new Node(7, null, null);
            //temp = root.Right.Right;

            //Console.WriteLine(root.Left.Right.Data);
            //Console.WriteLine(root.Right.Right.Data);
            //Console.WriteLine(root.Left.Right.Left.Data);

            BTree tree = new BTree();
            tree.addNode(1, "");
            tree.addNode(3, "L");
            tree.addNode(5, "R");
            tree.addNode(9, "LL");
            tree.addNode(4, "LR");
            tree.addNode(7, "RR");
            tree.addNode(2, "LLL");
            tree.addNode(6, "RRL");
            tree.pre();
            Console.WriteLine();
            tree.inOrder();
            Console.WriteLine();
            tree.post();
            Console.WriteLine();
            Console.WriteLine(tree.countNodes());
            Console.WriteLine(tree.countLeaves());
        }
    }
}
