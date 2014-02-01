using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    public delegate void ThreadCallback(int response);

    public class ThreadWithState
    {
        private int Data;

        // If the worker threads needs
        // to communicate back to main thread 
        // then it needs a callback method
        private ThreadCallback callback;

        public ThreadWithState(int data, ThreadCallback threadCallback)
        {
            Data = data;
            callback = threadCallback;
        }

        public void ThreadProc()
        {
            Console.WriteLine("Hello from worker thread 2");
            Console.WriteLine("Passed in data in worker thread2 is {0}", Data);

            if (callback != null)
            {
                Data++;
                callback(Data);
            }
        }
    }
}
