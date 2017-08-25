using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace Ch4_CollectionsAndGenerics
{
    //Dictionaries: This program demonstrates the use of other Dictionary classes such as SortedList.
    public class OtherDictionaryClasses
    {
        public static void Display()
        {
            Console.WriteLine("\n Other Dictionary Operations...");
            Console.WriteLine("\n SortedList Operations...");

            //The SortedList is a dictionary class that supports sorting the items by key
            SortedList sortedList = new SortedList();
            sortedList["First"] = "1st";
            sortedList["Second"] = "2nd";
            sortedList["Third"] = "3rd";
            sortedList["Fourth"] = "4th";
            sortedList["fourth"] = "4th";
            foreach (DictionaryEntry entry in sortedList)
            {
                Console.WriteLine("{0} = {1}", entry.Key, entry.Value);
            }

            //Displays total number of currently allocated slots for items
            Console.WriteLine("The List Capacity is ", sortedList.Capacity.ToString());

            //ListDictionary class: For small collections (fewer than ten elements), use of the  Hashtable class 
            //can incur a bit of overhead that can slow down the performance. This is where we can use the ListDictionary class
            //which is very efficient for small collections of items.
            Console.WriteLine("\n ListDictionary Operations...");
            ListDictionary emailLookupListDictionary = new ListDictionary();
            emailLookupListDictionary["sbishop@contoso.com"] = "Bishop, Scott";
            emailLookupListDictionary["chess@contoso.com"] = "Hess, Christian";
            emailLookupListDictionary["djump@contoso.com"] = "Jump, Dan";
            foreach (DictionaryEntry entry in emailLookupListDictionary)
            {
                Console.WriteLine(entry.Value);
            }

            //HybridDictionary class: If you know your collection is small we can use a List-Dictionary; 
            //if your collection is large, use a Hashtable. But what if you just do not know
            //how large your collection is? That is where the HybridDictionary comes in.It is implemented
            //as a ListDictionary and only when the list becomes too large does it convert
            //itself into a Hashtable internally. The HybridDictionary is best used in situations where
            //some lists are small and others are very large.
            Console.WriteLine("\n HybridDictionary Operations...");
            HybridDictionary emailLookupHybridDictionary = new HybridDictionary();
            emailLookupHybridDictionary["sbishop@contoso.com"] = "Bishop, Scott";
            emailLookupHybridDictionary["chess@contoso.com"] = "Hess, Christian";
            emailLookupHybridDictionary["djump@contoso.com"] = "Jump, Dan";
            foreach (DictionaryEntry entry in emailLookupHybridDictionary)
            {
                Console.WriteLine(entry.Value);
            }

            //OrderedDictionary class:There are times when you want the functionality of the Hashtable but you need 
            //to control the order of the elements in the collection. Thus when you need a fast dictionary but also 
            //need to keep the items in an ordered fashion, the .NET Framework supports the OrderedDictionary.
            Console.WriteLine("\n OrderedDictionary Operations...");
            OrderedDictionary emailLookupOrderedDictionary = new OrderedDictionary();
            emailLookupOrderedDictionary["Jump@contoso.com"] = "Jump, Dan";
            emailLookupOrderedDictionary["Hess@contoso.com"] = "Hess, Christian";
            emailLookupOrderedDictionary["James@contoso.com"] = "James, Witherton";
            foreach (DictionaryEntry entry in emailLookupOrderedDictionary)
            {
                Console.WriteLine(entry.Value);
            }

            Console.WriteLine("\n Ater inserting, OrderedDictionary looks like...");
            //The advantage of the OrderedDictionary class is that we can control where the items are placed
            //with the help of the Insert and Remove methods. This is not possible with the HashTable...
            emailLookupOrderedDictionary.Insert(0,"CVRaman@Contoso.com","CV, Raman");
            foreach (DictionaryEntry entry in emailLookupOrderedDictionary)
            {
                Console.WriteLine(entry.Value);
            }

        }
    }
}