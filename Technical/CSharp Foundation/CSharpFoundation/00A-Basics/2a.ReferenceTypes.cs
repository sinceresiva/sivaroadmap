using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter1
{
    //This program demonstrates the use of Reference Types.
    public class ReferenceTypes
    {
        public static void Display()
        {
            Console.WriteLine("\n****ReferenceTypes*****");

            //String is a reference type
            string s = "This is a string to search";
            s=s.Replace("search", "replace");
            Console.WriteLine(s.ToString());

            //Strings are immutable - any change to the string causes the runtime to create a new one.
            string country = "India";
            country += " is my country.";
            Console.WriteLine(country.ToString());

            //We can use the String.Concat method instead.
            country = String.Concat(country, "It is a subcontinent.");
            Console.WriteLine(country.ToString());

            //Using the StringBuilder is more flexible.
            System.Text.StringBuilder sBuilder = new StringBuilder(country)
                .Append("Bound by Indian Ocean in the South.");
            Console.WriteLine(sBuilder.ToString());

            
        }
    }
}
