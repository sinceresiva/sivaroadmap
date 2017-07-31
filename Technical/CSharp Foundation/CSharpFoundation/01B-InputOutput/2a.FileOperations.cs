using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Chapter2
{
    public class FileOperations
    {
        public static void Display()
        {
            Console.WriteLine("\n****File Operations*****");

            //Instantiate a FileStream to point to a file in Open mode with Read Access
            FileStream theFile = File.Open("SampleFile.txt", FileMode.Open, FileAccess.Read);
            
            //Point a StreamReader to the above stream and read it, display and close.
            //Note: The StreamReader class is intended to read a stream as a string, not as a series of bytes.
            //In this way, the StreamReader’s methods for returning data all return either strings or
            //arrays of strings.
            StreamReader rdr = new StreamReader(theFile);
            Console.Write(rdr.ReadToEnd());
            rdr.Close();
            theFile.Close();

            //Alternatively we can use the File class that supports creating a StreamReader directly with the OpenText() method
            StreamReader reader = File.OpenText("SampleFile.txt");
            Console.Write(reader.ReadToEnd());
            reader.Close();

            //The File class supports reading the file in a single method call, 
            //hiding all the details of the stream and reader implementation by calling its ReadAllText method
            Console.Write(File.ReadAllText("SampleFile.txt"));

            //Let us look at File Write operatations. We can simply use the FileStream and StreamWriter class to do this.
            FileStream fileToWrite = File.Create(@"SampleFileToWrite.txt");
            StreamWriter writer = new StreamWriter(fileToWrite);
            writer.WriteLine("Hello");
            writer.Close();
            fileToWrite.Close();
            
            //We can use the StreamWriter to write text directly into your new file
            writer = File.CreateText("SampleFileToWrite.txt");
            writer.WriteLine("Hello");
            writer.Close();

            //Or we can do all in one go...
            File.WriteAllText("SampleFileToWrite.txt", "Hello From Final\n");

            //Read it and show.
            Console.Write(File.ReadAllText("SampleFileToWrite.txt"));

            //To Open an exising file, we can use the File.Open() by specifying the mod and access type.
            FileStream writeableStream = File.Open(@"SampleFileToWrite.txt",
                                            FileMode.OpenOrCreate,
                                                FileAccess.Write);
            writer = new StreamWriter(writeableStream);
            writer.WriteLine("Added line to exising file");
            writer.Close();


            //StringReader and StringWriter classes write to and read from in-memory strings.
            string s = @"Hello all 
                        This is a multi-line 
                        text string";

            StringReader redr = new StringReader(s);
            while (redr.Peek() != -1)// See if there are more characters
            {
                string line = redr.ReadLine();
                Console.WriteLine(line);
            }

            StringWriter swriter = new StringWriter();
            swriter.WriteLine("Hello!!!");
            swriter.WriteLine("This is a multi-line");
            swriter.WriteLine("text string");
            Console.WriteLine(swriter.ToString());

            //The BinaryReader and BinaryWriter classes can be used to fetch and write binary data to and from streams.
            FileStream newFile = File.Create(@"somefile.bin");
            BinaryWriter bWriter = new BinaryWriter(newFile);
            long number = 100;
            byte[] bytes = new byte[] { 10, 20, 50, 100 };
            string ssample = "hunger";
            bWriter.Write(number);
            bWriter.Write(bytes);
            bWriter.Write(ssample);
            bWriter.Close();
            newFile.Close();

            FileStream newFileStream = File.Open(@"somefile.bin",FileMode.Open);
            BinaryReader bReader = new BinaryReader(newFileStream);
            long bNumber = bReader.ReadInt64();
            byte[] bBytes = bReader.ReadBytes(4);
            ssample = bReader.ReadString();
            bReader.Close();
            Console.WriteLine(bNumber);
            foreach (byte b in bBytes)
            {
                Console.Write("[{0}]", b);
            }
            Console.WriteLine();
            Console.WriteLine(ssample);

            bReader.Close();
            newFileStream.Close();


            //The MemoryStream class helps us create streams in memory. Memory streams are generally used for temporary data storage.
            //These are especially helpful if we don't want situations where we have to keep a file handle open for a long time while writing 
            //time intensive data. Instead,
            //we can use a memory stream, write the (time intesive) data to the memory stream and then dump the mem stream to a file stream as shown;
            MemoryStream memStrm = new MemoryStream();
            StreamWriter mWriter = new StreamWriter(memStrm);
            mWriter.WriteLine("Hello");
            mWriter.WriteLine("Goodbye");
            mWriter.Flush();

            // Create a file stream
            FileStream memFile = File.Create(@"inmemory.txt");
            // Write the entire Memory stream to the file
            memStrm.WriteTo(memFile);

            // Clean up
            mWriter.Close();
            memFile.Close();
            memStrm.Close();

        }
    }
}
