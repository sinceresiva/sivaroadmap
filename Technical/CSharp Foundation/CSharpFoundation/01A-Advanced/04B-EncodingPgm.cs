using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Chapter1
{
    /// <summary>
    //Encoding means representing characters of a language with corresponding numbers/bytes (machines only understand bytes remember??)
    //For example 'A' is represented by the number 65 where as 'a' is represented by 97.
    //American Standard Code for Information 
    //Interchange (ASCII) is still the foundation for existing encoding types. ASCII assigned
    //characters to 7-bit bytes using the numbers 0 through 127. These characters included
    //English uppercase and lowercase letters, numbers, punctuation, and some special control
    //characters. 
    //While ASCII was sufficient for most English-language communications, ASCII did not
    //include characters used in non-English alphabets. To enable computers to be used in
    //non-English-speaking locations, computer manufacturers made use of the remaining
    //values—128 through 255—in an 8-bit byte. Over time, different locations assigned
    //unique characters to values greater than 127. Because different locations might have
    //different characters assigned to a single value, transferring documents between different
    //languages created problems.   
    //To help reduce these problems, American National Standards Institute (ANSI) defined
    //standardized code pages that had standard ASCII values for 0 through 127, and language-
    //specific values for 128 through 255. A code page is a list of selected character
    //codes (characters represented as code points) in a certain order. Code pages are usually
    //defined to support specific languages or groups of languages that share common writing
    //systems.
    //The .NET Framework uses Unicode UTF-16 (Unicode Transformation Format, 16-bit encoding form) 
    //to represent characters. In some cases, the .NET Framework uses UTF-8 internally.
    /// </summary>
    public class EncodingPgm
    {
        public static void Display()
        {
            // Get Korean Code Page for encoding. 
            Encoding e = Encoding.GetEncoding("Korean");

            // Convert ASCII bytes to Korean encoding.
            //Note the last character. Whereas all the other characters in the below string
            //will be encoded matching the original ASCII bytes, the last character ╝ will differ in various code pages.
            byte[] encoded = e.GetBytes("A Nice Lady╝");

            // Display the byte codes
            for (int i = 0; i < encoded.Length; i++)
                Console.WriteLine("Byte {0}: {1}", i, encoded[i]);

            //Let us examine all the supported code pages in the .NET Framework
            EncodingInfo[] ei = Encoding.GetEncodings();
            foreach (EncodingInfo einfo in ei)
                Console.WriteLine("{0}: {1}, {2}", einfo.CodePage, einfo.Name, einfo.DisplayName);

            //From the above output,“ISO-8859-1” corresponds to code page 28591, “Western European (ISO)”. 
            //If it had specified “ISO-8859-7”, it could have contained characters from the “Greek (ISO)”
            //code page; number 28597.

            //To specify the encoding type when writing a file, use an overloaded Stream constructor
            //that accepts an Encoding object.
            StreamWriter swUtf8 = new StreamWriter("utf8.txt", false, Encoding.UTF8);
            swUtf8.WriteLine("Hello, World!");
            swUtf8.Close();

            StreamWriter swUtf32 = new StreamWriter("utf32.txt", false, Encoding.UTF32);
            swUtf32.WriteLine("Hello, World!");
            swUtf32.Close();

            //Note: Notepad is not capable of correctly reading UTF-7 and UTF-32 files.
            //Hence try opening the files in notepad to see it yourself.
            StreamWriter swUtf7 = new StreamWriter("utf7.txt", false, Encoding.UTF7);
            swUtf7.WriteLine("Hello, World!");
            swUtf7.Close();

            StreamWriter swUtf16 = new StreamWriter("utf16.txt", false, Encoding.Unicode);
            swUtf16.WriteLine("Hello, World!");
            swUtf16.Close();

            //Typically, you do not need to specify an encoding type when reading a file. The .NET
            //Framework automatically decodes most common encoding types. However, you can
            //specify an encoding type using an overloaded Stream constructor,
            string fn = "file.txt";
            StreamWriter sw = new StreamWriter(fn, false, Encoding.UTF7);
            sw.WriteLine("Hello, World!");
            sw.Close();

            StreamReader sr = new StreamReader(fn, Encoding.UTF7);
            Console.WriteLine("When read with Encoding.UTF7: " + sr.ReadToEnd());
            sr.Close();
        }
    }
}
