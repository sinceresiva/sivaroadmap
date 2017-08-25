using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Chapter05_Serialization
{
    //This program demonstrates the various formats in Serialization.
    //Choose BinaryFormatter only when you know that all clients
    //opening the serialized data will be .NET Framework applications. Therefore, if you are
    //writing objects to the disk to be read later by your application, BinaryFormatter is perfect.
    //SoapFormatter is XML-based, it is primarily intended to be used by SOAP Web
    //services. If your goal is to store objects in an open, standards-based document that
    //might be consumed by applications running on other platforms, the most flexible
    //way to perform serialization is to choose XML serialization.
    public class SerializationFormat
    {
        public static void Display()
        {
            //Let us serialize a ShoppingCartItem object
            // Create file to save the data to.
            FileStream fs = new FileStream("SerializedObject.Soap", FileMode.Create);

            // Create a SoapFormatter object to perform the serialization
            System.Runtime.Serialization.Formatters.Soap.SoapFormatter soapFormatter =
                        new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();

            ShoppingCartItem cartItem = new ShoppingCartItem() { productId = 1001, quantity = 50, price = 10 };

            // Use the BinaryFormatter object to serialize the cartItem to the file
            soapFormatter.Serialize(fs, cartItem);

            // Close the file
            fs.Close();

            //Let us deserialize a ShoppingCartItem object.
            fs = new FileStream("SerializedObject.Soap", FileMode.Open);

            // Use the SoapFormatter object to deserialize the data from the file
            ShoppingCartItem item = (ShoppingCartItem)soapFormatter.Deserialize(fs);

            // Close the file
            fs.Close();

            // Display the deserialized item
            Console.WriteLine("\n SoapFormatter...");
            item.DisplayDetails();
        }
    }
}
