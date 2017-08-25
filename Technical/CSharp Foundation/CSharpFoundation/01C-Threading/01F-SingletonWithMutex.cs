using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSharpFoundation
{
    public class SingletonAcrossProcesses
    {
        private static SingletonAcrossProcesses _instance;
        private static Mutex _mutex;

        static SingletonAcrossProcesses()
        {
            bool isCreatedNew = false;
            _mutex =  new Mutex(true, @"Global\" + "sivablogz.wordpress.com SingletonMutexDemo", out isCreatedNew);

            if (isCreatedNew)
                Console.WriteLine("Created new Mutex");
        }

        protected SingletonAcrossProcesses()
        {
        }

        public static SingletonAcrossProcesses GetInstance()
        {
            if (_mutex.WaitOne(TimeSpan.Zero, true))
            {
                if (_instance == null)
                {
                    _instance = new SingletonAcrossProcesses();
                }
                _mutex.ReleaseMutex();
                _mutex.Close();
            }            
            
            return _instance;                            
        }

        public string Name { get; set; }

        public static void RunSingletonAcrossProcesses()
        {
            Console.WriteLine("Press any key to Instantiate the singleton...");
            Console.ReadLine();

            SingletonAcrossProcesses instance = SingletonAcrossProcesses.GetInstance();
            if (instance != null)
            {
                if (String.IsNullOrEmpty(instance.Name))
                {
                    Console.WriteLine("Enter a name for the instance...");
                    instance.Name = Console.ReadLine();
                }
                Console.WriteLine("The Instance name is: " + instance.Name);
            }
            else
                Console.WriteLine("The Singleton Instance could not be obtained.");
            
            Console.WriteLine("Press any key to terminate...");
            Console.ReadLine();
        }
    }
}
