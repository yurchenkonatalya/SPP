using System;
using System.Diagnostics;

namespace SPP4
{
    class Program
    {
        static void Main(string[] args)
        {
            IntPtr process = CreateProcess();
            OSHandle handle = new(process);
            Console.ReadLine();
            handle.Dispose();
        }

        private static IntPtr CreateProcess()
        {
            Process process = new();
            process.StartInfo.FileName = "/Users/yurchenkonatalya/Desktop/test.txt";
            process.StartInfo.UseShellExecute = true;
            process.Start();
            return process.Handle;
        }
    }
}