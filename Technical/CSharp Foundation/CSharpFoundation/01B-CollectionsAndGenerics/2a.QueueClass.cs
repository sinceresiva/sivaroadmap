using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Ch4_CollectionsAndGenerics
{
    //Sequential Lists: This program demonstrates the use of the Queue class.
    //The Queue class is a collection for dealing with first-in, first-out (FIFO) handling of
    //sequential objects. The interface to the Queue class is very simple: it supports putting
    //items into the queue and pulling them out.
    public class QueueClass
    {
        public static void Display()
        {
            Console.WriteLine("\nQueue Operations...");
            //Working with the Queue class is very straightforward. Once you have an instance of
            //the class, you can use the Enqueue method to add items to the queue and the Dequeue
            //method to remove items from the list.
            Queue queue = new Queue();
            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");
            queue.Enqueue("Fourth");
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            queue.Enqueue("Fifth");
            //There are times when being able to look at the next item without actually removing it
            //is a good idea because if you were to Dequeue it and then find out that someone else had to handle
            //it, you could put it back into the queue, but it would lose its place in line.
            if (queue.Peek() is int) //Checking whether the first item is an int which obviously is not the case
            {
                Console.WriteLine(queue.Dequeue());
            }

            //Verify that the queue still has one item in it.
            Console.WriteLine("Items in the queue: " + queue.Count);

        }
    }
}
