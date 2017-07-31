using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFoundation
{
    partial class Program
    {
        static void RunMain03(string[] args)
        {
            Console.WriteLine("-----RunThreadBasics-----");
            //_01A_ThreadBasics.RunThreadBasics();

            Console.WriteLine("-----RunThreadBasicsMore-----");
            //_01B_ThreadBasicsMore.RunThreadBasicsMore();

            Console.WriteLine("-----RunThreadPooling-----");
            //_01C_ThreadPooling.RunThreadPooling();

            Console.WriteLine("-----Synchronization:Blocking-----");
            //_01D_Synchronization.RunBlocking();

            Console.WriteLine("-----Synchronization:Locking-----");
            //_01E_Locking.RunLocking();

            Console.WriteLine("-----Singleton:Mutex-----");
            //SingletonAcrossProcesses.RunSingletonAcrossProcesses();

            Console.WriteLine("-----ThreadSafety-----");
            _02A_ThreadSafety.RunThreadSafety();
        }
    }

}
