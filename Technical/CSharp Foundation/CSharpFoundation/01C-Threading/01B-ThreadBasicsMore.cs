using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSharpFoundation
{
    public class _01B_ThreadBasicsMore
    {
        
        
        public static void RunThreadBasicsMore()
        {
            //Passing Data to a Thread:
            //*************************
            //We can use the ParameterizedThreadStart delegate to pass data to a thread.
            //The limitation of ParameterizedThreadStart is that it accepts only one argument.
            //And because it’s of type object, it usually needs to be cast. See the cast in PrintObject() method.
            Thread t0 = new Thread(new ParameterizedThreadStart(PrintObject));
            t0.Start();

            //Another technique is to pass an argument into Thread’s Start method:
            Thread t1 = new Thread(PrintObject);
            t1.Start("Hello from t!");

            //The easiest way to pass arguments to a thread’s target method is to execute a lambda
            //expression that calls the method with the desired arguments:
            Thread t2 = new Thread(() => Print("Hello from t!"));
            t2.Start();

            //With this approach, you can pass in any number of arguments to the method. You
            //can even wrap the entire implementation in a multistatement lambda: 
            Thread t3 = new Thread(() =>
            {
                Print("Hello");
                Print("World");                
            });
            t3.Start();

            //Lambda expressions and captured variables: You must be careful about accidentally modifying captured variables after
            //starting the thread.For instance, consider the following:
            //  for (int i = 0; i < 10; i++) //Here i variable refers to the same memory location throughout the loop’s lifetime.
            //      new Thread (() => Console.Write (i)).Start();
            //The output is nondeterministic! Here’s a typical result: 0223557799

            //Sharing Data Between Threads
            //****************************
            //Important: Each thread gets a separate copy of its own variables as it enters its associated method
            //and so is unable to interfere with another concurrent thread. The CLR and operating system achieve this by 
            //assigning each thread its own private memory stack for local variables. For example: 
            new Thread(WriteY).Start(); //Each thread gets a separate copy of variable i (see method WriteY) below. Hence no interference.
            WriteY();

            //Now if threads want to share data, they do so via a common reference. See example below;
            Introducer intro = new Introducer(); //This instance is shared between the "main" thread and "intro" thread.
            intro.Message = "Hello";
            
            var tshare = new Thread(intro.Run);
            tshare.Start();
            tshare.Join(); //This is important. Main thread has to wait till thread "tshare" completes.

            Console.WriteLine(intro.Reply); //Now access the Reply property which would have been set by "tshare".

            //Foreground and Background Threads
            //*******************************
            //By default, threads you create explicitly are foreground threads. Foreground threads keep the application alive for as long 
            //as any one of them is running, whereas background threads do not. Once all foreground threads finish, the application ends, and any background 
            //threads still running abruptly terminate.
            //We can set IsBackground = true to set a thread as a background thread.Here the worker is assigned background status, and the program exits 
            //almost immediately as the main thread ends (terminating the ReadLine). When a process terminates in this manner, any finally blocks 
            //in the execution stack of background threads are circumvented. This is a problem if your program employs finally (or using) blocks 
            //to perform cleanup work such as releasing resources or deleting temporary files by using either Thread.Join or event wait handle for pooled threads.
            //In either case, you should specify a timeout, so you can abandon a renegade thread should it refuse to finish for some reason. 
            //This is your backup exit strategy: in the end, you want your application to close—without the user having to enlist help from the Task Manager!

            //Thread Priority
            //***************
            //A thread’s Priority property determines how much execution time it gets relative to other active threads in the operating system, 
            //on the following scale: enum ThreadPriority { Lowest, BelowNormal, Normal, AboveNormal, Highest }
            //This becomes relevant only when multiple threads are simultaneously active. Think carefully before elevating a thread’s priority—it can lead
            //to problems such as resource starvation for other threads.

            //Elevating a thread’s priority doesn’t make it capable of performing real-time work, because it’s still throttled by the application’s 
            //process priority. To perform real-time work, you must also elevate the process priority using the Process class in System.Diagnostics as:
            // myProcess.PriorityClass = ProcessPriorityClass.High; 
            //ProcessPriorityClass.High is actually one notch short of the highest priority: Realtime. Setting a process priority to Realtime instructs 
            //the OS that you never want the process to yield CPU time to another process. If your program enters an accidental infinite loop, 
            //you might find even the operating system locked out.

            //Exception Handling
            //******************
            //Any try/catch/finally blocks in scope when a thread is created are of no relevance to the thread when it starts executing.
            try
            {
                new Thread(WriteY).Start(); //if WriteY throws an exception, it'll never enter the below catch block because each thread has an 
                                            //independent execution path. The remedy is to move the exception handler into the WriteY method:

            }
            catch (Exception ex)
            {
                // We'll never get here!
                Console.WriteLine("Exception!" + ex.Message);
            }

            //The “global” exception handling events for WPF and Windows Forms applications (Application.DispatcherUnhandledException 
            //and Application.ThreadException) fire only for exceptions thrown on the main UI thread. You still must handle exceptions
            //on worker threads manually (except for Asynchronous delegates, BackgroundWorker and The Task Parallel Library). 
            //AppDomain.CurrentDomain.UnhandledException fires on any unhandled exception, but provides 
            //no means of preventing the application from shutting down afterward.
        }

        class Introducer
        {
            public string Message;
            public string Reply;
            public void Run()
            {
                Console.WriteLine(Message);
                Reply = "Hi right back!";
            }
        }

        static void PrintObject(object message)
        {
            if(message is string)
                Console.WriteLine((string)message);
        }

        static void Print(string message) 
        { 
            Console.WriteLine(message); 
        }
    
        static void WriteY()
        {
            //Once started, a thread’s IsAlive property returns true, until the point where the thread ends.
            for (int i = 0; i < 500; i++)
            {
                Console.Write("y");
            }
        }
        
    }
}
