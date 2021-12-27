using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
///Users/yurchenkonatalya/Desktop/bsuir/source
///Users/yurchenkonatalya/Desktop/bsuir/target
namespace SPP_2
{
    delegate void TaskDelegate(string from, string to);

    class Program
    {

        private static ThreadPool threadPool;
        private static string source_directory;
        private static string final_directory;

        static void Main(string[] args)
        {
            Console.WriteLine("Исходная папка");
            source_directory = Console.ReadLine();

            Console.WriteLine("Конечная папка");
            final_directory = Console.ReadLine();


            if (Directory.Exists(source_directory) && Directory.Exists(final_directory))
            {
                threadPool = new ThreadPool(7);
                List<string> list = new List<string>();
                rec(list, source_directory);


                foreach (string file in list)
                {
                    threadPool.EnqueueTask(copyFile, new CopyFileInfo(file, final_directory));
                }
            }
            else
            {
                Console.WriteLine("Папка не существует");
            }

            while (threadPool.getTasks() != 0)
            {

            }
            threadPool.count = threadPool.count - 1;
            Console.WriteLine($"Скопированно файл : {threadPool.count }");


            Console.ReadLine();
        }

        public static void rec(List<string> list, string directory)
        {
            string[] files = Directory.GetFiles(directory); 
            foreach (string file in files)
            {
                list.Add(file);
            }
            string[] dirs = Directory.GetDirectories(directory);
            foreach (string dir in dirs)
            {
                rec(list, dir);
            }
        }

        public static void copyFile(string from, string to)
        {
            File.Copy(from, to, true);
            Thread.Sleep(1);
        }
    }
}