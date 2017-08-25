//Preprocessor directives
//Preprocessor directives supply the compiler with additional information about regions of code. 
//The most common preprocessor directives are the conditional directives, which provide a way to include 
//or exclude regions of code from compilation.
#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace CSharpFoundation
{
    
    public class _03C_PreprocessingDirectives
    {
        [Conditional("DEBUG")]    //Conditional attribute will be compiled only if a given preprocessor symbol is present. 
        public static void RunPreprocessingDirectives()
        {
#if DEBUG
            Console.WriteLine("RunPreprocessingDirectives");
#else
            Console.WriteLine("Not RunPreprocessingDirectives");
#endif
        }
    }
}
