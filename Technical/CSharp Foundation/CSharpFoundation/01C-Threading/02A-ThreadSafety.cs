using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSharpFoundation
{
    public class _02A_ThreadSafety
    {
        public static void RunThreadSafety()
        {
            //ThreadSafety
            //************
            //A program or method is thread-safe if it has no indeterminacy (means unable to determine the output) in the face of any multithreading scenario. 
            //Thread safety is achieved primarily with locking and by reducing the possibilities for thread interaction.
            //General-purpose types are rarely thread-safe in their entirety because development burden in full thread safety can be significant
            //or can entail a performance cost.
            //IMPORTANT: Thread safety is hence usually implemented just where it needs to be, in order to handle a specific multithreading scenario.

            //Thread Safety and .NET Framework Types
            //Nearly all .NET Framework Types (other than primitive types) are NOT thread-safe (for anything more than read-only access) when instantiated, 
            //and yet they can be used in multithreaded code if all access to any given object is protected via a lock.
            //Here’s an example, where two threads simultaneously add an item to the same List collection, then enumerate the list:
            new Thread(AddItem).Start();
            new Thread(AddItem).Start();
        }

        static List<string> _list = new List<string>();

        static void AddItem()
        {
            //In this case, we’re locking on the _list object itself.
            lock (_list) 
                _list.Add("Item " + _list.Count);
            
            string[] items;
            
            //Enumerating .NET collections is also thread-unsafe in the sense that an exception is thrown if the list is modified 
            //during enumeration. Rather than locking for the duration of enumeration, in this example we first copy the items to an array. 
            //This avoids holding the lock excessively if what we’re doing during enumeration is potentially time-consuming.
            lock (_list)
                items = _list.ToArray();

            foreach (string s in items) 
                Console.WriteLine(s);

            //Locking around thread-safe objects
            //**********************************
            //Sometimes you also need to lock around accessing thread-safe objects.
            lock (_list)
            {
                if (!_list.Contains("Item 1000")) //Here we are accessing _list.
                    _list.Add("Item 1000");

            }

            //Static methods
            //**************
            //A common pattern throughout the .NET Framework is that "static members of a .NET Framework type are thread-safe; instance members are not."
            //Also in our custom types, thread safety in static methods is something that we must explicitly code: it doesn’t happen 
            //automatically by virtue of the method being static!
            //Also in the .NET Framework, collections types for example, are threadsafe for concurrent read-only access.

            //Thread Safety in Application Servers
            //************************************
            //Application servers such as WCF, ASP.NET etc are designed to be multithreaded to handle simultaneous client requests.
            //This means that when writing code on the server side, we must consider thread safety if there’s any possibility of interaction among the threads
            //processing client requests. If the types are purely stateless, then it is perfectly fine. But if instances are sharing static fields,
            //then we must take thread safety into account by appropriately locking those instances as shown above in the _list example.

            //Rich Client Applications and Thread Affinity
            //********************************************
            //Both the Windows Presentation Foundation (WPF) and Windows Forms follow models based on thread affinity meaning that 
            //means that only the thread that instantiates the UI elements (such as button) can subsequently access their members.
            //If you wish a worker thread to update a control on the UI thread call Invoke or BeginInvoke on the element’s Dispatcher object.

        }
    }
}
