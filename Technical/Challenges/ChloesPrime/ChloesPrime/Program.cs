using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{
    class Solution
    {
        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            int q = 0;
            List<int> numbers = new List<int>();

            ConsoleNumberReader reader = new ConsoleNumberReader();
            ChloesPrime chloesPrime = new ChloesPrime();
            q = reader.ReadNumber();
            if (q > 0)
            {
                numbers = reader.ReadNumbers(q);

                //For each number print the total number of Chloe's primes
                foreach (int number in numbers)
                {
                    chloesPrime.PrintCountOfPrimes(number);
                }

                Console.WriteLine("The numbers are: " + string.Join(",", numbers.ToArray()));
            }
        }

        internal class ConsoleNumberReader
        {
            public int ReadNumber()
            {
                int number = 0;
                Console.WriteLine("Enter the value for q: ");
                int.TryParse(Console.ReadLine(), out number);
                return number;
            }

            public List<int> ReadNumbers(int q)
            {
                int number = 0;
                List<int> numbers = new List<int>();
                for (int counter = 0; counter < q; counter++)
                {
                    Console.WriteLine("Enter {0} the value for q: ", counter + 1);
                    if (int.TryParse(Console.ReadLine(), out number))
                        numbers.Add(number);
                }
                return numbers;
            }
        }

        internal class ChloesPrime
        {
            public void PrintCountOfPrimes(int numOfDigits)
            {
                double startRange =  Math.Pow(10, numOfDigits);
                double endRange = (startRange * 10) - 1;
                this.PrintChloesPrimeInRange(startRange, endRange);
            }

            private void PrintChloesPrimeInRange(double startRange, double endRange)
            {

            }
        }
    }
}