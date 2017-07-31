using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Ch4_CollectionsAndGenerics
{
    //Generic Collections:Generic types exist for most of the collection classes. See region below for 
    //lists the types, along with a mapping to their generic type equivalents.
    #region Collection Types and their Generic Equivalents
            //Table 4-20 Equivalent Generic Types

            //Type                  Generic Type
            //ArrayList             List<>
            //Queue                 Queue<>
            //Stack                 Stack<>
            //Hashtable             Dictionary<>
            //SortedList            SortedList<>
            //ListDictionary        Dictionary<>
            //HybridDictionary      Dictionary<>
            //OrderedDictionary     Dictionary<>
            //SortedDictionary      SortedDictionary<>
            //NameValueCollection   Dictionary<>
            //DictionaryEntry       NameValuePair<>
            //StringCollection      List<String>
            //StringDictionary      Dictionary<String>
            //N/A                   LinkedList<>
    #endregion
    public class GenericCollections
    {
        public static void Display()
        {
            //The generic List class is as simple to use as the ArrayList, but type-safe based on the
            //generic type parameter.
            Console.WriteLine("\n Generic List<> class...");
            List<int> intList = new List<int>();
            intList.Add(24);
            intList.Add(108);
            intList.Add(12);
            int number = intList[0];
            CollectionDisplay.DisplayCollection(intList);

            //Given below is a generic queue class.
            Queue<String> que = new Queue<String>();
            que.Enqueue("Hello");
            String queued = que.Dequeue();
            Console.WriteLine("Dequeued:" + queued);

            //Given below is a Dictionary class (equivalent to HashTable, ListDictionary and HybridDictionary classes
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict[3] = "Three";
            dict[4] = "Four";
            dict[1] = "One";
            dict[2] = "Two";
            String str = dict[3];
            Console.WriteLine("\nContents if the Dictionary is:");
            foreach (KeyValuePair<int, string> kvp in dict)
            {
                Console.WriteLine(kvp.Value);
            }

            //Given below is a SortedList class. Both SortedList and SortedDictionary 
            //maintain its items sorted by the key of the collection.
            SortedList<string, int> sortList = new SortedList<string, int>();
            sortList["One"] = 1;
            sortList["Two"] = 2;
            sortList["Three"] = 3;
            Console.WriteLine("\nContents if the SortedList is:");
            foreach (KeyValuePair<string, int> i in sortList)
            {
                Console.WriteLine(i);
            }

            //Given below is a SortedDictionary class.
            SortedDictionary<string, int> sortedDict = new SortedDictionary<string, int>();
            sortedDict["One"] = 1;
            sortedDict["Two"] = 2;
            sortedDict["Three"] = 3;
            Console.WriteLine("\nContents if the SortedDictionary is:");
            foreach (KeyValuePair<string, int> i in sortedDict)
            {
                Console.WriteLine(i);
            }

            //Given below is a LinkedList class.
            LinkedList<String> links = new LinkedList<string>();
            LinkedListNode<string> first = links.AddLast("First");
            LinkedListNode<string> last = links.AddFirst("Last");
            LinkedListNode<string> second = links.AddBefore(last, "Second");
            links.AddAfter(second, "Third");
            Console.WriteLine("\nContents if the LinkedList is:");
            foreach (string s in links)
            {
                Console.WriteLine(s);
            }

        }
    }
}
