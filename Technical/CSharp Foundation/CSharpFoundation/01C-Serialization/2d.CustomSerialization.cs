using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Data;
using System.Security.Permissions;

namespace Chapter05_Serialization
{
    //This program shows Custom Serialization.
    //In some circumstances, you might need complete control over the serialization process.
    //You can override the serialization built into the .NET Framework by implementing
    //the ISerializable interface and applying the Serializable attribute to the class. This is
    //particularly useful in cases where the value of a member variable is invalid after deserialization,
    //but you need to provide the variable with a value to reconstruct the full
    //state of the object.

    //The following sample code, which uses the System.Runtime.Serialization and System.Security.Permissions 
    //namespaces, shows how to implement ISerializable, GetObjectData method (for serialization) and 
    //the de-serialization constructor.

    [Serializable]
    class ShoppingCartItemSerializable : ISerializable
    {
        public Int32 productId;
        public decimal price;
        public Int32 quantity;

        [NonSerialized]
        public decimal total;

        // The standard, non-serialization constructor
        public ShoppingCartItemSerializable(int _productID, decimal _price, int _quantity)
        {
            productId = _productID;
            price = _price;
            quantity = _quantity;
            total = price * quantity;
        }

        // The following method is called during serialization.
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Product ID", productId);
            info.AddValue("Price", price);
            info.AddValue("Quantity", quantity);
        }

        //The following constructor is for deserialization.
        protected ShoppingCartItemSerializable(SerializationInfo info,
        StreamingContext context)
        {
            productId = info.GetInt32("Product ID");
            price = info.GetDecimal("Price");
            quantity = info.GetInt32("Quantity");
            total = price * quantity;
        }

        public override string ToString()
        {
            return productId + ": " + price + " x " + quantity + " = " + total;
        }
    }

    public class CustomSerialization
    {
        public static void Display()
        {
            //Let us use the BinaryFormatter to Serialize and Deserialize the ShoppingCartItemSerializable data.
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream("CustomSerialized.ser",FileMode.Create);

            ShoppingCartItemSerializable scart=new ShoppingCartItemSerializable(100,(decimal)55.89,100);
            formatter.Serialize(fileStream, scart);
            fileStream.Close();

            fileStream = new FileStream("CustomSerialized.ser", FileMode.Open);
            ShoppingCartItemSerializable item = (ShoppingCartItemSerializable) formatter.Deserialize(fileStream);
            Console.WriteLine("\n Custom Serialization: Retrived Item: " + item.ToString());
            fileStream.Close();
        }        
    }
}
