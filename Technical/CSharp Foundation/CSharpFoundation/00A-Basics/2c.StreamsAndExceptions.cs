using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter1
{
    public class Streams
    {
        public static void Display()
        {
            Console.WriteLine("\n****Streams and Exceptions*****");
            
            // Create and write to a text file
            System.IO.StreamWriter sw = new System.IO.StreamWriter("text.txt");
            sw.WriteLine("Hello, World!");
            sw.Close();

            // Read and display a text file
            System.IO.StreamReader sr = new System.IO.StreamReader("text.txt");
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();

            // Let us make the system throw an exception because below text1.txt does not exist.
            try
            {
                System.IO.StreamReader sr1 = new System.IO.StreamReader("text1.txt");
                Console.WriteLine(sr1.ReadToEnd());
            }
            //The most specific exception is first caught.
            catch (System.IO.FileNotFoundException ex)
            {
                // The file was not found.
                Console.WriteLine("The file was not found.: " + ex.Message);
            }
            //Exception is the most generic of all exceptions.
            catch (Exception ex)
            {
                // If there are any problems reading the file, display an error message.
                Console.WriteLine("Error reading file: " + ex.Message);
            }
            //finally block always executes - whether exception is thrown or not.
            finally
            {
                // Close the StreamReader, whether or not an exception occurred.
                sr.Close();
            }
        }
    }
}
