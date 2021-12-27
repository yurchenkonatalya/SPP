using System;
using System.Threading;

namespace SPP_1
{
    class Program
    {
        private static int numberTreads = 4;
        static void Main(string[] args)
        {
            TaskQueue task = new TaskQueue(numberTreads);

            task.EnqueueTask(CreateDelegate("1"));
            task.EnqueueTask(CreateDelegate("2"));
            task.EnqueueTask(CreateDelegate("3"));
            task.EnqueueTask(CreateDelegate("4"));
            task.EnqueueTask(CreateDelegate("5"));
        }

        private static TaskQueue.TaskDelegate CreateDelegate(String str)
        {
            return () =>
            {
                Console.WriteLine(str);
                Thread.SpinWait(5000);
            };
        }
    }
}
