using System;

namespace DoFactory.GangOfFour.Factory.Structural
{
    /// <summary>
    /// MainApp startup class for Structural 
    /// Factory Method Design Pattern.
    /// </summary>

    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>

        static void Main()
        {
            // An array of creators
            var creators = Init();


            // Iterate over creators and create products

            foreach (var creator in creators)
            {
                var product = creator.Create();
                Console.WriteLine("Created {0}",
                          product.GetType().Name);
            }

            // Wait for user

            Console.ReadLine();
        }

        private static IProductCreator[] Init()
        {
            return new IProductCreator[]
            {
                new CreatorA(),
                new CreatorB(),
                new CreatorC()
            };
        }
    }

    /// <summary>
    /// The 'Product' abstract class
    /// </summary>

    interface IProduct
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>

    class ConcreteProductA : IProduct
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>

    class ConcreteProductB : IProduct
    {
    }

    class ConcreteProductC : IProduct
    {

        public ConcreteProductC(string name)
        {

        }
    }

    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>

    interface IProductCreator
    {
        IProduct Create();
    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>

    class CreatorA : IProductCreator
    {
        public IProduct Create()
        {
            return new ConcreteProductA();
        }
    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>

    class CreatorB : IProductCreator
    {
        public IProduct Create()
        {
            return new ConcreteProductB();
        }
    }

    class CreatorC : IProductCreator
    {
        public IProduct Create()
        {
            return new ConcreteProductC("World");
        }
    }
}
