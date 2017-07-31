using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    //Extension Methods
    //Extension methods allow an existing type to be extended with new methods without altering the definition of the original type. 
    //An extension method is a static method of a static class, where the this modifier is applied to the first parameter.
    public static class StringHelper
    {
        //The below two are extension methods that extend the string type.
        public static bool IsCapitalized(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return char.IsUpper(s[0]);
        }

        public static string GetFirstCharacter(this string s)
        {
            if (String.IsNullOrEmpty(s)) return String.Empty;
            return s[0].ToString();
        }
        
        //Interfaces can be extended too: This is a very powerful feature.
        public static T First<T>(this IEnumerable<T> sequence)
        {
            foreach (T element in sequence)
                return element;
            throw new InvalidOperationException("No elements!");
        }

    }

    public class _03B_ExtensionMethods
    {
        public static void RunExtensionMethods()
        {
            //The IsCapitalized extension method can be called as though it were an instance
            //method on a string, as follows:
            Console.WriteLine("Chennai".IsCapitalized());

            Console.WriteLine("Bangalore".First()); // S

            //Extension methods, like instance methods, provide a tidy way to chain functions
            Console.WriteLine("mumbai".GetFirstCharacter().IsCapitalized()); // False

            //Ambiguity and Resolution
            //An extension method cannot be accessed unless the namespace is in scope. Hence to use the above IsCapitalized() elsewhere,
            //the following application must import the namespace CSharpFoundation.

            //Extension methods versus extension methods
            //If two extension methods have the same signature, the extension method must be
            //called as an ordinary static method to disambiguate the method to call. If one extension
            //method has more specific arguments, however, the more specific method
            //takes precedence.
        }
    }
}
