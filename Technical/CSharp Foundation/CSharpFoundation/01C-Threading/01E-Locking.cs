using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharpFoundation
{
    public class _01E_Locking
    {
        //Locking:
        //*******
        //Exclusive locking is used to ensure that only one thread can enter particular sections of code at a time. The two main 
        //exclusive locking constructs are lock and Mutex. Of the two, the lock construct is faster and more convenient. Mutex, though, 
        //has a niche in that its lock can span applications in different processes on the computer.
        
        //Now let us see a class that is NOT thread-safe.
        class ThreadUnsafe
        {
            static int _val1 = 1, _val2 = 1;
            public static void Go()
            {
                if (_val2 != 0) Console.WriteLine(_val1 / _val2);
                _val2 = 0;
                //This class is not thread-safe: if Go was called by two threads simultaneously, it would
                //be possible to get a division-by-zero error, because _val2 could be set to zero in one
                //thread right as the other thread was in between executing the if statement and Console.WriteLine.
            }
        }
        //Here’s how lock can fix the problem:
        class ThreadSafe
        {
            static readonly object _locker = new object();
            static int _val1 = 1, _val2 = 1;
            public static void Go()
            {
                //Only one thread can lock the synchronizing object (in this case, _locker) at a time,
                //and any contending threads are blocked until the lock is released. If more than one
                //thread contends the lock, they are queued on a “ready queue” and granted the lock
                //on a first-come, first-served basis.† Here one thread’s access cannot overlap with that of another. 
                //In this case, we’re protecting the logic inside the Go method, as well as the fields _val1 and _val2.
                lock (_locker) 
                {
                    if (_val2 != 0) Console.WriteLine(_val1 / _val2);
                    _val2 = 0;
                }
                //A thread blocked while awaiting a contended lock has a ThreadState of WaitSleepJoin.
            }
        }

        //C#’s lock statement is in fact a syntactic shortcut for a call to the methods Monitor.Enter and Monitor.Exit, with a try/finally block.
        class ThreadSafeWithMonitor
        {
            static readonly object _locker = new object();
            static int _val1 = 1, _val2 = 1;
            public static void Go()
            {
                Monitor.Enter(_locker);
                try
                {
                    if (_val2 != 0) Console.WriteLine("Thread.ID=" + Thread.CurrentThread.ManagedThreadId + ", " + _val1 / _val2);
                    _val2 = 0;
                }
                finally
                {
                    Monitor.Exit(_locker); //Calling Monitor.Exit without first calling Monitor.Enter on the same object throws an exception.
                } 
            }
        }

        //But there’s a subtle vulnerability in the above 'Monitor' code. What happens if an exception being thrown between the call to Monitor.Enter 
        // and the try block (OutOfMemoryException for example)?In such a scenario, the lock may or may not be taken. If the lock is taken, 
        //it won’t be released—because we’ll never enter the try/finally block. This will result in a leaked lock.
        //To avoid this danger, in C# 4.0 we can use the following overload to Monitor.Enter. 
        class ThreadSafeWithMonitorOverload
        {
            static readonly object _locker = new object();
            static int _val1 = 1, _val2 = 1;
            static bool lockTaken = false;
            public static void Go()
            {
                Monitor.Enter(_locker, ref lockTaken);
                try
                {
                    if (_val2 != 0) Console.WriteLine("Thread.ID=" + Thread.CurrentThread.ManagedThreadId + ", " + _val1 / _val2);
                    _val2 = 0;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(_locker); 
                }
            }
            //Monitor also provides a TryEnter method that allows a timeout to be specified, either in milliseconds or as a TimeSpan. 
            //The method then returns true if a lock was obtained, or false if no lock was obtained because the method timed out.
        }

        //Important: 

        //Choosing the Synchronization Object : The synchronizing object (as _locker above) is typically private, readonly and an instance or static field. 
        //This allows precise control over the scope and granularity of the lock and is the preferred way of locking. Others 
        //such as lock (this), lock (typeof (Widget)) etc will make it harder to prevent deadlocking and excessive blocking.

        //When to Lock :As a basic rule, you need to lock around accessing any writable shared field (defined typically as static). 
        //Even in the simplest case — an assignment operation on a single field—you must consider synchronization.

        //Locking and Atomicity: If a group of variables are always read and written within the same lock, you can say
        //the variables are read and written atomically.

        //Nested Locking: A thread can repeatedly lock the same object in a nested (reentrant) fashion. In these scenarios, 
        //the object is unlocked only when the outermost lock statement has exited—or a matching number of Monitor.Exit statements have executed.

        //Deadlocks: A deadlock happens when two threads each wait for a resource held by the other, so neither can proceed. (See book for example).
        //To avoid deadlocks, we must lock objects in a consistent order. A better strategy is to be wary of locking around calling methods in objects that may have
        //references back to your own object.

        //Performance: Locking is fast - you can expect to acquire and release a lock in less than 100 nanoseconds.

        //Mutex:A Mutex is like a C# lock, but it can work across multiple processes. In other words, Mutex can be computer-wide as well as application-wide.
        public class MutexDemo
        {
            public static void FunX()
            {
                // Naming a Mutex makes it available computer-wide. Use a name that's
                // unique to your company and application (e.g., include your URL).
                using (var mutex = new Mutex(false, "my.mphasis.com ThreadingDemo"))
                {
                    //With a Mutex class, you call the WaitOne method to lock and ReleaseMutex to unlock.
                    //Closing or disposing a Mutex automatically releases it. Just as with the lock statement,
                    //a Mutex can be released only from the same thread that obtained it.

                    //Wait a few seconds if contended, in case another instance
                    //of the program is still in the process of shutting down.
                    if (mutex.WaitOne(TimeSpan.FromSeconds(3), false))
                    {
                        RunProgram();
                    }
                    else
                    {
                        Console.WriteLine("Another instance of the app is running. Bye...");
                    }
                }
            }


            static void RunProgram()
            {
                Console.WriteLine("Running from Mutex pgm. Press Enter to exit");
                Console.ReadLine(); //This line is important as it will keep the Mutex active and locked.
            }
        }

        //Semaphore:
        //A semaphore is like a nightclub: it has a certain capacity, enforced by a bouncer. Once it’s full, no more people can enter, 
        //and a queue builds up outside. Then, for each person that leaves, one person enters from the head of the queue. The constructor
        //requires a minimum of two arguments: the number of places currently available in the nightclub and the club’s total capacity.
        //A semaphore with a capacity of one is similar to a Mutex or lock, except that the semaphore has no “owner”—it’s thread-agnostic. 
        //Any thread can call Release on a Semaphore, whereas with Mutex and lock, only the thread that obtained the lock can release it.
        //There are two functionally similar versions of this class: Semaphore and SemaphoreSlim (for 4.0, a lighter version)
        //Important: Semaphores can be useful in limiting concurrency—preventing too many threads from executing a particular piece of code at once.
        public class SemaphoreDemo
        {
            static SemaphoreSlim _sem = new SemaphoreSlim(3); // Capacity of 3 meaning places available and total capacity, both equals 3               

            public static void Start()
            {
                for (int i = 1; i <= 5; i++) new Thread(Enter).Start(i);
            }

            private static void Enter(object id)
            {
                Console.WriteLine(id + " wants to enter");
                _sem.Wait();
                Console.WriteLine(id + " is in!");  // Only three threads can be here at a time.
                Thread.Sleep(1000 * (int)id);
                Console.WriteLine(id + " is leaving");
                _sem.Release();
            }
        }

        public static void RunLocking()
        {
            Thread t1 = new Thread(() => ThreadUnsafe.Go());
            Thread t2 = new Thread(() => ThreadUnsafe.Go());
            t1.Start(); t2.Start();

            Thread t3 = new Thread(() => ThreadSafe.Go());
            Thread t4 = new Thread(() => ThreadSafe.Go());
            t3.Start(); t4.Start();

            Thread t5 = new Thread(() => ThreadSafeWithMonitor.Go());
            Thread t6 = new Thread(() => ThreadSafeWithMonitor.Go());
            t5.Start(); t6.Start();

            Thread t7 = new Thread(() => MutexDemo.FunX());
            t7.Start();

            Thread t8 = new Thread(() => SemaphoreDemo.Start());
            t8.Start();

        }        
    }
}
