using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Chapter2
{
    //This program demonstrates the use of the FileSystemWatcher class to monitor file system changes
    public class FileSystemWatch
    {
        public static void Display()
        {
            Console.WriteLine("\n****File System Watch*****");

            //Get the FileSystemWatcher object.
            FileSystemWatcher fsWatcher = new FileSystemWatcher(@"D:\");

            //Gets or sets whether the watcher object should raise events.
            fsWatcher.EnableRaisingEvents = true; 

            //File filter to use to determine which file changes to monitor.
            fsWatcher.Filter = "*.txt";

            //When too many file system change events occur, the FileSystemWatcher throws the Error event.
            fsWatcher.Error += new ErrorEventHandler(fsWatcher_Error);

            //Watch the folder for new .txt file creations.
            fsWatcher.Created += new FileSystemEventHandler(fsWatcher_Created);

            //Create a file randomly.
            CreateTextFile();
        }

        static void fsWatcher_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("Error Occurred");
        }

        static void fsWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("New File Created. Name: {0}, Change Type: {1}", e.Name, e.ChangeType.ToString());
        }

        private static void CreateTextFile()
        {
            StreamWriter writer = new StreamWriter(@"D:\" + Guid.NewGuid().ToString() + ".txt");
            writer.WriteLine("New file created at " + System.DateTime.Now.ToString());
            writer.Close();
        }
    }
}
