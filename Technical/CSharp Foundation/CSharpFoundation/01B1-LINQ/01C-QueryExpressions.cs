using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    //C# provides a syntactic shortcut for writing LINQ queries, called query expressions. Contrary to popular belief, 
    //query expressions are based not on SQL, but on list comprehensions from functional programming languages such as LISP and Haskell.
    public class _01C_QueryExpressions
    {
        public static void RunQueryExpressions()
        {
            //Query expressions always start with a from clause and ends with either a select or group clause.
            //For example: 
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> query =
                                    from n in names //The from clause declares an range variable (in this case, n), which you
                                                                            //can think of as traversing the input sequence—rather like foreach
                                    where n.Contains("a") // Filter elements
                                    orderby n.Length // Sort elements
                                    select n.ToUpper(); // Translate each element (project)
            query.ConsolePrint();

            //IMPORTANT: The compiler processes a query expression by translating it into fluent syntax much like it translates foreach statements
            //into calls to GetEnumerator and MoveNext.

            //The identifier immediately following the from keyword syntax is called the range variable. A range variable refers to the current element 
            //in the sequence that the operation is to be performed on. Also note that each instance of n (above) is scoped privately to its own lambda expression.

            //Query Syntax Versus Fluent Syntax (Important)
            //1. Query syntax is simpler for queries that involve any of the following:
                //  • A let clause (seen later) for introducing a new variable alongside the range variable
                //  • SelectMany, Join, or GroupJoin, (seen later) followed by an outer range variable reference
            //2. The middle ground is queries that involve the simple use of Where, OrderBy, and Select. Either syntax works well; 
                    //the choice here is largely personal.
            //3. Finally, there are many operators that have no keyword in query syntax. These require that you use fluent syntax—at least in part. 
            //This means any operator outside of the following:
            //Where, Select, SelectMany, OrderBy, ThenBy, OrderByDescending, ThenByDescending, GroupBy, Join, GroupJoin

            //Mixed Syntax Queries
            //If a query operator has no query-syntax support, you can mix query syntax and fluent
            //syntax. The only restriction is that each query-syntax component must be complete
            //(i.e., start with a from clause and end with a select or group clause).
            //The following example counts the number of names containing the letter “a”:
            int matches = (from n in names where n.Contains ("a") select n).Count();
            Console.WriteLine("Count = " + matches);
            //The mixed syntax approach is sometimes beneficial in more complex queries.

            //There are times when mixed syntax queries offer by far the highest “bang for the buck” in terms of function and simplicity.
            //It’s important not to unilaterally favor either query or fluent syntax; otherwise, you’ll be unable to write mixed syntax queries
            //without feeling a sense of failure!
        }

    }
}
