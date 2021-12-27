using System;
using System.Collections;
using System.Collections.Generic;
namespace SPP_9
{
    public class DynamicList<T> : IEnumerable<T>
    {
        public int Count { private set; get; }

        public T[] Items;

        public DynamicList()
        {
            Items = Array.Empty<T>();
        }

        public void Add(T element)
        {
            T[] temp = new T[Count + 1];
            Array.Copy(Items, temp, Items.Length);
            temp[Count] = element;
            Items = temp;
            Count++;
        }

        public void Remove(T element)
        {
            Remove(Array.IndexOf(Items, element));
        }

        public void Remove(int index)
        {
            Array.Copy(Items, index + 1, Items, index, Count - index - 1);
            Count--;
            Items[Count] = default;
        }

        public void Clear()
        {
            Items = Array.Empty<T>();
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return Items[i];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
