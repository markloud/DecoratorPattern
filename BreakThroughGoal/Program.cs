/*
Theoretical example: Decorator Pattern
*/
using System;

namespace Decorator
{
    internal class Program
    {
        /// <summary>
        /// IComponent interface
        /// </summary>
        public interface IComponent
        {
            string Operation();
        }

        /// <summary>
        /// Component Subject
        /// </summary>
        private class Component : IComponent // Concrete component class
        {
            public string Operation()
            {
                return "I am walking ";
            }
        }

        private class DecoratorA : IComponent // Concrete decorator class
        {
            private IComponent component; // declaration of object to decorate

            public DecoratorA(IComponent c) // pass object in constructor
            {
                component = c;
            }

            public string Operation() // implimented method
            {
                var s = component.Operation(); // call the 
                s += "(A) and listening to classic FM ";
                return s;
            }
        }

        private class DecoratorB : IComponent
        {
            private IComponent component; 
            public string addedState = "(B: state) past the coffee shop "; // public added state

            public DecoratorB(IComponent c)
            {
                component = c;
            }

            public string Operation() // implimented operation
            {
                string s = component.Operation();
                s += "(B) to school ";
                return s;
            }

            public string AddedBehavior() // public added behavior
            {
                return "(B: behavior) and I bought a cappuccino ";
            }
        }

        public class Client // calls components operation
        {
            public static void Display(string s, IComponent c)
            {
                Console.WriteLine(s + c.Operation());
            }
        }

        private static void Main()
        {
            // Decorator Pattern
            IComponent component = new Component();
            Console.WriteLine(component.Operation());
            Client.Display("Basic: ", component);
            Client.Display("A: ", new DecoratorA(component));
            Client.Display("B: ", new DecoratorB(component));
            Client.Display("B-A: ", new DecoratorB(new DecoratorA(component)));

            // Explicit Decorator B
            DecoratorB b = new DecoratorB(new Component());
            Client.Display("A-B: ", new DecoratorA(b));
            // Invoke added state and behavior
            Console.WriteLine("\t\t\t" + b.addedState + b.AddedBehavior());

            Console.ReadKey();
        }
    }
}

/*
Does not rely on inheritance for extending behavior

If the tag class had to inherit from Photo class to add one or two methods,
Tags would carry everything concerned with Photos (making them heavyweight objects)

*/