using System;

namespace SPP_6
{
    class Program
    {
        static void Main(string[] args)
        {
            LogBuffer logBuffer = new LogBuffer(5, 2000, "/Users/yurchenkonatalya/Projects/SPP_6/file.txt");

            for (int i = 0; i < 200; i++)
            {
                logBuffer.Add(i.ToString());
            }
            logBuffer.Close();
            Console.WriteLine("Готово");
            Console.ReadLine();
        }
    }
}
