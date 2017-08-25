using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharpFoundation
{
    public class _01C_ThreadPooling
    {
        //Thread Pooling
        //Whenever you start a thread, a few hundred microseconds are spent organizing such things as a fresh private local variable stack. 
        //Each thread also consumes (by default) around 1 MB of memory. The thread pool cuts these overheads by sharing and recycling threads, 
        //allowing multithreading to be applied at a very granular level without a performance penalty. This is useful when leveraging multicore processors to
        //execute computationally intensive code in parallel in “divide-and-conquer” style.
        
        //There are a number of ways to enter the thread pool:
        //  • Via the Task Parallel Library or PLINQ (from Framework 4.0)
        //  • By calling ThreadPool.QueueUserWorkItem
        //  • Via asynchronous delegates
        //  • Via BackgroundWorker

        //WCF, Remoting, ASP.NET, and ASMX Web Services application servers use the thread pool indirectly.
        
        //There are a few things to be wary of when using pooled threads:
        //  • You cannot set the Name of a pooled thread, making debugging more difficult.
        //  • Pooled threads are always background threads

        public static void RunThreadPooling()
        {
            RunThreadPoolingWithTPL();
            RunThreadPoolingWithoutTPL();
        }

        public static void RunThreadPoolingWithTPL()
        {
            //Entering the Thread Pool via TPL: 
            //*********************************
            //You can enter the thread pool easily using the Task classes in the Task Parallel Library.
            //These were introduced in Framework 4.0: if you’re familiar with the older constructs, consider the nongeneric Task class a replacement 
            //for ThreadPool.QueueUserWorkItem, and the generic Task<TResult> a replacement for asynchronous delegates.
            Task t = Task.Factory.StartNew(Go);       
            
            //The generic Task<TResult> class is a subclass of the nongeneric Task. It lets you get a return value back from the task 
            //after it finishes executing.

            // Start the task executing:
            Task<string> task = Task.Factory.StartNew<string>(() => DownloadString("http://sivablogz.wordpress.com"));
            
            // We can do other work here and it will execute in parallel:
            Go();

            // When we need the task's return value, we query its Result property:
            // If it's still executing, the current thread will now block (wait)
            // until the task finishes:
            string result = task.Result;
            Console.WriteLine(result);

            //Any unhandled exceptions are automatically rethrown when you query the task’s Result property, wrapped in an 
            //AggregateException. However, if you fail to query its Result property (and don’t call Wait), any unhandled exception will take the
            //process down.

        }

        public static void RunThreadPoolingWithoutTPL()
        {
            //Entering the Thread Pool Without TPL
            //************************************
            //ThreadPool.QueueUserWorkItem
            //****************************
            //Since you can’t use the Task Parallel Library if you’re targeting an earlier version of
            //the .NET Framework you must use one of the older constructs for entering the thread pool: ThreadPool.QueueUserWorkItem and asynchronous delegates.
            //Our target method, below, must accept a single object argument (to satisfy the WaitCallback delegate).
            ThreadPool.QueueUserWorkItem((p) => Go());
            ThreadPool.QueueUserWorkItem((p) => Go("Hello"));
            Console.WriteLine("Press any key");
            Console.ReadLine();

            //Asynchronous delegates
            //**********************
            //ThreadPool.QueueUserWorkItem doesn’t provide an easy mechanism for getting return  values back from a thread after it has finished executing. 
            //Also unhandled exceptions will take down the program. Asynchronous delegates solve this, allowing any number of typed 
            //arguments to be passed in both directions. Also unhandled exceptions on asynchronous delegates are conveniently rethrown on the original thread.
            Func<string, int> method = CalculateLength;
            IAsyncResult token = method.BeginInvoke("Testing Async Delegates", null, null);
            
            //Below we can do some costly opertion, here..we just sleep for 1 sec.
            Thread.Sleep(1000);

            //EndInvoke does three things. First, it waits for the asynchronous delegate to finish
            //executing, if it hasn’t already. Second, it receives the return value (as well as any
            //ref or out parameters). Third, it throws any unhandled worker exception back to
            //the calling thread.
            int result = method.EndInvoke(token);
            Console.WriteLine("String length is: " + result);

            
            //You can also specify a callback delegate when calling BeginInvoke—a method accepting an IAsyncResult object 
            //that’s automatically called upon completion.
            method.BeginInvoke("AnotherString", (asyncRes) =>
            {
                var target = (Func<string, int>)asyncRes.AsyncState;
                result = target.EndInvoke(asyncRes);
                Console.WriteLine("String length is: " + result);
            }, method); //The final argument to BeginInvoke is a user state object that populates the AsyncState property of IAsyncResult, it can be anything u like,
            //in this case, we’re using it to pass the method delegate to the completion callback, so we can call EndInvoke on it.
            Console.WriteLine("Press any key");
            Console.ReadLine();

            //****FOR Optimizing the Thread Pool, see book
        }

        static string DownloadString(string uri)
        {
            Console.WriteLine("Will now download content from : " + uri);
            Console.WriteLine("Press any key");
            Console.ReadLine();
            using (var wc = new System.Net.WebClient())
                return wc.DownloadString(uri);
        }

        static void Go()
        {
            Console.WriteLine("Hello from the thread pool!");
        }

        static void Go(string msg)
        {
            Console.WriteLine("Hello from the thread pool:" + msg);
        }

        static int CalculateLength(string s) { return s.Length; }
    }
}
