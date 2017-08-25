using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Chapter2
{
    public class RegularExps
    {
        //Demonstrates the use of File System classes in System.IO namespace.
        public static void Display()
        {
            Console.WriteLine("/n***********Regular Exps***********");
            string inputString1 = "1234";
            string inputString2 = "12345";

            string regExpString = @"^\d{5}$";

            if (Regex.IsMatch(inputString1, regExpString))
                Console.WriteLine("Match for inputString1  found!!!");

            if (Regex.IsMatch(inputString2, regExpString))
                Console.WriteLine("Match for inputString2 found!!!");

        }
    }
}
