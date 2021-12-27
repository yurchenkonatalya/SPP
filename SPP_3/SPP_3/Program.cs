
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPP_3
{
    class Program
    {
        private static Mutex mutex = new Mutex();
        static void Main(string[] args)
        {

            for (int i = 0; i < 3; i++)
            {
                Thread thread = new Thread(print);
                thread.Start();
            }
            Console.ReadLine();
         }

    public static void print()
    {
        mutex.Lock();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("thread " + Thread.CurrentThread.ManagedThreadId + " step " + i);
        }
        mutex.Unlock();
    }
}
}
