using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Chapter05_Serialization
{
    //This program creates a class that can be Serialized by Using XML Serialization.
    //To create a class that can be serialized by using XML serialization, you must perform
    //the following tasks:
    //■ Specify the class as public.
    //■ Specify all members that must be serialized as public.
    //■ Create a parameterless constructor.
    //Unlike classes processed with standard serialization, classes do not have to have the
    //Serializable attribute to be processed with XML serialization. If there are private or
    //protected members, they will be skipped during serialization.
    // C#
    [XmlRoot("OrderDetails")]
    public class OrderItem
    {
        [XmlAttribute]//productId will be an attribute in the serialized Xml
        public Int32 productId;

        public decimal price;
        public Int32 quantity;

        [XmlIgnore]//total will not be serialized.
        public decimal total;

        public OrderItem()
        {
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Pid={0},Qty={1},Price={2}, Total={3}", this.productId, this.quantity, this.price, this.total);
        }
    }
    
    public class XmlSerializableClasses
    {
        public static void Display()
        {
            //Let us serialize a OrderItem object
            // Create file to save the data to.
            FileStream fs = new FileStream("SerializedObject.Xml", FileMode.Create);

            // Create a XmlSerializer object to perform the serialization
            XmlSerializer xsz = new XmlSerializer(typeof(OrderItem));

            OrderItem orderItem = new OrderItem() { productId = 1001, quantity = 50, price = 10 };

            // Serialize it to the file
            xsz.Serialize(fs, orderItem);

            // Close the file
            fs.Close();

            //Let us deserialize a ShoppingCartItem object.
            fs = new FileStream("SerializedObject.Xml", FileMode.Open);

            // Create a XmlSerializer object to perform the deserialization
            xsz = new XmlSerializer(typeof(OrderItem));

            // Use the XmlSerializer object to deserialize the data from the file
            OrderItem item = (OrderItem)xsz.Deserialize(fs);
            
            // Close the file
            fs.Close();

            // Display the deserialized item
            Console.WriteLine("\n Xml De-Serialized Class...");
            item.DisplayDetails();

            //Note: To create a new Strongly typed class based on an Xml schema file
            //named (for example) C:\schema\library.xsd into the folder 'classes',
            //you would run the following command:
            
            //// C#
            //xsd C:\schema\library.xsd /classes /language:CS

            //When you serialize the newly created class, it will automatically conform to the Xml
            //schema. This makes it simple to create applications that interoperate with standardsbased
            //Web services.

            //Refer XmlSchema\ShipOrder.xml and XmlSchema\ShipOrderSchema.xsd for examples of the Xml and its corresponding Schema.
        }
    }

    
}
