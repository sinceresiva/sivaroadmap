using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Ch4_CollectionsAndGenerics
{
    //Dictionaries: This program demonstrates the use of the Dictionary class.
    //The Dictionary classes supported by the .NET Framework are used to map a key to a
    //value. Essentially, they exist to allow you to create lookup tables that can map arbitrary
    //keys to arbitrary values.
    //Note: All dictionary classes (including the Hashtable) support the IDictionary interface. The
    //IDictionary interface derives from the ICollection interface.
    public class DictionaryClass
    {
        public static void Display()
        {
            Console.WriteLine("\n Dictionary Operations...");

            //In the most basic case, the Hashtable class is used to do
            //this mapping of key/value pairs.
            Hashtable emailLookup = new Hashtable();

            // Add method takes a key (first parameter)
            // and a value (second parameter)
            emailLookup.Add("sbishop@contoso.com", "Bishop, Scott");

            // The indexer is functionally equivalent to Add
            emailLookup["sram@f1r100.com"] = "S, Ram";

            //Loop through and display the entries
            foreach (DictionaryEntry entry in emailLookup)
            {
                Console.WriteLine(entry.Value);
            }

            //The Hashtable allows only unique hashes of values, not unique values. If
            //you try to store the same key twice, the second call replaces the first call,
            Hashtable duplicates = new Hashtable();
            duplicates["First"] = "1st";
            duplicates["First"] = "the first";
            Console.WriteLine("duplicates count:" + duplicates.Count);

            //If we create two instance of the Car class (below) with the same name, the Hashtable
            //treats them as different objects because the Object class’s implementation
            //of GetHashCode creates a hash that is likely to be unique for each instance of a class.
            Hashtable duplicateCars = new Hashtable();
            Car key1 = new Car();
            Car key2 = new Car();
            duplicateCars[key1] = "Santro";
            duplicateCars[key2] = "Santro";
            Console.WriteLine("duplicate cars count:" + duplicateCars.Count);

            //IEqualityComparer Interface: assume that you want to store keys in the Hashtable 
            //as strings but need to ignore the case of the string. Changing the string class to support 
            //this or creating your own String class that is case insensitive would be a painful solution.
            //The Hashtable class supports a constructor that can accept an instance of the IEquality-Comparer class 
            //as an argument for this purpose.
            Hashtable dehash = new Hashtable(new InsensitiveComparer());
            dehash["First"] = "1st";
            dehash["Second"] = "2nd";
            dehash["Third"] = "3rd";
            dehash["Fourth"] = "4th";
            dehash["fourth"] = "4th";
            Console.WriteLine("dehash count: " + dehash.Count); // Displays 4 in this case


        }
    }
    public class InsensitiveComparer : IEqualityComparer
    {
        //The CaseInsensitiveComparer from System.Collections is used here.
        CaseInsensitiveComparer _comparer = new CaseInsensitiveComparer();
        public int GetHashCode(object obj)
        {
            return obj.ToString().ToLowerInvariant().GetHashCode();
        }
        public new bool Equals(object x, object y)
        {
            if (_comparer.Compare(x, y) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}