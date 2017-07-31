using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    partial class Program
    {
        static void RunMain02(string[] args)
        {
            Console.WriteLine("-----RunLINQIntro1-----");
            _01A_Intro1.RunLINQIntro1();
            Console.WriteLine("-----RunFluentSyntax-----");
            _01B_FluentSyntax.RunFluentSyntax();
            Console.WriteLine("-----QueryExpressionSyntax-----");
            _01C_QueryExpressions.RunQueryExpressions();
            Console.WriteLine("-----DefExecution-----");
            _01C_DefExecution.RunDefExecution();
            Console.WriteLine("-----Subqueries-----");
            _01E_Subqueries.RunSubqueries();
            Console.WriteLine("-----Composition-----");
            _02A_Composition.RunComposition();
            Console.WriteLine("-----Projection-----");
            _02B_Projection.RunProjection();
        }
    }

    public static class ConsolePrinter
    {
        public static void ConsolePrint(this IEnumerable<string> sequence)
        {
            foreach (string n in sequence)
                Console.WriteLine(n);
            Console.WriteLine("\n");
        }

        public static void ConsolePrint(this IEnumerable<int> sequence)
        {
            foreach (int n in sequence)
                Console.WriteLine(n);
            Console.WriteLine("\n");
        }
    }
    
}
