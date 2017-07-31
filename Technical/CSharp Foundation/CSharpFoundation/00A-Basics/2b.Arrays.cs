using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter1
{
    //Demonstrates the use of Arrays.
    public class Arrays
    {
        public static void Display()
        {
            Console.WriteLine("\n****Arrays*****");

            //Sorting an array
            int[] integerArray = new int[] { 3,1,5};
            Array.Sort(integerArray);
            Console.WriteLine("{0},{1},{2}", integerArray[0], integerArray[1], integerArray[2]);

            //Let us work with value&reference types and arrays
            SByte a = 0;
            Byte b = 0;
            Int16 c = 0;
            Int32 d = 0;
            Int64 e = 0;
            string str = "";
            Exception ex = new Exception();

            //Instantiate an object array
            object[] types = { a, b, c, d, e, str, ex };

            // Loop thru and display them
            foreach (object o in types)
            {
                string type;
                if (o.GetType().IsValueType)
                    type = "Value type";
                else
                    type = "Reference Type";
                Console.WriteLine("{0}: {1}", o.GetType(), type);
            }

            //Let us work with strings and arrays
            string s = "Microsoft .NET Framework 2.0 Application Development Foundation";
            string[] sa = s.Split(' ');

            //Sort the array
            Array.Sort(sa);

            //Join the array
            s = string.Join(" ", sa);
            Console.WriteLine(s);


        }
    }
}
