using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace Ch4_CollectionsAndGenerics
{
    //This program demonstrates the use of Bit Operations using BitArray and BitVector32 classes.
    //The .NET Framework supports a new namespace called System.Collections.Specialized
    //that includes collections that are meant to work with specific types of data.   
    public class BitOperations
    {
        public static void Display()
        {
            Console.WriteLine("\n Bit Arrays...");
            //The BitArray class is a resizeable collection that can store Boolean values. In addition
            //to being resizeable, it supports common bit-level operations such as and, not, or, and
            //exclusive-or (Xor).The BitArray is a traditionally resizeable collection, but not a dynamically resizing one.
            //When you create a new instance of the BitArray class, you must specify the size of the collection. Once the 
            //new instance has been created, you can change the size by changing the Length property.
            BitArray bits = new BitArray(3);
            bits[0] = false;
            bits[1] = true;
            bits[2] = false;

            //The real power of the BitArray is in its ability to perform Boolean operations on two
            //BitArray objects (of the same size).
            BitArray moreBits = new BitArray(3);
            moreBits[0] = true;
            moreBits[1] = true;
            moreBits[2] = false;
            BitArray xorBits = bits.Xor(moreBits);
            foreach (bool bit in xorBits)
            {
                Console.WriteLine(bit);
            }

            Console.WriteLine("\n BitVector32...");

            //BitVector32 class: The BitVector32 class is very useful for managing individual bits in a larger number.
            //The BitVector32 stores all its data as a single 32-bit integer.All operations on the
            //BitVector32 actually change the value of the integer within the structure. At any time,
            //you can retrieve the stored integer by calling the structure’s Data property.
            BitVector32 bitVector = new BitVector32(0);
            int firstBit = BitVector32.CreateMask();
            int secondBit = BitVector32.CreateMask(firstBit);
            int thirdBit = BitVector32.CreateMask(secondBit);
            bitVector[firstBit] = true;
            bitVector[secondBit] = true;
            bitVector[thirdBit] = false;
            Console.WriteLine("{0} should be 3", bitVector.Data);

            Console.WriteLine(bitVector); //Displays BitVector32{00000000000000000000000000000011}

            //Create a new BitVector32 object and set its initial value to 4
            BitVector32 newVector = new BitVector32(4);
            bool bit1 = newVector[firstBit];
            bool bit2 = newVector[secondBit];
            bool bit3 = newVector[thirdBit];
            Console.WriteLine("bit1 and bit2 are {0} whereas bit3 is {1}", (bit1&&bit2), bit3);
            Console.WriteLine("{0} should be 4", newVector.Data);

            Console.WriteLine("\n Bit Packing...");
            //Bit Packing: Bit packing can be defined as taking several smaller numbers and packing them into one large number. 
            //Bit packing is often done to decrease storage of especially small numbers.
            //For ex: if we have 3 small numbers, 5 15 and 600, instead of storing as 3 Int16s we can use a BitVector32 to store all three values in a single
            //32-bit number as shown below;
            BitVector32.Section firstSection = BitVector32.CreateSection(5);
            BitVector32.Section secondSection = BitVector32.CreateSection(15, firstSection);
            BitVector32.Section thirdSection = BitVector32.CreateSection(600, secondSection);

            BitVector32 packedBitVector = new BitVector32();
            packedBitVector[firstSection] = 5;
            packedBitVector[secondSection] = 15;
            packedBitVector[thirdSection] = 600;

            Console.WriteLine("firstSection is {0}", packedBitVector[firstSection]);
            Console.WriteLine("packedBitVector is {0}", packedBitVector.Data);
        }
    }    
}
