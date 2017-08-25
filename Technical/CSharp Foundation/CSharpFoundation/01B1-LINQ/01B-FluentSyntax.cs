using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    public class _01B_FluentSyntax
    {
        public static void RunFluentSyntax()
        {
            //Fluent Syntax
            //Fluent syntax is the most flexible and fundamental. Here we chain query operators to form more complex queries as:
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> namesInUppercase = names
            .Where(n => n.Contains("a"))    //Emits a filtered version of the input sequence.
            .OrderBy(n => n.Length)         //Emits a sorted version of its input sequence
            .Select(n => n.ToUpper());      //Emits a sequence where each input element is transformed or projected with a given lambda expression
            //Important: When query operators are chained as in this example, the output sequence of one operator is the input sequence of the next.

            namesInUppercase.ConsolePrint(); //We have defined this extension method at (Program02.cs)
            //Why extension methods are important: The extension method syntax gives the query a natural linear shape that reflects the left-to-right flow of data.
            //Without extension methods, the query loses its fluency as:
            //IEnumerable<string> query =
            //    Enumerable.Select(
            //      Enumerable.OrderBy(
            //          Enumerable.Where(
            //          names, n => n.Contains("a")
            //          ), n => n.Length
            //      ), n => n.ToUpper()
            //    );

            //Composing Lambda Expressions
            //Note: An expression returning a bool value is called a predicate.
            /*
             * Lambda expressions and Func signatures
             * The standard query operators utilize generic Func delegates. Hence, Func<TSource,bool> matches a TSource=>bool lambda expression: one that
                accepts a TSource argument and returns a bool value.
             * 
             * Lambda expressions and element typing - VERY IMPORTANT.
             * The standard query operators use the following generic type names:
                Generic type letter                         Meaning
                TSource                         Element type for the input sequence
                TResult                         Element type for the output sequence—if different from TSource
                TKey                            Element type for the key used in sorting, grouping, or joining
             * 
             * For example, consider the signature of the Select query operator:
                    public static IEnumerable<TResult> Select<TSource,TResult> (this IEnumerable<TSource> source, Func<TSource,TResult> selector).
             *      Here Func<TSource,TResult> matches a TSource=>TResult lambda expression: one that maps an input element to an output element.
             *      The compiler infers the type of TResult from the return value of the lambda expression.
             *      
             * Now consider the signature of the OrderBy operator:
                    public static IEnumerable<TSource> OrderBy<TSource,TKey>(this IEnumerable<TSource> source, Func<TSource,TKey> keySelector).
             *      Here Func<TSource,TKey> maps an input element to a sorting key. TKey is inferred from your lambda expression and 
             *      is separate from the input and output element types.
            */

            /*
             *  Natural Ordering: The original ordering of elements within an input sequence is significant in LINQ.
                Some query operators rely on this behavior, such as Take, Skip, and Reverse as:
             * */
            int[] numbers = { 10, 9, 8, 7, 6 };
            
            IEnumerable<int> firstThree = numbers.Take(3); //   Outputs the first x elements: { 10, 9, 8 }
            firstThree.ConsolePrint(); //We have defined this extension method at (Program02.cs)

            IEnumerable<int> lastTwo = numbers.Skip(2); //Ignores the first 2 elements and outputs the rest: { 7, 6 }
            lastTwo.ConsolePrint();

            IEnumerable<int> reversed = numbers.Reverse(); // Reverses the sequence:  { 6, 7, 8, 9, 10 }
            reversed.ConsolePrint();

            //Other Operators
            //Not all query operators return a sequence.

            //The element operators extract one element from the input sequence;
            int firstNumber = numbers.First(); // 10
            int lastNumber = numbers.Last(); // 6
            int secondNumber = numbers.ElementAt(1); // 9
            int lowestNumber = numbers.OrderBy(n => n).First(); // 6
            int secondHighest = numbers.OrderBy(n => n).Reverse().ElementAt(1); //9
            Console.WriteLine("Second Highest is : " + secondHighest.ToString());

            //The aggregation operators return a scalar value;
            int count = numbers.Count(); // 5;
            int min = numbers.Min(); // 6;

            //The quantifiers return a bool value:
            bool hasTheNumberNine = numbers.Contains (9); // true
            bool hasMoreThanZeroElements = numbers.Any(); // true
            bool hasAnOddElement = numbers.Any (n => n % 2 == 1); // true

            //Some query operators accept two input sequences.
            int[] seq1 = { 1, 2, 3 };
            int[] seq2 = { 3, 4, 5 };
            IEnumerable<int> concat = seq1.Concat(seq2); // Appends one sequence to another : { 1, 2, 3, 3, 4, 5 } 
            IEnumerable<int> union = seq1.Union(seq2); // // Appends one sequence to another with duplicates removed: : { 1, 2, 3, 4, 5 }
        }
    }
}
