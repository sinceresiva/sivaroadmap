using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Chapter05_Serialization
{
    //This program demonstrates Xml Serialization.
    //You can use XML serialization when you need to exchange an object with an application that
    //might not be based on the .NET Framework, and you do not need to serialize any
    //private members.
    public class XmlSerializers
    {
        public static void Display()
        {
            // Create file to save the data to
            FileStream fs = new FileStream("SerializedDate.XML", FileMode.Create);

            // Create an XmlSerializer object to perform the serialization
            XmlSerializer xs = new XmlSerializer(typeof(DateTime));

            // Use the XmlSerializer object to serialize the data to the file
            xs.Serialize(fs, System.DateTime.Now);

            // Close the file
            fs.Close();

            //Let us De-Serialize the data.
            // Open file to read the data from
            fs = new FileStream("SerializedDate.XML", FileMode.Open);

            // Create an XmlSerializer object to perform the deserialization
            xs = new XmlSerializer(typeof(DateTime));

            // Use the XmlSerializer object to deserialize the data from the file
            DateTime previousTime = (DateTime)xs.Deserialize(fs);

            // Close the file
            fs.Close();

            // Display the deserialized time
            Console.WriteLine("\nXmlSerializer...");
            Console.WriteLine("Day: " + previousTime.DayOfWeek + ",Time: " + previousTime.TimeOfDay.ToString());
        }
    }
}
