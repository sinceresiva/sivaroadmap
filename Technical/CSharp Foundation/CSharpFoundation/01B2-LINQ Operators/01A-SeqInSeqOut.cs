using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    //This Chapter describes each of the LINQ query operators.

    //All of the examples in this section assume that a names array is defined as follows:
    //string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

    //Examples that query a database assume that a typed DataContext variable called dataContext having entity classes 
    //corresponding to below SQL table definitions:
        
        //create table Customer
        //(
        //  ID int not null primary key,
        //  Name varchar(30) not null
        //)

        //create table Purchase
        //(
        //  ID int not null primary key,
        //  CustomerID int references Customer (ID),
        //  Description varchar(30) not null,
        //  Price decimal not null
        //)

    /*
     Overview
        In this section, we provide an overview of the standard query operators.
        The standard query operators fall into three categories:
            • Sequence in, sequence out (sequence-to-sequence)
            • Sequence in, single element or scalar value out
            • Nothing in, sequence out (generation methods)    
     * 
     * In this chapter we see Sequence in, sequence out (sequence-to-sequence)
     */
    
    public class _01A_SeqInSeqOut
    {
        public static void RunSeqInSeqOut()
        {
            /*
            Filtering: 
            **********
            With each of the filtering methods, you always end up with either the same number or fewer elements than you started with. You can never get more! The elements are
            also identical when they come out; they are not transformed in any way.*/
            
            //Where: returns the elements from the input sequence that satisfy the given predicate.
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> query = names.Where(name => name.EndsWith("y")); // Result: { "Harry", "Mary", "Jay" }
            query.ConsolePrint();

            //A where clause can appear more than once in a query and be interspersed with let clauses:
            IEnumerable<string> query1 = from n in names
                                            where n.Length > 3
                                            let u = n.ToUpper()
                                            where u.EndsWith ("Y")
                                            select u; // Result: { "HARRY", "MARY" }
            query1.ConsolePrint();

        }        
    }
}
