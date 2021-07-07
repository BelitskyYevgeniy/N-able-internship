using System;
using System.Collections;
using System.Collections.Generic;

namespace MyCollections.Generic
{

    class Program
    {
       
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            var en = list.GetEnumerator();
            list.Add(en, 5);
            list.Add(1);
            list.Add(2);
            en.Reset();
            list.Add(en, 3);
            en = list.GetEnumerator();
            en.MoveNext();
            en.MoveNext();
            list.Add(en, 4);
            foreach (int nodeValue in list)
            {
                Console.WriteLine(nodeValue);
            }

            en.Reset();
            try
            {
                list.Remove(en as IEnumerator<int>);
            }
            catch
            {
                Console.WriteLine("Error is caught!");
            }

            en.Reset();
            en.MoveNext();
            en.MoveNext();
            list.Remove(en as IEnumerator<int>);
            Console.WriteLine(list.Remove(2));

            foreach (int nodeValue in list)
            {
                Console.WriteLine(nodeValue);
            }
            list.Clear();
            foreach (int nodeValue in list)
            {
                Console.WriteLine(nodeValue);
            }
        }
    }
}
