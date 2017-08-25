using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    //Events
    //When using delegates, two emergent roles commonly appear: broadcaster and
    //subscriber.
    //The broadcaster is a type that contains a delegate field. The broadcaster decides
    //when to broadcast, by invoking the delegate.
    //The subscribers are the method target recipients. A subscriber decides when to start
    //and stop listening, by calling += and −= on the broadcaster’s delegate. A subscriber
    //does not know about, or interfere with, other subscribers.
    public class _01C_Events
    {
        //The EvenNumberEventArgs class is used by EvenNumberGenerator
        public class EvenNumberEventArgs : EventArgs
        {
            public EvenNumberEventArgs(int evenNumber)
            {
                this.EvenNumber = evenNumber;
            }
            public int EvenNumber { get; set; }
        }

        public class EvenNumberGenerator
        {
            //Declare the delegate type.
            public delegate void EvenNumberFoundHandler(object sender, EvenNumberEventArgs e);

            //The easiest way to declare an event is to put the event keyword in front of a delegate instance.
            public event EvenNumberFoundHandler OnEvenNumberFound;

            public void RunGenerateRandomNumbers()
            {
                Random rnd = new Random(100);
                int randomNumber = rnd.Next(100);
                if (randomNumber % 2 == 0)
                {
                    //Raise the event. Code within the Broadcaster type has full access to Progress and can treat it as a
                    //delegate.
                    if (OnEvenNumberFound != null)
                        OnEvenNumberFound(this, new EvenNumberEventArgs(randomNumber));
                    return;
                }
                else
                    RunGenerateRandomNumbers();
            }

            //Note: If we remove the event keyword from our example so that OnEvenNumberFound becomes an
            //ordinary delegate field, our example would give the same results. However it
            //would be less robust, in that subscribers could do the following things to interfere
            //with each other:
            //  • Replace other subscribers by reassigning OnEvenNumberFound (instead of using the +=
            //  operator).
            //  • Clear all subscribers (by setting OnEvenNumberFound to null).
            //  • Broadcast to other subscribers by invoking the delegate.
        }
    }
}
