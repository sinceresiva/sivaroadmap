using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Chapter05_Serialization
{
    //This program creates classes that can be serialized.
    //You can serialize and deserialize custom classes by adding the Serializable attribute to
    //the class.If you are satisfied with the default handling of the serialization, no other code besides
    //the Serializable attribute is necessary.When your class is serialized, the runtime serializes
    //all members, including private members. 
    [Serializable]
    public class ShoppingCartItem : IDeserializationCallback
    {
        //The below members will be automatically serialized.
        public int productId;
        public decimal price;
        public int quantity;

        //One can omit class members to be not included in the serialization
        //by using the NonSerialized attribute as below.
        [NonSerialized]
        public decimal total;

        //The OptionalField attribute does not affect the serialization process. During deserialization,
        //if the member was not serialized, the runtime will leave the member’s value as
        //null rather than throwing an exception.
        [OptionalField]
        public bool taxable;

        /*To enable your class to automatically initialize a nonserialized member, use the
        IDeserializationCallback interface, and then implement IDeserializationCallback.OnDeserialization. 
        Each time your class is deserialized, the runtime will call the
        IDeserializationCallback.OnDeserialization method after deserialization is complete.*/
        void IDeserializationCallback.OnDeserialization(Object sender)
        {
            // After deserialization, calculate the total
            total = price * quantity;
            taxable = true;//Incase the taxable field was not serialized in a previous version, provide a default value now.

            #region
                //Best Practices for Version Compatibility
                //To ensure proper versioning behavior, follow these rules when modifying a custom
                //class from version to version:
                //■ Never remove a serialized field.
                //■ Never apply the NonSerializedAttribute attribute to a field if the attribute was not
                //applied to the field in a previous version.
                //■ Never change the name or type of a serialized field.
                //■ When adding a new serialized field, apply the OptionalFieldAttribute attribute.
                //■ When removing a NonSerializedAttribute attribute from a field that was not serializable
                //in a previous version, apply the OptionalFieldAttribute attribute.
                //■ For all optional fields, set meaningful defaults using the serialization callbacks
                //unless 0 or null as defaults are acceptable.
            #endregion
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Pid={0},Qty={1},Price={2}, Total={3}, Taxable={4}", this.productId,this.quantity,this.price,this.total,this.taxable);
        }
    }

    public class SerializableClasses
    {
        public static void Display()
        {
            //Let us serialize a ShoppingCartItem object
            // Create file to save the data to.
            FileStream fs = new FileStream("SerializedObject.Data", FileMode.Create);

            // Create a BinaryFormatter object to perform the serialization
            BinaryFormatter bf = new BinaryFormatter();

            ShoppingCartItem cartItem = new ShoppingCartItem(){productId=1001, quantity = 50, price = 10};

            // Use the BinaryFormatter object to serialize the cartItem to the file
            bf.Serialize(fs, cartItem);

            // Close the file
            fs.Close();

            //Let us deserialize a ShoppingCartItem object.
            fs = new FileStream("SerializedObject.Data", FileMode.Open);

            // Create a BinaryFormatter object to perform the deserialization
            bf = new BinaryFormatter();

            // Use the BinaryFormatter object to deserialize the data from the file
            ShoppingCartItem item = (ShoppingCartItem)bf.Deserialize(fs);
            
            // Close the file
            fs.Close();

            // Display the deserialized item
            Console.WriteLine("\n Serializable Class...");
            item.DisplayDetails();
        }
    }

    
}
