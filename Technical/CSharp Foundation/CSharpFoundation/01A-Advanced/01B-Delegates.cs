using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    public class _01B_Delegates
    {
        //The Func and Action Delegates
        //Func and Action delegates are so general they can work for methods of any return type and any (reasonable)
        //number of arguments. Func can return a type/value whereas Action returns void.
        public static void Transform<T>(T[] values, Func<T, T> transformer)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = transformer(values[i]);
        }

        public int MultiplyBy2(int i)
        {
            return i * 2;
        }

        public static void RunFuncDelegate()
        {
            _01B_Delegates myobj = new _01B_Delegates();
            _01B_Delegates.Transform(new int[] { 2, 4 }, new Func<int,int>(myobj.MultiplyBy2));
        }
    }
}
