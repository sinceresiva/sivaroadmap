using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//This program demonstrates the use of Delegates and Events.
namespace Chapter1
{
    /// <summary>
    /// This class EventNumberEventArgs specifies a class that derives from
    /// <see cref="EventArgs"> EventArgs</see> class.
    /// </summary>
    public class EventNumberEventArgs: EventArgs
    {
        public EventNumberEventArgs(int evenNumber){
            this.EvenNumber = evenNumber;    
        }

        public int EvenNumber { get; set; }

    }

    /// <summary>
    /// The class EventNumberGenerator defines the delegates and the events
    /// and contains the  method GenerateEvenNumbers() that generates even numbers
    /// </summary>
    public class EventNumberGenerator
    {
        public delegate void EvenNumberGenerated(object sender, EventNumberEventArgs e);
        public event EvenNumberGenerated OnEvenNumberGenerated;

        public void GenerateEvenNumbers(int startNumber, int endNumber)
        {
            Random rnd = new Random(startNumber);
            for (int counter = 0; counter < 10; counter++)
            {
                int randomNumber = rnd.Next(endNumber);
                if (randomNumber % 2 == 0)
                {
                    if (OnEvenNumberGenerated != null)
                        OnEvenNumberGenerated(this, new EventNumberEventArgs(randomNumber));
                }
            }
        }
    }

    /// <summary>
    /// The class EvenNumberConsumer consumes the EventNumberGenerator methods.
    /// </summary>
    public class EvenNumberConsumer
    {
        private EventNumberGenerator _evenNoGenerator;
        public EvenNumberConsumer()
        {
            Console.WriteLine("\n****Generating Even Numbers: EvenNumberConsumer");
            _evenNoGenerator = new EventNumberGenerator();
            _evenNoGenerator.OnEvenNumberGenerated += new EventNumberGenerator.EvenNumberGenerated(_evenNoGenerator_OnEvenNumberGenerated);
        }

        void _evenNoGenerator_OnEvenNumberGenerated(object sender, EventNumberEventArgs e)
        {
            Console.WriteLine("Even Number: {0}", e.EvenNumber);
        }

        public void DisplayEvenNumbers()
        {
            _evenNoGenerator.GenerateEvenNumbers(100, 1000);
        }
    }
}
