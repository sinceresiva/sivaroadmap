using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Chapter2
{
    public class FileSystemNavigation
    {
        //Demonstrates the use of File System classes in System.IO namespace.
        public static void Display()
        {
            Console.WriteLine("/n***********FileSystemNavigation***********");

            //The file system classes are separated into two types of
            //classes: informational and utility.

            //Let us look at Informational classes first (below).

            //The FileSystemInfo class contains methods that are common to file and directory manipulation
            FileSystemInfo fsi = new DirectoryInfo(@"D:\");

            // Determine if entry is really a directory
            if ((fsi.Attributes & FileAttributes.Directory) == FileAttributes.Directory )
            {
                string entryType = "Directory";
                //  Show this entry's type, name, and creation date.
                Console.WriteLine("{0} entry {1} was created on {2:D}", entryType, fsi.FullName, fsi.CreationTime);
            }
            

            //The FileInfo class provides the basic functionality to access and manipulate a single
            //file in the file system.
            FileInfo ourFile = new FileInfo(@"SampleFile.txt");
            if (ourFile.Exists)
            {
                Console.WriteLine("Filename : {0}", ourFile.Name);
                Console.WriteLine("Path : {0}", ourFile.FullName);

                //Copy the file to another file overwriting it if necessary.
                if (File.Exists(@"SampleNewFile.txt")) File.Delete(@"SampleNewFile.txt");
                ourFile.CopyTo(@"SampleNewFile.txt", true);
                Console.WriteLine(@"File Copied.");                
            }


            //Enumerate Files in a Directory using DirectoryInfo class
            DirectoryInfo ourDir = new DirectoryInfo(@"C:\windows");
            Console.WriteLine("Directory: {0}", ourDir.FullName);
            foreach (FileInfo file in ourDir.GetFiles())
            {
                Console.WriteLine("File: {0}", file.Name);
            }

            //Enumerate Drives in a System using DriveInfo class.
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Drive: {0}", drive.Name);
                Console.WriteLine("Type: {0}", drive.DriveType);
            }

            //Change the extension of a file. This is done using the Path object
            string ourPath = @"SampleNewFile.txt";
            Console.WriteLine("Ext: {0}", Path.GetExtension(ourPath));
            Console.WriteLine("Change Path: {0}",
            Path.ChangeExtension(ourPath, "text"));            
        }
    }
}
