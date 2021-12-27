using System;
using System.Linq;
using System.Reflection;
///Users/yurchenkonatalya/Projects/SPP_8/SPP_8/bin/Debug/netcoreapp3.1/SPP_8.dll
namespace SPP_8
{
    class Program
    {
        static void Main(string[] args)
        {
          
            string path = Console.ReadLine();
            Assembly assembly = Assembly.LoadFrom(path);
            var types = assembly.GetTypes().Where(t => t.IsPublic && t.IsDefined(typeof(ExportClass), false));
            Console.WriteLine("ExportClass:");
            foreach (var type in types)
            {
                Console.WriteLine(type.FullName);
            }
            Console.ReadLine();
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ExportClass : Attribute { }

    [ExportClass]
    public class PublicClass { }
    [ExportClass]
    internal class InternalClass { }
}
