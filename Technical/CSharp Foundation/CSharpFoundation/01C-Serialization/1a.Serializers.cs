using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Chapter05_Serialization
{
    //This program demonstrates the technique of Serialization.
    //Serialization, as implemented in the System.Runtime.Serialization namespace, is the
    //process of serializing and deserializing objects so that they can be stored or transferred
    //and then later re-created.Serializing is the process of converting an object into
    //a linear sequence of bytes that can be stored or transferred.Deserializing is the process
    //of converting a previously serialized sequence of bytes into an object.
    public class Serializers
    {
        public static void Display()
        {
            //Let us serialize a string and DateTime.Now to a file.
            string data = "This must be stored in a file.";
                
            // Create file to save the data to.
            FileStream fs = new FileStream("SerializedString.Data", FileMode.Create);

            // Create a BinaryFormatter object to perform the serialization
            BinaryFormatter bf = new BinaryFormatter();

            // Use the BinaryFormatter object to serialize the data to the file
            bf.Serialize(fs, data); //Serializes the string object
            bf.Serialize(fs, System.DateTime.Now); //Serializes a DateTime object

            // Close the file
            fs.Close();

            //Let us deserialize the data.
            // Open file to read the data from
            fs = new FileStream("SerializedString.Data", FileMode.Open);

            // Create a BinaryFormatter object to perform the deserialization
            bf = new BinaryFormatter();

            // Create the object to store the deserialized data
            data = "";

            // Use the BinaryFormatter object to deserialize the data from the file
            data = (string)bf.Deserialize(fs);
            DateTime dt = (DateTime)bf.Deserialize(fs);
            
            // Close the file
            fs.Close();

            // Display the deserialized string
            Console.WriteLine(data);
            Console.WriteLine(dt.ToString());

        }
    }
}
