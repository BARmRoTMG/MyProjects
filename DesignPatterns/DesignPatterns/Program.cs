//using System;
//using System.Collections.Generic;

//namespace Composite.Structural
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            // Create a tree structure
//            Composite root = new Composite("root");
//            root.Add(new Leaf("Leaf A"));
//            root.Add(new Leaf("Leaf B"));

//            Composite comp = new Composite("Composite X");
//            comp.Add(new Leaf("Leaf XA"));
//            comp.Add(new Leaf("Leaf XB"));

//            root.Add(comp);
//            root.Add(new Leaf("Leaf C"));


//            // Add and remove a leaf
//            Leaf leaf = new Leaf("Leaf D");
//            root.Add(leaf);
//            root.Remove(leaf);


//            // Recursively display tree
//            root.Display(1);


//            // Wait for user
//            Console.ReadKey();
//        }
//    }

//    public interface IComponent
//    {
//        string Name { get; set; }
//        void Add(IComponent c);
//        void Remove(IComponent c);
//        void Display(int depth);
//    }


//    public class Composite : IComponent
//    {
//        List<IComponent> children = new List<IComponent>();
//        public string Name { get; set; }

//        // Constructor
//        public Composite(string name)
//        {
//            Name = name;
//        }

//        public void Add(IComponent component)
//        {
//            children.Add(component);
//        }

//        public void Remove(IComponent component)
//        {
//            children.Remove(component);
//        }

//        public void Display(int depth)
//        {
//            Console.WriteLine(new String('-', depth) + Name);

//            // Recursively display child nodes
//            foreach (IComponent component in children)
//                component.Display(depth + 2);
//        }
//    }


//    public class Leaf : IComponent
//    {
//        public string Name { get; set; }

//        // Constructor
//        public Leaf(string name)
//        {
//            Name = name;
//        }

//        public void Add(IComponent c)
//        {
//            Console.WriteLine("Cannot add to a leaf");
//        }

//        public void Remove(IComponent c)
//        {
//            Console.WriteLine("Cannot remove from a leaf");
//        }

//        public void Display(int depth)
//        {
//            Console.WriteLine(new String('-', depth) + Name);
//        }
//    }
//} Composite

using System;

namespace Proxy.Structural
{
    /// <summary>
    /// Proxy Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            // Create proxy and request a service

            var proxy = new Proxy();
            proxy.Request();

            // Wait for user

            Console.ReadKey();
        }
    }

    public interface ISubject
    {
        public void Request();
    }

    public class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("Called RealSubject.Request()");
        }
    }

    public class Proxy : ISubject
    {
        private RealSubject realSubject;

        public void Request()
        {
            // Use 'lazy initialization'

            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }

            realSubject.Request();
        }
    }
}


