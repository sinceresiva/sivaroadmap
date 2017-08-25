using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    //Anonymous Methods
    //To write an anonymous method, you include the delegate keyword followed (optionally)
    //by a parameter declaration and then a method body. 
    
    public class _01F_AnonymousMethods
    {
        //For example, given this delegate:
        delegate int Transformer(int i);

        public static void RunAnonymous()
        {
            //We could write and call an anonymous method as follows:
            Transformer sqr = delegate (int x) {return x * x;};
            Console.WriteLine (sqr(3));

            //A unique feature of anonymous methods is that you can omit the parameter declaration
            //entirely—even if the delegate expects them as: OnClicked is declared below;
            OnClicked += delegate { Console.WriteLine("clicked"); }; // No parameters

            //Raise the event
            OnClicked(null, new EventArgs());
        }

        static event EventHandler OnClicked;
    }
}
