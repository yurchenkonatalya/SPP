﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
namespace SPP_5
{
    class Program
    {
          static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к dll файлу");
        string path = Console.ReadLine();
        if (!File.Exists(path))
        {
            Console.WriteLine("Неверный путь");
            Console.ReadLine();
            return;
        }

        string extension = Path.GetExtension(path);

        if (extension.Equals(".dll") || extension.Equals(".exe"))
        {
            Assembly asm = Assembly.LoadFrom(path);
            var types = asm.GetTypes().Where(type => type.IsPublic).OrderBy(type => type.Namespace).ThenBy(type => type.Name);
                foreach (Type t in types)
                {
                    Console.WriteLine(t.FullName);
                }
        }
        else
        {
            Console.WriteLine("У файла неверное расширение");
        }
        Console.ReadLine();
    }
}
}
