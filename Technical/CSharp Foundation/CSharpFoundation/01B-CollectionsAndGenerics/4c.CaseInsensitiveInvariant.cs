using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;

namespace Ch4_CollectionsAndGenerics
{
    //This program demonstrates creation of a localizable lookup table that is case insensitive and culture invariant.
    //Invariant culture means: Current thread's culture is not relevant.
    public class CaseInsensitiveInvariant
    {
        public static void Display()
        {
            // Make the dictionary case insensitive
            ListDictionary list = new ListDictionary(new CaseInsensitiveComparer(CultureInfo.InvariantCulture));
            
            // Add some items
            list["Estados Unidos"] = "United States of America";
            list["Canadá"] = "Canada";
            list["España"] = "Spain";

            // Show the results
            Console.WriteLine("\n CaseInsensitiveInvariant class...");
            Console.WriteLine(list["españa"]);
            Console.WriteLine(list["CANADÁ"]);            
        }
    }    
}
