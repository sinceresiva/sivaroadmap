using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Xml.Serialization;

namespace CSharpFoundation
{
    public class _03A_Attributes
    {
        //Attributes
        //Attributes are an extensible mechanism for adding metadata (custom information) to code elements
        //(assemblies, types, members, return values, and parameters).

        //Attribute Classes
        //An attribute is defined by a class that inherits (directly or indirectly) from the abstract
        //class System.Attribute. For example, the following attaches the ObsoleteAttribute to SomeMethod:
        [ObsoleteAttribute]
        public static void SomeMethod() //Calling this method causes compiler warnings.
        {
            Console.WriteLine("SomeMethod");
        }

        //Attribute parameters fall into one of two categories: positional or named. In the
        //following example, the first argument is a positional parameter; the second is a
        //named parameter.
        public class CustomerEntity
        {
            [XmlElement("CustomerCode", Namespace = "http://oreilly.com")]
            public string CusotmerID { get; set; }
        }

        //Here is an example of using the CLSCompliant attribute to specify CLS compliance
        //for an entire assembly:
        //[assembly:CLSCompliant(true)]

        //Custom Attributes. We can define our own attributes by deriving from System.Attribute. See Below;
        [AttributeUsage(AttributeTargets.Class,AllowMultiple=true,Inherited=false)]
        public class MyAttribute : Attribute
        {
            //The above AttributeUsage attribute specifies to the compiler that this attribute can be specified only
            //for a class and we are allowed to have multiple 'MyAttribute' attributes specified for a class. Also it is not
            //inherited for sub classes.
            public int MyProperty { get; set; }            
        }

        //Now let us decorate a sample class with MyAttribute.Because AllowMultiple=true, we can specify more than once.
        [MyAttribute(MyProperty = 1)]
        [MyAttribute(MyProperty = 2)]
        public class MyEmployee
        {
            public void Write() { Console.WriteLine("Hi"); }

            //Do some refection and print all MyAttribute attributes.
            public void GetAttributeValue()
            {
                foreach (object attrib in typeof(MyEmployee).GetCustomAttributes(typeof(MyAttribute), false))
                {
                    if (attrib is MyAttribute)
                    {
                        Console.WriteLine("Custom Attribute:" + (attrib as MyAttribute).MyProperty.ToString());
                    }
                }
            }
        }

        public static void RunAttributes()
        {
            SomeMethod();
            new MyEmployee().Write();
            new MyEmployee().GetAttributeValue();
        }


        
    }
}
