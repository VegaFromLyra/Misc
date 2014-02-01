using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// passing data between threads
// Option (1) - Create a delegate with signature void functioName (Object data)
// Pass this functionName as a parameter to new Thread()/constructor
// and then pass the parameter in thread.Start()
// Disadvantage is that this approach is not type safe

// Option(2)

namespace Threads
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from main thread");

            bool done = false;

            while (!done)
            {
                Console.WriteLine("Enter stop to stop");

                int dataToBePassed = 5;

                // Approach 1
                Thread workerThread1 = new Thread(workerRoutine);
                workerThread1.Start(dataToBePassed);

                // Approach 2
                // Encapsulate state and methods in a class and use callabck
                ThreadWithState tws = new ThreadWithState(dataToBePassed, ResultCallback);
                Thread workerThread2 = new Thread(tws.ThreadProc);
                workerThread2.Start();

                string input = Console.ReadLine();

                if (String.Equals(input, "stop", StringComparison.OrdinalIgnoreCase))
                {
                    done = true;
                }
            }
        }

        static void ResultCallback(int value)
        {
            Console.WriteLine("Value in callback is {0}", value);
        }

        static void workerRoutine(object data)
        {
            Console.WriteLine("Hello from worker thread 1");
            Console.WriteLine("Passed in data in worker thread1 is {0}", data);
        }





    }
}
