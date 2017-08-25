using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    //An enumerator is a read-only, forward-only cursor over a sequence of values. An
    //enumerator is an object that implements either of the following interfaces:
    //• System.Collections.IEnumerator
    //• System.Collections.Generic.IEnumerator<T>
    public class _02AEnumerations
    {
        //The enumeration pattern is as follows:
        //  class Enumerator // Typically implements IEnumerator or IEnumerator<T>
        //  {
        //      public IteratorVariableType Current { get {...} }
        //      public bool MoveNext() {...}
        //  }
        public static void RunEnumeration()
        {
            using (var enumerator = "beer".GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var element = enumerator.Current;
                    Console.WriteLine(element);
                }
            }

            //Collection Initializers
            //You can instantiate and populate an enumerable object in a single step.
            List<int> list = new List<int> { 1, 2, 3 };

            //Iterators
            //Whereas a foreach statement is a consumer of an enumerator, an iterator is a producer of an enumerator.
            //In this example, we use an iterator to return a sequence of Fibonacci numbers (where each number is the sum of the previous two):
            foreach (int fib in Fibonacci(6))
                Console.Write(fib + " ");

            //Iterator Semantics:
            //An iterator is a method, property, or indexer that contains one or more yield statements and
            //An iterator must return one of the following four interfaces (otherwise, the compiler will generate an error):
            ////    Enumerable interfaces
            //          System.Collections.IEnumerable
            //          System.Collections.Generic.IEnumerable<T>
            ////    Enumerator interfaces
            //          System.Collections.IEnumerator
            //          System.Collections.Generic.IEnumerator<T>

            //Also note that multiple yield statements are permitted (see GetLines() method).
            foreach (string s in GetLines())
                Console.WriteLine(s); // Prints "One","Two","Three"

            //The yield break statement indicates that the iterator block should exit early, without
            //returning more elements
            foreach (string s in GetLines(true))
                Console.WriteLine(s); // Prints "One","Two""

            //Iterators and try/catch/finally blocks
            //A yield return statement cannot appear in a try, catch or finally block. These restrictions are due
            //to the fact that the compiler must translate iterators into ordinary classes with MoveNext, Current, and Dispose members, 
            //and translating exception handling blocks would create excessive complexity.

            //Composing Sequences
            //Iterators are highly composable. We can extend our example, this time to output even Fibonacci numbers only:
            Console.WriteLine("Even fibonacci");
            foreach (int fib in EvenNumbersOnly(Fibonacci(10)))
                Console.WriteLine(fib);
        }

        

        static IEnumerable<int> Fibonacci(int fibCount)
        {
            for (int i = 0, prevFib = 1, curFib = 1; i < fibCount; i++)
            {
                yield return prevFib;   //A yield return statement expresses “Here’s the next element you asked me to yield from this enumerator.”
                //On each yield statement, control is returned to the caller (the RunEnumeration() loop), but the callee’s (this method, Fibonacci)
                //state is maintained so that the method can continue executing as soon as the caller enumerates the next element. 
                //The lifetime of this state is bound to the enumerator (caller for loop), such that the state can be released when the caller has finished enumerating.
                int newFib = prevFib + curFib;
                prevFib = curFib;
                curFib = newFib;
            }
        }

        static IEnumerable<string> GetLines(bool breakEarly = false)
        {
            yield return "One";
            yield return "Two";
            if (breakEarly)
                yield break;    //The yield break statement indicates that the iterator block should exit early, without returning more elements. 
                                //A return statement is illegal in an iterator block.
            yield return "Three";
        }

        static IEnumerable<int> EvenNumbersOnly(IEnumerable<int> sequence)
        {
            foreach (int x in sequence)
                if ((x % 2) == 0)
                    yield return x;
        }
    }
}
