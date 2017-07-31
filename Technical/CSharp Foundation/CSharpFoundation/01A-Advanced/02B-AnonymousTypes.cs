using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    public class _02B_AnonymousTypes
    {
        public static void RunAnonymousTypes()
        {
            //An anonymous type is a simple class created by the compiler on the fly to store a set
            //of values. To create an anonymous type, use the new keyword followed by an object
            //initializer, specifying the properties and values the type will contain. For example:
            var dude = new { Name = "Bob", Age = 1 }; //You must use the var keyword to reference an anonymous type, because the name 
                                                      //of the type is compiler-generated.
            Console.WriteLine(dude.Name);

            //The property name of an anonymous type can be inferred from an expression that is itself an identifier (or ends with one).
            int Age = 23;
            var dude1 = new { Name = "Bob", Age, Age.ToString().Length};
            Console.WriteLine(dude1.Age + ": " + dude1.Length);

            //Two anonymous type instances will have the same underlying type if their elements are same-typed and they’re declared within the same assembly:
            var a1 = new { X = 2, Y = 4 };
            var a2 = new { X = 2, Y = 4 };
            Console.WriteLine (a1.GetType() == a2.GetType()); // True
        }
    }
}
