using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace CSharpFoundation
{
    public class _02D_BulidingQuerExpressions
    {
        public static void RunBulidingQueryExpressions()
        {
            //Building Query Expressions
            //Delegates Versus Expression Trees
            //It is important to understand that:
            //  • Local queries, which use Enumerable operators, take delegates.
            //  • Interpreted queries, which use Queryable operators, take expression trees.

            //We can see this by comparing the signature of the Where operator in Enumerable and Queryable:
            //          public static IEnumerable<TSource> Where<TSource> (this
            //                                              IEnumerable<TSource> source, Func<TSource,bool> predicate)
            //          public static IQueryable<TSource> Where<TSource> (this
            //                                              IQueryable<TSource> source, Expression<Func<TSource,bool>> predicate)

            //When embedded within a query, a lambda expression looks identical whether it
            //binds to Enumerable’s operators or Queryable’s operators:
            //IEnumerable<Product> q1 = localProducts.Where (p => !p.Discontinued);
            //IQueryable<Product> q2 = sqlProducts.Where (p => !p.Discontinued);

            //When you assign a lambda expression to an intermediate variable, however,
            //you must be explicit on whether to resolve to a delegate (i.e., Func<>) or an
            //expression tree (i.e., Expression<Func<>>).

            //Compiling expression trees
            //You can convert an expression tree to a delegate by calling Compile. (see class Product below where we have defined IsSelling() method
            //that returns Expression<Func<Product, bool>>. This method can be used both in interpreted and in local queries:
        }

        /*
        void Test()
        {
            var dataContext = new NutshellContext("connection string");
            Product[] localProducts = dataContext.Products.ToArray();
            IQueryable<Product> sqlQuery =
            dataContext.Products.Where(Product.IsSelling());
            IEnumerable<Product> localQuery =
            localProducts.Where(Product.IsSelling.Compile());  //Converts into a delegate.
         *  //You cannot convert in the reverse direction, from a delegate to an expression tree. 
         *  //This makes expression trees more versatile.
        }
         * 
         * //AsQueryable
         * The AsQueryable operator lets you write whole queries that can run over either local or remote sequences:
         * 
            IQueryable<Product> FilterSortProducts (IQueryable<Product> input)
            {
                return from p in input
                where ...
                order by ...
                select p;
            }
         * 
         * void Test()
            {
            var dataContext = new NutshellContext ("connection string");
            Product[] localProducts = dataContext.Products.ToArray();
            var sqlQuery = FilterSortProducts (dataContext.Products);
            var localQuery = FilterSortProducts (localProducts.AsQueryable()); //AsQueryable wraps IQueryable<T> clothing around a local sequence so that subsequent
            //query operators resolve to expression trees.
            ...
            }
         * 
         * //Expression Trees : Please refer book (Important!!!)
        * 
        * 
        */

        //Used above
        public partial class Product
        {
            /*
            public static Expression<Func<Product, bool>> IsSelling()
            {
                return p => !p.Discontinued && p.LastSale > DateTime.Now.AddDays(-30);
            }              
            */
        }
    }
}
