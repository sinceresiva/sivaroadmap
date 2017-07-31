using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    public class _02C_InterpretedQueries
    {
        public static void RunIPQueries()
        {
            //Interpreted Queries
            //LINQ provides two parallel architectures: local queries for local object collections, and interpreted queries for remote data sources. 
            //So far, we’ve examined the architecture of local queries, which operate over collections implementing IEnumerable<>.

            //By contrast, interpreted queries are descriptive. They operate over sequences that implement IQueryable<T>, and they resolve to the query operators in the
            //Queryable class, which emit expression trees that are interpreted at runtime.

            //There are two IQueryable<T> implementations in the .NET Framework:
            //• LINQ to SQL
            //• Entity Framework (EF)
            //It’s also possible to generate an IQueryable<T> wrapper around an ordinary enumerable collection by calling the AsQueryable method.(seen later).
            //IQueryable<T> is an extension of IEnumerable<> with additional methods for constructing expression trees.

            //For example: If Customer table (in SQL Server) contains ID and Name field, the following is a LINQ-To SQL query, in C# to retrieve
            // customers whose name contains the letter “a” (works with Entity Framework also).

            /*
            DataContext dataContext = new DataContext("connection string");
            Table<Customer> customers = dataContext.GetTable<Customer>();
            IQueryable<string> query = from c in customers
                                            where c.Name.Contains ("a")
                                            orderby c.Name.Length
                                            select c.Name.ToUpper();
            foreach (string name in query) 
                    Console.WriteLine (name);
             * 
             */

            //How Interpreted Queries Work
            //1. customers is of type Table<>, which implements IQueryable<T> (a subtype of IEnumerable<>).
            //2. The compiler chooses Queryable.Where because its signature is a more specific match.
            //3. Because Where method accepts a Lamda expressoon, the compiler translates the supplied lambda expression to an 
            //      expression tree rather than a compiled delegate.
            //4. An expression tree is an object model based on the types in System.Linq.Expressions that can be inspected at runtime (so that LINQ to SQL or
            //      EF can later translate it to a SQL statement).
            //5. Because Queryable.Where also returns IQueryable<T>, the same process follows with
            //the OrderBy and Select operators.

            //Note: We can also combine Intepreted and local queries.
        }
    }
}
