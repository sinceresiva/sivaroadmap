using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Ch4_CollectionsAndGenerics
{
    public class Car
    {
        public string Make{get;set;}
        public double Price { get; set; }
    }

    //This program demonstrates sorting an array list.
    public class ArrayListSorting
    {
        public static void Display()
        {
            //The ArrayList supports a method to sort a collection’s items.
            Console.WriteLine("\nArrayList sorting...");
            ArrayList arrayList = new ArrayList();
            arrayList.Add(new Car { Make = "Ferrari", Price = 5000000 });
            arrayList.Add(new Car { Make = "Maruti WagonR", Price = 400000 });
            arrayList.Add(new Car { Make = "Honda Accord", Price = 1000000 });
            Console.WriteLine("\nBefore Sorting...");
            foreach (Car car in arrayList)
            {
                Console.WriteLine("{0} Price: {1}", car.Make, car.Price);
            }
            //The Sort method allows you to specify an IComparer object to use instead of the default.
            arrayList.Sort(new CarComparer());
            Console.WriteLine("\nAfter Sorting...");
            foreach (Car car in arrayList)
            {
                Console.WriteLine("{0} Price: {1}", car.Make, car.Price);
            }
        }
    }

    public class CarComparer : IComparer
    {

        #region IComparer<Car> Members

        //The IComparer interface contains a single method called Compare that takes two
        //objects (for example, a and b) and returns an integer that represents the result of the
        //comparison.
        public int Compare(object c1, object c2)
        {
            Car x = c1 as Car;
            Car y = c2 as Car;

            int result = 0;
            if (x.Price.Equals(y.Price))
                return (result);
            else
            {
                if (x.Price < y.Price)
                    result = -1;
                else
                    result = 1;
            }
            return (result);
        }

        #endregion
    }
}
