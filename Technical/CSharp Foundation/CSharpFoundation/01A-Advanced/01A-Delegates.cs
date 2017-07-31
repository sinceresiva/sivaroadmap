using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    public class _01A_Delegates
    {
        //Delegates
        //*********
        //A delegate dynamically wires up a method caller to its target method. There are two
        //aspects to a delegate: type and instance. A delegate type defines a protocol to which
        //the caller and target will conform, comprising a list of parameter types and a return
        //type. A delegate instance is an object that refers to one (or more) target methods
        //conforming to that protocol.

        //A delegate instance literally acts as a delegate for the caller: the caller invokes the
        //delegate, and then the delegate calls the target method. This indirection decouples
        //the caller from the target method.

        //A delegate type declaration is preceded by the keyword delegate as:
        delegate int Transformer(int x);

        public static void RunSimpleDelegate()
        {
            // Create delegate instance
            Transformer t = new Transformer(Square);
            // Invoke delegate
            int result = t(3); 
            Console.WriteLine(result); // 9

            //We can also directly refer to the method as:
            Transformer t1 = Square;
            Console.WriteLine(t1(6).ToString());
        }

        static int Square(int x) { return x * x; }

        //Multicast Delegates
        //All delegate instances have multicast capability. This means that a delegate instance
        //can reference not just a single target method, but also a list of target methods. 

        //Example Delegate and method
        public delegate void ProgressReporter(int percentComplete);
        //Note that the HardWork method takes a parameter of ProgressReporter delegate.
        public class Util
        {
            public static void HardWork(ProgressReporter p)
            {
                for (int i = 0; i < 4; i++)
                {
                    p(i * 25); // Invoke delegate. The Delegates are invoked in the order they are added.
                    System.Threading.Thread.Sleep(100); // Simulate hard work
                }
            }

        }

        public static void RunMulticastDelegate()
        {
            ProgressReporter p = null;
            //The + and += operators combine delegate instances.
            p += WriteProgressToConsole;
            p += WriteProgressToFile;
            Util.HardWork(p);
            //The − and −= operators remove the right delegate operand from the left delegate operand. 
            //For example:Invoking Util.HardWork(p) after the following line will cause 
            //only WriteProgressToConsole to be called.
            p -= WriteProgressToFile;
            Util.HardWork(p);
            //Note that calling −= on a delegate variable with a single target is equivalent to assigning
            //null to that variable.

            //Important: If a multicast delegate has a nonvoid return type, the caller receives the return value
            //from the last method to be invoked. The preceding methods are still called, but their
            //return values are discarded. In most scenarios in which multicast delegates are used,
            //they have void return types, so this subtlety does not arise.
        }

        static void WriteProgressToConsole(int percentComplete)
        {
            Console.WriteLine(percentComplete);
        }

        static void WriteProgressToFile(int percentComplete)
        {
            System.IO.File.WriteAllText("Progress.txt",
            percentComplete.ToString());
        }

        //Instance Versus Static Method Targets
        //When a delegate object is assigned to an instance method, the delegate object must maintain a reference 
        //not only to the method, but also to the instance to which the  method belongs.The System.Delegate class’s 
        //Target property represents this instance (and will be null for a delegate referencing a static method).
        //See InstanceDelegate() method.
        class ProgressManager
        {
            public void InstanceProgress(int percentComplete)
            {
                Console.WriteLine(percentComplete);
            }
        }

        public static void RunInstanceDelegate()
        {
            ProgressManager manager = new ProgressManager();
            ProgressReporter p = manager.InstanceProgress;
            p(99); // Will write 99 to console
            Console.WriteLine(p.Target == manager); // True
            Console.WriteLine(p.Method); // Void InstanceProgress(Int32)
        }

        //Generic Delegate Types
        //A delegate type may contain generic type parameters. For example:
        public delegate T TransformerDelegate<T> (T arg);
    }

}
