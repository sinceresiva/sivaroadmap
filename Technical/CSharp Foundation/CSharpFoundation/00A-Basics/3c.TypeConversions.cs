using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter1
{
    //This program demonstrates Implicit and Explicit conversions
    //and widening and narrowing conversions.
    struct TypeA
    {
        public int Value;

        // Allows implicit conversion from an integer.
        public static implicit operator TypeA(int arg)
        {
            TypeA res = new TypeA();
            res.Value = arg;
            return res;
        }

        // Allows explicit conversion to an integer
        public static explicit operator int(TypeA arg)
        {
            return arg.Value;
        }

        // Provides string conversion (avoids boxing).
        public override string ToString()
        {
            return this.Value.ToString();
        }
    }

    public class TypeConversions
    {
        public static void Display()
        {
            Console.WriteLine("\n****TypeConversions");

            TypeA a; 
            int i;
            
            // Widening conversion is OK implicit.
            a = 42; // Rather than a.Value = 42

            // Narrowing conversion must be explicit.
            i = (int)a; // Rather than i = a.Value

            Console.WriteLine("a = {0}, i = {0}", a.ToString(), i.ToString());
        }
    }
}
