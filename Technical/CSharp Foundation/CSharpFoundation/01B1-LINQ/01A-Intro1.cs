using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    //LINQ, or Language Integrated Query, is a set of language and framework features for writing structured type-safe queries 
    //over local object collections and remote data sources.LINQ enables you to query any collection implementing IEnumerable<T>, whether
    //an array, list, or XML DOM, as well as remote data sources, such as tables in SQL Server.
    //All core types are defined in the System.Linq and System.Linq.Expressions namespaces.
    public class _01A_Intro1
    {
        public static void RunLINQIntro1()
        {
            //Getting Started
            //The basic units of data in LINQ are sequences and elements. A sequence is any object
            //that implements IEnumerable<T> and an element is each item in the sequence. In the
            //following example, names is a sequence, and Tom, Dick, and Harry are elements:
            string[] names = { "Tom", "Dick", "Harry" };

            //A query operator is a method that transforms a sequence. A typical query operator accepts an input sequence 
            //and emits a transformed output sequence. In the Enumerable class in System.Linq, there are around 40 
            //query operators—all implemented as static extension methods. These are called standard query operators.

            //LINQ also supports sequences that can be dynamically fed from a remote data source such as a SQL Server. These sequences
            //additionally implement the IQueryable<T> interface and are supported through a matching set of standard query operators in the Queryable class. (Later)
            IEnumerable<string> filteredNames = System.Linq.Enumerable.Where (names, n => n.Length >= 4);
            filteredNames.ConsolePrint(); //We have defined this extension method at (Program02.cs)

            //Because the standard query operators are implemented as extension methods, we can call Where directly on names as:
            filteredNames = names.Where(n => n.Length >= 5); //Most query operators accept a lambda expression as an argument. The lambda expression helps guide and shape the query.
            filteredNames.ConsolePrint();
            //Important: In the above example, the input argument corresponds to an input element. In this case, the input argument n represents 
            //each name in the array and is of type string. The Where operator requires that the lambda expression return a bool value, 
            //which if true, indicates that the element should be included in the output sequence.

            //Fluent Syntax and Query Expression Syntax
            //So far, we’ve built queries using extension methods and lambda expressions. As we’ll see shortly, this strategy is highly composable 
            //in that it allows the chaining of query operators. In the book, we refer to this as fluent syntax.

            //C# also provides another syntax for writing queries, called query expression syntax. Here’s our preceding query written as a query expression:
            IEnumerable<string> filteredNamesWith = from n in names where n.Contains ("ck")
                                                    select n;
            filteredNamesWith.ConsolePrint();            
        }        
    }
}
