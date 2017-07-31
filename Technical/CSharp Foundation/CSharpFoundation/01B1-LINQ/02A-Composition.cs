using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    public class _02A_Composition
    {
        public static void RunComposition()
        {
            //Composition Strategies   
            //----------------------
            //There are three strategies for building more complex queries:
            string[] names = { "David Zukerberg", "Roger Waters", "Rick Sen" };

            //Progressive query construction
            //----------------------
            //For example: We could build a fluent query progressively:            
            var filtered =  names.Where(n => n.Contains("a"));
            var sorted =    filtered.OrderBy(n => n);
            var query =     sorted.Select(n => n.ToUpper());
            //There are a couple of potential benefits, however, to building queries progressively:
            //    • It can make queries easier to write.
            //    • You can add query operators conditionally.
            //A progressive approach is often useful in query comprehensions (means understanding). For example: 
            //The following query removes all vowels from a list of names, and then presents in alphabetical order those 
            //whose length is more than two characters.
            IEnumerable<string> query1 = names.Select(n => n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", ""))
                                                .Where(n => n.Length > 2)
                                                .OrderBy(n => n); //Here we are projecting (Select) before we filter (Where):
            query1.ConsolePrint();
            //Translating this directly into a query expression is troublesome because the select clause must come after the where and orderby clauses.
            //But we can query this progressively as:
            IEnumerable<string> query2 = from n in names
                                            select n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "");
                                query2 = from n in query   
                                            where n.Length > 2 
                                            orderby n select n;
            query2.ConsolePrint();

            //The into Keyword
            //----------------
            //The into keyword lets you “continue” a query after a projection and is a shortcut for progressively querying.
            IEnumerable<string> query3 = from n in names
                                            select n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "")
                                                into noVowel
                                                where noVowel.Length > 2
                                                orderby noVowel
                                                select noVowel;
            //The only place you can use into is after a select or group clause. Also all query variables (example 'n') are out of scope following an into keyword.

            //Wrapping Queries
            //----------------
            //A query built progressively can be formulated into a single statement by wrapping one query around another. For example:
            IEnumerable<string> query4 = from n1 in
                                                (
                                                    from n2 in names
                                                    select n2.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "")
                                                )
                                            where n1.Length > 2
                                            orderby n1
                                            select n1;

            //When converted to fluent syntax will look similar to query1 as above.
        }
    }
}
