using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.IO.Compression;
using System.IO.IsolatedStorage;
using System.Security.Permissions;

namespace Chapter2
{
    //This program demonstrates Isolated Storage

    //By using isolated storage to save your data, you will have access to a safe place to store
    //information without needing to resort to having users grant access to specific files or folders in the file system. 
    //The main benefit of using isolated storage is that your application will run regardless of whether it is running 
    //under partial, limited, or full-trust.
    
    //Before you can save data in isolated storage, you must determine how to scope the data you want in your store.

    //For most applications, you will want to choose one of the
    //following two methods:
        //■ Assembly/Machine: This method creates a store to keep information that is specific
        //to the calling assembly and the local machine. This method is useful for creating
        //application-level data.
        //■ Assembly/User: This method creates a store to keep information that is specific
        //to the calling assembly and the current user. This method is useful for creating
        //user-level data.


    //The below given IsolatedStorageFilePermission attribute is used to ensure that any calls to work with isolated storage 
    //within this class will succeed. This is because to make sure any code you are working with will have
    //the sufficient permissions, you will need to demand that permission.
    [IsolatedStorageFilePermission(SecurityAction.Demand,
                                            UserQuota = 1024,
                                                UsageAllowed = IsolatedStorageContainment.AssemblyIsolationByUser)]
    public class IsolatedStorages
    {
        public static void Display()
        {
            //Creating an assembly/machine-level store is accomplished by calling the IsolatedStorageFile
            //class’s GetMachineStoreForAssembly method
            IsolatedStorageFile machineStorage = IsolatedStorageFile.GetMachineStoreForAssembly();

            //Creating an assembly/user-level store is similar but with GetUserStoreForAssembly() method.
            IsolatedStorageFile ISStore = IsolatedStorageFile.GetUserStoreForAssembly();

            //Create an underlying IsolatedStorageFileStream object in Create mode.
            IsolatedStorageFileStream ISStorageFileStream = new IsolatedStorageFileStream("UserSettings.set",
                                                                                            FileMode.Create,
                                                                                            ISStore);
            //Write some data.
            StreamWriter userWriter = new StreamWriter(ISStorageFileStream);
            userWriter.WriteLine("User Prefs");
            userWriter.Close();
            ISStorageFileStream.Close();
            
            //Reading the data back is as simple as creating a stream object by opening the file.
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Open, ISStore);
            StreamReader reader = new StreamReader(userStream);
            string contents = reader.ReadToEnd();
            Console.WriteLine(contents);
            reader.Close();
            userStream.Close();
            
            //We are also allowed to create directories to store data within
            ISStore.CreateDirectory("SivaDir");
            userStream = new IsolatedStorageFileStream(@"SivaDir\UserSettings.set", FileMode.Create, ISStore);
            userWriter = new StreamWriter(userStream);
            userWriter.WriteLine("Some Data");
            userWriter.Close();
            userStream.Close();
            ISStore.Close();

        }

    }
}
