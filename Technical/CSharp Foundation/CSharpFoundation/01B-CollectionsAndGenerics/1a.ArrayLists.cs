using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Ch4_CollectionsAndGenerics
{
    //This program demonstrates the use of ArrayLists.
    //Note: It is important to understand that ArrayLists are lists meaning they implement the IList interface.
    //The inheritance hierarchy is like: IList derives from ICollection which in turn derives from IEnumerable.
    public class ArrayLists
    {
        public static void Display()
        {
            //Form the ArrayList. 
            ArrayList arrayList = new ArrayList();

            //Add individual items to the collection.
            //The Add and AddRange methods add items to the end of the collection.
            string s = "Hello";
            arrayList.Add(s);
            arrayList.Add("hi");
            arrayList.Add(50);
            arrayList.Add(new object());

            //The ArrayList supports the AddRange method to add a range of items, usually from an array 
            //or another collection.
            string[] anArray = new string[] { "more", "or", "less" };
            arrayList.AddRange(anArray);
            object[] anotherArray = new object[] { 99,100, new ArrayList() };
            arrayList.AddRange(anotherArray);

            //Display the ArrayList
            CollectionDisplay.DisplayCollection(arrayList);

            //They also support inserting objects into them at specific
            //positions using the Insert and InsertRange methods.
            arrayList.Insert(3, "Hey All");

            string[] moreStrings =
            new string[] { "goodnight", "see ya" };
            arrayList.InsertRange(4, moreStrings);

            //Display the ArrayList
            Console.WriteLine("\nAfter insertion ArrayList is:");
            CollectionDisplay.DisplayCollection(arrayList);

            //ArrayList supports removing items from the collection using Remove, RemoveAt, and RemoveRange methods
            arrayList.Remove(s);
            arrayList.RemoveAt(0);//Removes item at index 0.
            arrayList.RemoveRange(1,3);//Removes items at index 1 to 3.

            //Display the ArrayList
            Console.WriteLine("\nAfter removal ArrayList is:");
            CollectionDisplay.DisplayCollection(arrayList);

        }
    }

    public static class CollectionDisplay
    {
        public static void DisplayCollection(ICollection collection)
        {
            //The ArrayList also supports the IEnumerable interface to allow the use of an
            //Enumerator to access the list. The IEnumerable interface dictates that the class supports
            //the GetEnumerator method that returns an IEnumerator interface. In turn, the
            //IEnumerator interface provides a simple interface for iterating in a forward direction using
            //MoveNext() and Current.
            IEnumerator enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                object current = enumerator.Current;
                if (current is ICollection)
                    DisplayCollection(current as ICollection);
                Console.WriteLine(current.ToString());
            }
        }

        public static void DisplayCollection<T>(List<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine(item.ToString());
            }            
        }
    }
}
