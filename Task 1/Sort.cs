using System;
using System.Collections.Generic;

namespace Sort
{

    class Program
    {
        public static void Sort<T, CollectionType>(IList<T> collection, int start, int end)
            where T: IComparable<T>
            where CollectionType : IList<T>
            
        {
            if (start < 0 || start >= end || end > collection.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            for (; start < end; ++start)
            {
                int indexMin = start;
                for (int i = start; i < end; ++i)
                {
                    
                    if (collection[i].CompareTo(collection[indexMin]) < 0)
                    {
                        indexMin = i;
                    }
                }
                
                if (indexMin != start)
                {
                    T temp = collection[start];
                    collection[start] = collection[indexMin];
                    collection[indexMin] = temp;
                }
            }
        }

        public static void Sort<T, CollectionType>(IList<T> collection, int start)
            where T : IComparable<T>
            where CollectionType : IList<T>
        {
            Sort<T, CollectionType>(collection, start, collection.Count);
        }
        public static void Sort<T, CollectionType>(IList<T> collection)
            where T : IComparable<T>
            where CollectionType : IList<T>
        {
            Sort<T, CollectionType>(collection, 0, collection.Count);
        }





        public static void Print(Array list)
        {
            foreach (var nodeValue in list)
            {
                Console.WriteLine(nodeValue);
            }
            
        }
        static void Main(string[] args)
        {


            int[] mas = { 4, 3, 2, 2 };
            Sort<int, int[]>(mas, 1, 3);
            Print(mas);
            Sort<int, int[]>(mas, 1);
            Print(mas);
            Sort<int, int[]>(mas);
            Print(mas);

        }
    }
}
