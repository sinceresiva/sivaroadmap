using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    public class _01C_DefExecution
    {
        public static void RunDefExecution()
        {
            //Deferred Execution
            //An important feature of most query operators is that they execute not when constructed, but when enumerated 
            //(in other words, when MoveNext is called on its enumerator).
            var names = new List<string> { "Sunil", "Saurav" };
            names.Add("Srikkanth");
            IEnumerable<string> query = names.Where(n=>n.Contains("a"));
            names.Add("Siva");          // Sneak in an extra element
            foreach (string n in query)
                Console.Write(n + "|"); //Saurav|Srikkanth|Siva|

            //All standard query operators provide deferred execution, with the following exceptions:
            //• Operators that return a single element or scalar value, such as First or Count
            //• The following conversion operators: ToArray, ToList, ToDictionary, ToLookup
            //These operators cause immediate query execution because their result types have no mechanism for providing deferred execution.
            //The Count method, for instance, returns a simple integer, which then doesn’t get enumerated.
            var count = names.Where(n => n.Contains("kk")).Count();
            Console.WriteLine(count);

            //Reevaluation: Deferred execution has another consequence: a deferred execution query is reevaluated when you re-enumerate:
            //For example:
            names.Remove("Siva");
            foreach (string n in query) //Now query will be reevaluated.
                Console.Write(n + "|"); //Saurav|Srikkanth
            //You can defeat reevaluation by calling a conversion operator, such as ToArray or ToList.

            //Captured Variables: If your query’s lambda expressions reference local variables, these variables are subject to captured variable semantics.
            int[] numbers = { 1, 2 };
            int factor = 10;
            IEnumerable<int> query1 = numbers.Select(n => n * factor);
            factor = 20;
            foreach (int n in query1) 
                Console.Write(n + "|"); // 20|40|

            //How Deferred Execution Works: Query operators provide deferred execution by returning decorator sequences. Unlike a traditional 
            //collection class such as an array or linked list, a decorator sequence (in general) has no backing structure of its own to store elements. 
            //Instead, it wraps another sequence that you supply at runtime, to which it maintains a permanent dependency. Whenever you request data 
            //from a decorator, it in turn must request data from the wrapped input sequence.

            //How Queries Are Executed: See section in book.
            
        }
    }
}
