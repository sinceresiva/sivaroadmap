using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace Ch4_CollectionsAndGenerics
{
    //This program demonstrates String specific collections.
    //The .NET Framework supports two specialized collections
    //that are strongly typed to store strings: StringCollection and StringDictionary. 
    public class StringCollections
    {
        public static void Display()
        {
            Console.WriteLine("\n StringCollection...");
            //StringCollection: The StringCollection class is a simple dynamically sized collection (such as ArrayList) that
            //can only store strings.
            StringCollection coll = new StringCollection();
            coll.Add("First");
            coll.Add("Second");
            coll.Add("Third");
            coll.Add("Fourth");
            foreach (string s in coll)
            {
                Console.WriteLine("{0}",s);
            }

            Console.WriteLine("\n StringDictionary...");
            //StringDictionary: These are similar to Hashtable, except that both the keys and values must be strings.
            //The keys are case insensitive by default.
            StringDictionary dict = new StringDictionary();
            dict["First"] = "1st";
            dict["Second"] = "2nd";
            dict["Third"] = "3rd";
            dict["Fourth"] = "4th";
            foreach (string s in dict.Keys)
            {
                Console.WriteLine("{0}", dict[s]);
            }

            //The .NET Framework has a CollectionUtil class
            //that supports creating Hashtable and SortedList objects that are case insensitive.
            Console.WriteLine("\n CollectionUtil class...");
            Hashtable inTable = CollectionsUtil.CreateCaseInsensitiveHashtable();
            inTable["hello"] = "Hi";
            inTable["HELLO"] = "Heya";
            Console.WriteLine("CollectionsUtil: " + inTable.Count); // Prints 1

            //NameValueCollection Class: With the NameValueCollection class, you can store multiple values per key. You do this
            //with the Add method. To retrieve all the values for a particular key, you can use the
            //GetValues method.
            Console.WriteLine("\n NameValueCollection class...");
            NameValueCollection nvCollection = new NameValueCollection();
            nvCollection.Add("KeyString", "Some Text");
            nvCollection.Add("KeyString", "More Text");
            foreach (string s in nvCollection.GetValues("KeyString"))
            {
                Console.WriteLine(s);
            }

            // Here the Add method and the indexer have different behaviors.
            NameValueCollection nv = new NameValueCollection();
            nv["First"] = "1st";
            nv["First"] = "FIRST";
            nv.Add("Second", "2nd");
            nv.Add("Second", "SECOND");
            Console.WriteLine(nv.GetValues("First").Length); //Prints 1
            Console.WriteLine(nv.GetValues("Second").Length);//Prints 2

            //The other difference between using the NameValueCollection and the String-
            //Dictionary is that you can retrieve items by key index.
            NameValueCollection nv1 = new NameValueCollection();
            nv1.Add("First", "1st");
            nv1.Add("Second", "2nd");
            nv1.Add("Second", "Not First");
            for (int x = 0; x < nv1.Count; ++x)
            {
                Console.WriteLine(nv1[x]);
                // 1st
                // 2nd,Not First
            }
            
            

        }
    }    
}
