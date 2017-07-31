using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    partial class Program
    {
        static void RunMain01(string[] args)
        {
            _01A_Delegates.RunSimpleDelegate();
            _01A_Delegates.RunMulticastDelegate();
            _01A_Delegates.RunInstanceDelegate();

            Console.WriteLine("*--------\n");
            _01B_Delegates.RunFuncDelegate();

            Console.WriteLine("*--------\n");
            _01C_Events.EvenNumberGenerator enGenerator = new _01C_Events.EvenNumberGenerator();
            enGenerator.OnEvenNumberFound += new _01C_Events.EvenNumberGenerator.EvenNumberFoundHandler(enGenerator_OnEvenNumberFound);
            enGenerator.RunGenerateRandomNumbers();

            Console.WriteLine("*--------\n");
            _01C_Events_1.OddNumberGenerator oddGenerator = new _01C_Events_1.OddNumberGenerator();
            oddGenerator.OddNumberFoundEvent += new EventHandler<_01C_Events_1.OddNumberEventArgs>(oddGenerator_OddNumberFoundEvent);
            oddGenerator.RunGenerateRandomNumbers();

            Console.WriteLine("*--------\n");
            CSharpFoundation._01C_Events_1.EventAccessorDemo.RunEventAccessorDemo();

            Console.WriteLine("*--------RunLamda-----\n");
            _01E_LambdaExpressions.RunLamda();

            Console.WriteLine("*--------RunAnonymous-----\n");
            _01F_AnonymousMethods.RunAnonymous();

            Console.WriteLine("*--------RunEnumeration-----\n");
            _02AEnumerations.RunEnumeration();

            Console.WriteLine("*--------AnonymousTypes-----\n");
            _02B_AnonymousTypes.RunAnonymousTypes();

            Console.WriteLine("*--------RunDynamicBinding-----\n");
            _02C_DynamicBinding.RunDynamicBinding();

            Console.WriteLine("*--------RunAttributes-----\n");
            _03A_Attributes.RunAttributes();

            Console.WriteLine("*--------RunExtensionMethods-----\n");
            _03B_ExtensionMethods.RunExtensionMethods();

            Console.WriteLine("*--------PreprocessingDirectives-----\n");
            _03C_PreprocessingDirectives.RunPreprocessingDirectives();
        }

        static void oddGenerator_OddNumberFoundEvent(object sender, _01C_Events_1.OddNumberEventArgs e)
        {
            Console.WriteLine("Generated Number: " + e.OddNumber.ToString());
        }

        static void enGenerator_OnEvenNumberFound(object sender, CSharpFoundation._01C_Events.EvenNumberEventArgs e)
        {
            Console.WriteLine("Generated Number: " + e.EvenNumber.ToString());
        }
    }
}
