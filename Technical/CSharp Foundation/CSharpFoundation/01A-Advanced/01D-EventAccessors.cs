using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    //The Framework defines a generic delegate called System.EventHandler<T> that does the same thing:
    //public delegate void EventHandler<TEventArgs>
    //(object source, TEventArgs e) where TEventArgs : EventArgs;

    public class _01C_Events_1
    {
        //The previous code thus can be written using the above generic delegate
        public class OddNumberEventArgs : EventArgs
        {
            public OddNumberEventArgs(int oddNumber)
            {
                this.OddNumber = oddNumber;
            }
            public int OddNumber { get; set; }
        }

        public class OddNumberGenerator
        {
            Random rnd = new Random(100);

            //Declare an event using the Generic Handler as:
            public event EventHandler<OddNumberEventArgs> OddNumberFoundEvent;

            public void RunGenerateRandomNumbers()
            {
                int randomNumber = rnd.Next(100);
                if (randomNumber % 2 != 0)
                {
                    //Raise the event. 
                    OnOddNumberFoundEvent(new OddNumberEventArgs(randomNumber));
                    return;
                }
                else
                    RunGenerateRandomNumbers();
            }

            protected virtual void OnOddNumberFoundEvent(OddNumberEventArgs e)
            {
                if (OddNumberFoundEvent != null)
                    OddNumberFoundEvent(this, e);
            }
            
            //Note: The predefined nongeneric EventHandler delegate can be used when an event doesn’t carry extra information.
            //Example: public event EventHandler PriceChanged;
        }

        //Event Accessors
        //An event’s accessors are the implementations of its += and −= functions. By default,
        //accessors are implemented implicitly by the compiler. Consider this event
        //declaration:
        //public event EventHandler PriceChanged;
        //The compiler converts this to the following:
        //  • A private delegate field
        //  • A public pair of event accessor functions, whose implementations forward the += and −= 
        //                                                  operations to the private delegate field.
        //We can take over this process by defining explicit event accessors.:
        //private EventHandler _priceChanged; // Declare a private delegate
        //public event EventHandler PriceChanged
        //{
        //    add { _priceChanged += value; }
        //    remove { _priceChanged -= value; }
        //}
        public class EventAccessorDemo
        {
            private EventHandler _sampleEvent;
            public event EventHandler SampleEvent
            {
                add{_sampleEvent+=value;}
                remove { _sampleEvent -= value; }
            }

            public void SomeMethod()
            {
                if (_sampleEvent != null)
                    _sampleEvent(this, new EventArgs());
            }

            public static void RunEventAccessorDemo()
            {
                EventAccessorDemo demo = new EventAccessorDemo();
                demo.SampleEvent += new EventHandler(demo_SampleEvent);
                demo.SomeMethod();
            }

            static void demo_SampleEvent(object sender, EventArgs e)
            {
                Console.WriteLine("Sample Event");
            }

            //Event Modifiers
            //Like methods, events can be virtual, overridden, abstract, or sealed. Events can also
            //be static:
            //public class Foo
            //{
            //  public static event EventHandler<EventArgs> StaticEvent;
            //  public virtual event EventHandler<EventArgs> VirtualEvent;
            //}
        }
    }
}
