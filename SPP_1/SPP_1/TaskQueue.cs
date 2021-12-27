using System;
using System.Threading;
using System.Collections.Generic;
namespace SPP_1
{
    public class TaskQueue
    {
        Queue<TaskDelegate> queueTasks = new Queue<TaskDelegate>();
        public delegate void TaskDelegate();

        public TaskQueue (int n)
        {
            Thread[] threads = new Thread[n];
            while(n != 0)
            {
                threads[n - 1] = new Thread(Method);
                threads[n - 1].Start();
                n--;
            }
        }

        public void EnqueueTask(TaskDelegate task)
        {
            lock (queueTasks)
            {
                queueTasks.Enqueue(task);
            }
        }

        private void Method()
        {

            while (true)
            {
                TaskDelegate task = null;
                lock (queueTasks)
                {
                    if (queueTasks.Count != 0)
                    {
                        task = queueTasks.Dequeue();
                    }
                }
                if (task != null)
                {
                    task();
                }
            }
        }
    }
}
