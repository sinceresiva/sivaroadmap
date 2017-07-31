using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace CSharpFoundation
{
    public class _02C_DynamicBinding
    {
        public static void RunDynamicBinding()
        {
            //Static Binding: 
            //For example: Let’s suppose the static type of d is Duck:
            //Duck d = new Duck();
            //d.Quack();
            //In the simplest case, the compiler does the binding by looking for a parameterless method named Quack on Duck. 
            //Failing that, the compiler extends its search to methods taking optional parameters, methods on base classes of Duck, and extension
            //methods that take Duck as its first parameter. If no match is found, you’ll get a compilation error. This makes it static binding.

            //Dynamic Binding
            //A dynamic type lets us use an object reference in ways that aren’t known at compile time. A dynamic object binds at 
            //runtime based on its runtime type, not its compile-time type. When the compiler sees a dynamically bound expression 
            //(which in general is an expression that contains any value of type dynamic), it merely packages up the expression such
            //that the binding can be done later at runtime. Hence in the below statement, we don't know what object is returned by GetObject(); hence we use dynamic.
            dynamic d = GetObject();
            Console.WriteLine("Breed is " + d.Breed);

            //The below call is used for Custom Binding (see below).
            dynamic camel = new Camel();
            camel.Walk(); //Remember, we have not defined Walk() method in Camel.Instead, it uses custom binding to intercept and interpret all method calls.

            //RuntimeBinderException: If a member fails to bind, a RuntimeBinderException is thrown.

            //Runtime Representation of Dynamic: 
            //Like an object reference, a dynamic reference can point to an object of any type
            dynamic x = "hello";
            Console.WriteLine(x.GetType().Name); // String
            x = 123; // No error (despite same variable)
            Console.WriteLine(x.GetType().Name); // Int32

            //Dynamic Conversions:For a conversion to succeed, the runtime type of the dynamic object must be implicitly 
            //convertible to the target static type.
            int i = 7;
            dynamic d1 = i;
            int j = d1; // No cast required (implicit conversion). If i was declared as long, then it throws a RuntimeBinderException here.
            Console.WriteLine(j.ToString());

            //var Versus dynamic
            //The var and dynamic types bear a superficial resemblance, but the difference is deep:
            //    • var says, “Let the compiler figure out the type.”
            //    • dynamic says, “Let the runtime figure out the type.”
            //  dynamic x = "hello"; // Static type is dynamic, runtime type is string
            //  var y = "hello"; // Static type is string, runtime type is string
            //  int i = x; // Runtime error
            //  int j = y; // Compile-time error
        }

        private static object GetObject()
        {
            return new Hen{Breed = "Fatty"};
        }

        //Custom Binding: Custom binding occurs when a dynamic object implements IDynamicMetaObjectProvider (IDMOP) and is used to refer
        //objects returned from other dynamically typed languages (IronRuby, Python) having IDMOP objects. A C# version if IDMOP is given below;
        public class Camel : DynamicObject //DynamicObject implements IDynamicMetaObjectProvider
        {
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
            {
                Console.WriteLine(binder.Name + " method was called");
                result = null;
                return true;
            }
        }
    }

    internal class Hen
    {
        public string Breed { get; set; }        
    }
}
