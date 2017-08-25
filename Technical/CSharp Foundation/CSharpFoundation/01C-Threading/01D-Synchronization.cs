using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharpFoundation
{
    public class _01D_Synchronization
    {
        //Synchronization: Coordinating the actions of threads for a predictable outcome. Synchronization is particularly important when threads access the same
        //data; else it will cause critical problems/bugs.

        //Synchronization constructs can be divided into four categories:
        //Simple blocking methods: These wait for another thread to finish or for a period of time to elapse. Sleep, Join, and Task.Wait are simple blocking methods.
        //Locking constructs :These limit the number of threads that can perform some activity or execute a section of code at a time. These are further classified into
        //  Exclusive locking constructs (Monitor.Enter/Monitor.Exit, Mutex,SpinLock) or 
        //  Nonexclusive locking constructs (Semaphore, SemaphoreSlim, and ReaderWriterLockSlim)
        //Signaling constructs: These allow a thread to pause until receiving a notification from another, avoiding the need for inefficient polling.
        //Nonblocking synchronization constructs: These protect access to a common field by calling upon processor primitives (like Thread.MemoryBarrier, 
        //  Thread.VolatileRead, Thread.VolatileWrite etc.
        public static void RunBlocking()
        {
            //Blocking:
            //A thread is deemed blocked when its execution is paused for some reason, such as when Sleeping or waiting for another to end 
            //via Join or EndInvoke. A blocked thread immediately yields its processor time slice, and from then on consumes no processor
            //time until its blocking condition is satisfied.
            //You can test for a thread being blocked via its ThreadState property:
            //bool isBlocked = (t1.ThreadState & ThreadState.WaitSleepJoin) != 0;
            //Console.WriteLine("This thread t1 is in: isBlockedState = " + isBlocked.ToString());
            //Important: When a thread blocks or unblocks, the operating system performs a contextswitch. 
            //This incurs an overhead of a few microseconds.

            //Blocking Versus Spinning: 
            //A thread can await a condition by "spinning" in a polling loop as : while (!proceed); 
            //Generally spinning is very wasteful on processor time: It is better to use Signaling and locking constructs to achieve this efficiently 
            //by blocking until a condition is satisfied.
        }

    }
}
