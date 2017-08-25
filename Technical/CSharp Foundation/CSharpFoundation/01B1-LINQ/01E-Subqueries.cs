using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    public class _01E_Subqueries
    {
        public static void RunSubqueries()
        {
            //Subqueries
            //A subquery is a query contained within another query’s lambda expression.
            string[] musos = { "David Zukerberg", "Roger Waters", "Rick Sen" };
            IEnumerable<string> query = musos.OrderBy(m => m.Split().Last());   //m.Split().Last is the subquery; "query" is the outer query.
            query.ConsolePrint();
            //A subquery is simply another C# expression. This means that the rules for subqueries are a consequence of the rules for lambda expressions

            //The next query retrieves all strings in an array whose length matches that of the shortest string:
            //Example in Fluent Syntax:
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay", "Joey" };
            IEnumerable<string> outerQuery = names.Where(
                                                            n => n.Length == names.OrderBy(n2 => n2.Length).Select(n2 => n2.Length).First()
                                                        );
            outerQuery.ConsolePrint();

            //Example in Query Expression Syntax:
            IEnumerable<string> outerQueryQE = from n in names where n.Length == (from n2 in names orderby n2.Length select n2.Length).First()
                                               select n;
            outerQueryQE.ConsolePrint();
            //In our example, the subquery executes once for every outer loop iteration.

            //With the Min aggregation function, we can simplify the query further:
            IEnumerable<string> queryMin = from n in names where n.Length == names.Min (n2 => n2.Length)
                                           select n;
            queryMin.ConsolePrint();
        }
    }
}
