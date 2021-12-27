using System;
using System.Collections.Generic;

namespace SPP_9
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Remove(5);

            IEnumerator<int> enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            enumerator.Dispose();
        }
    }
}
