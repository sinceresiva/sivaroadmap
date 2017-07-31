using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Ch4_CollectionsAndGenerics
{
    //Sequential Lists: This program demonstrates the use of the Stack class.
    //The Stack class is a last-in, first-out (LIFO) collection.
    public class StackClass
    {
        public static void Display()
        {
            Console.WriteLine("\nStack Operations...");
            //you use the Push method to add items to the stack and 
            //the Pop method to remove items from the top of the stack.
            Stack s = new Stack();
            s.Push("First");
            s.Push("Second");
            s.Push("Third");
            s.Push("Fourth");
            while (s.Count > 0)
            {
                Console.WriteLine(s.Pop());
            }

            s.Push("Fifth");
            //Retrieves the top item from the stack without removing it
            if (s.Peek() is string) //Checking whether the top item is string
            {
                Console.WriteLine("Popped item: "+s.Pop());
            }


        }
    }
}
