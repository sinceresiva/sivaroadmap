using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSharpFoundation
{
    public class _01A_ThreadBasics
    {
        public static void RunThreadBasics()
        {
            //A thread is analogous to the operating system process in which your application runs. 
            //Just as processes run in parallel on a computer, threads run in parallel within a single process. 
            //Processes are fully isolated from each other; threads have just a limited degree of isolation. 
            //In particular, threads share (heap) memory with other threads running in the same application.

            //Multithreading has many uses; here are the most common:
            //1.    Maintaining a responsive user interface - By running time-consuming tasks on a parallel “worker” thread, the main UI
            //      thread is free to continue processing keyboard and mouse events.
            //2.    Making efficient use of an otherwise blocked CPU  - Multithreading is useful when a thread is awaiting a response from another
            //      computer or piece of hardware. While one thread is blocked while performing the task, other threads can take advantage of the 
            //      otherwise unburdened computer.
            //3.    Parallel programming - Code that performs intensive calculations can execute faster on multicore or multiprocessor computers 
            //      if the workload is shared among multiple threads in a “divide-and-conquer” strategy.
            //4.    Speculative execution - For example: run a number of different algorithms in parallel that all solve the same task -
            //      Whichever one finishes first “wins”—this is effective when you can’t know ahead of time which algorithm will execute fastest.
            //5.    Allowing requests to be processed simultaneously - On a server, client requests can arrive concurrently and so need to be handled
            //      in parallel (the .NET Framework creates threads for this automatically if you use ASP.NET, WCF, Web Services, or Remoting).

            //Problems with Threads - Threads also come with strings attached. The biggest is that multithreading can increase complexity. 
            //Having lots of threads does not in and of itself create much complexity; it’s the interaction between threads (typically via shared data) that does.
            //This applies whether or not the interaction is intentional, and can cause long development cycles and an ongoing susceptibility to 
            //intermittent and nonreproducible bugs.
            //Threading also incurs a resource and CPU cost in scheduling and switching threads (when there are more active threads than CPU cores)—
            //and there’s also a creation/ tear-down cost. Multithreading will not always speed up your application—it can even slow it down 
            //if used excessively or inappropriately. For example, when heavy disk I/O is involved, it can be faster to have a couple of 
            //worker threads run tasks in sequence than to have 10 threads executing at once.

            //GETTING STARTED
            //A client program (Console, WPF, or Windows Forms) starts in a single thread that’s created automatically by the CLR 
            //and operating system (the “main” thread). Here it lives out its life as a single-threaded application, unless you do otherwise, by creating
            //more threads (directly or indirectly).

            //You can create and start a new thread by instantiating a Thread object and calling its Start method. 
            //The simplest constructor for Thread takes a ThreadStart delegate: a parameterless method indicating where execution should begin.

            Thread t = new Thread(new ThreadStart(WriteY)); // Kick off a new thread
            t.Start(); // running WriteY()
            
            //Once started, a thread’s IsAlive property returns true, until the point where the thread ends.
            Console.WriteLine("IsAlive = " + t.IsAlive.ToString());

            // Simultaneously, do something on the main thread.
            for (int i = 0; i < 500; i++) 
                Console.Write("x");

            //Start another thread and look into the Go Method
            Thread t1 = new Thread(Go);
            t1.Start();
            
            Console.WriteLine("Main thread has ended!");
        }

        static void WriteY()
        {
            //Once started, a thread’s IsAlive property returns true, until the point where the thread ends.
            for (int i = 0; i < 500; i++)
            {
                Console.Write("y");
            }
        }

        static void Go() 
        {
            Thread t2 = new Thread(GoAgain);
            t2.Start();
            //You can wait for another thread to end by calling its Join method. Here we are calling t2.Join() which means that the remaning execution of Go() method
            //will wait until t2 finishes and joins our method Go() meaning t2 will "Join" this method Go (which was actally initiated by Thread t1).
            //So the output here will be a full complete set (500 no:s) of "GoAgain" followed by (500 no:s) of "Go".
            //In short what we mean by t2.Join() is that "immediately start t2 and wait till t2 completes and joins the current thread. Then proceed forward."
            t2.Join();
            //You can include a timeout when calling Join, either in milliseconds or as a TimeSpan. It then returns true if the thread ended or false if it timed out.

            for (int i = 0; i < 500; i++)
            {
                //Thread.Sleep pauses the current thread for a specified period:
                Thread.Sleep(10); // sleep for 10 milliseconds
                Console.Write("Go");

                //Important: While a thread waits during a Sleep or Join, it’s said to be blocked.

                //Thread.Sleep(0) relinquishes the thread’s current time slice immediately, voluntarily  handing over the CPU to other threads. 
                //Framework 4.0’s new Thread.Yield() method does the same thing—except that it relinquishes only to threads running on
                //the same processor. These 2 methods are excellent diagnostic tool for helping to uncover thread safety issues: if inserting
                //Thread.Yield() anywhere in your code makes or breaks the program, you almost certainly have a bug.
            }
        }

        static void GoAgain()
        {
            for (int i = 0; i < 500; i++)
                Console.Write("GOAgain");
        }

    }
}
