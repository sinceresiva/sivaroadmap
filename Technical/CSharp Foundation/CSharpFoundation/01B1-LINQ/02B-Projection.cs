using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    public class _02B_Projection
    {
        internal class ProjectionItem
        {
            public string Original; // Original name
            public string Vowelless; // Vowel-stripped name
        }

        public static void RunProjection()
        {
            //Projection Strategies   
            //----------------------
            //There are three strategies for projecting queries:
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            //Object Initializers
            //----------------------
            //So far, all our select clauses have projected scalar element types. With C# object initializers, you can project into more complex types.
            //For example, suppose, as a first step in a query, we want to strip vowels from a list of names while still retaining
            //the original versions alongside, for the benefit of subsequent queries.
            IEnumerable<ProjectionItem> tempQuery = from n in names
                                                    select new ProjectionItem
                                                    {
                                                        Original = n,
                                                        Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "")
                                                                        .Replace("o", "").Replace("u", "")
                                                    };
            //The result is of type IEnumerable<TempProjectionItem>, which we can subsequently query:
            IEnumerable<string> query = from item in tempQuery
                                            where item.Vowelless.Length > 2
                                            select item.Original;
            query.ConsolePrint();

            //Anonymous Types
            //---------------
            //Anonymous types allow you to structure your intermediate results without writing special classes.
            //We can eliminate the TempProjectionItem class in our previous example with anonymous types:
            var intermediate = from n in names
                               select new
                               {
                                   Original = n,
                                   Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "")
                                   .Replace("o", "").Replace("u", "")
                               };
            IEnumerable<string> query2 = from item in intermediate
                                        where item.Vowelless.Length > 2
                                        select item.Original;
            query2.ConsolePrint();

            //The let Keyword
            //---------------
            //The let keyword introduces a new variable alongside the range variable.
            //With let, we can write a query extracting strings whose length, excluding vowels,
            //exceeds two characters, as follows:
            IEnumerable<string> query3 =    from n in names
                                            let vowelless = n.Replace ("a", "").Replace ("e", "").Replace ("i", "").Replace ("o", "").Replace ("u", "")
                                            where vowelless.Length > 2
                                            orderby vowelless
                                            select n; // Thanks to let, n is still in scope.
            query3.ConsolePrint();
            //let accomplishes two things:
                //• It projects new elements alongside existing elements.
                //• It allows an expression to be used repeatedly in a query without being rewritten.
            //The let approach is particularly advantageous in this example, because it allows the
            //select clause to project either the original name (n) or its vowel-removed version (vowelless).
            //You can have any number of let statements, before or after a where statement
            //A let statement can reference variables introduced in earlier let statements (subject to the boundaries imposed by an into clause).
        }
    }
}
