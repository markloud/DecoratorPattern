using System;

namespace DoFactory.GangOfFour.Decorator.Structural
{
    /// <summary>
    /// The 'Component' abstract class
    /// </summary>
    interface IComponent
    {
        void Operation();
    }

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    class ConcreteComponent : IComponent
    {
        public void Operation()
        {
            Console.Write("ConcreteComponent.");
        }
    }
    
    /// <summary>
    /// The 'ConcreteDecoratorA' class
    /// </summary>
    class ConcreteDecoratorA : IComponent
    {
        protected IComponent component;
        public ConcreteDecoratorA(IComponent c)
        {
            component = c;
        }

        public void Operation()
        {
            component.Operation();
            Console.WriteLine("ConcreteDecoratorA.");
        }
    }

    /// <summary>
    /// The 'ConcreteDecoratorB' class
    /// </summary>
    class ConcreteDecoratorB : IComponent
    {
        IComponent component;
        public ConcreteDecoratorB(IComponent c)
        {
            component = c;
        }
        public void Operation()
        {
            component.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.");
        }

        void AddedBehavior()
        {
            Console.Write("(my added behavior) - ");
        }
    }


    /// <summary>
    /// MainApp startup class for Structural 
    /// Decorator Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            IComponent c = new ConcreteComponent();
            // Create ConcreteComponent and two Decorators
            var d1 = new ConcreteDecoratorA(c);
            var d2 = new ConcreteDecoratorB(c);

            // perform operations
            c.Operation();
            Console.WriteLine("---end---");
            d1.Operation();
            d2.Operation();

            Console.WriteLine("---end---");
            var d3 = new ConcreteDecoratorA(new ConcreteDecoratorB(c));
            d3.Operation();

            // Wait for user
            Console.ReadKey();
        }
    }
}