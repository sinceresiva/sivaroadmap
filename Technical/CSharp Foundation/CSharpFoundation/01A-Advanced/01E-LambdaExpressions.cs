using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    public class _01E_LambdaExpressions
    {
        /*
        Lambda Expressions
         *  A lambda expression is an unnamed method written in place of a delegate instance.
            The compiler immediately converts the lambda expression to either:
            • A delegate instance.
            • An expression tree.
         * 
         *  A lambda expression has the following form:
            (parameters) => expression-or-statement-block
         * 
         *  Each parameter of the lambda expression corresponds to a delegate parameter, and
            the type of the expression (which may be void) corresponds to the return type of the
            delegate.
         */
        //Given the following delegate type:
        delegate int Transformer (int i);
         
        public static void RunLamda()
        {
            //We could assign and invoke the lambda expression p => p * p as follows:
            Transformer tr = (p => p * p);
            Console.WriteLine(tr(2).ToString());

            //A lambda expression’s code can be a statement block instead of an expression
            Transformer tr1 = (p => { return p * p * p; });
            Console.WriteLine(tr1(2).ToString());

            //Lambda expressions are used most commonly with the Func and Action delegates as:
            Action<string, string> myAction = (s1, s2) => { Console.WriteLine(String.Concat(s1," ", s2)); };
            myAction("Siva","Kumar");

            Func<int, int> cube = (p=>p*p*p);
            Console.WriteLine(cube(3).ToString());

            //Here’s an example of an expression that accepts two parameters:
            Func<string, string, int> stringLength = (s1, s2) => s1.Length + s2.Length;
            Console.WriteLine(stringLength("Siva", "DotNet").ToString());

            //We can also specify the type of each parameter explicitly as:
            Func<int, int> cube1 = ((int p) => p * p * p);
            Console.WriteLine(cube1(4).ToString());

            //Capturing Outer Variables
            //A lambda expression can reference the local variables and parameters of the method
            //in which it’s defined (outer variables).Outer variables referenced by a lambda expression are 
            //called captured variables. A lambda expression that captures variables is called a closure.
            int factor = 2;
            Func<int, int> multiplier = n => n * factor;
            Console.WriteLine(multiplier(3));   // 6            

            //In the following example, the local variable "seed" would ordinarily disappear from scope when
            //Natural finished executing. But because seed has been captured, its lifetime is extended
            //to that of the capturing delegate, natural:
            Func<int> natural = Natural(); //Natural is declared below;
            Console.WriteLine(natural()); // 0
            Console.WriteLine(natural()); // 1
        }

        static Func<int> Natural()
        {
            int seed = 0;
            return () => seed++; // Returns a closure
        }


    }
}
