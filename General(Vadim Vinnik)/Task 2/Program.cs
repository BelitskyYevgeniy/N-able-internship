using System;
using MyCollections.Generic;
namespace TestMyCollections.Genric
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
            Console.WriteLine("Count: " + list.Count);
            en.Reset();
            try
            {
                list.Remove(en as System.Collections.Generic.IEnumerator<int>);
            }
            catch
            {
                Console.WriteLine("Error is caught!");
            }

            en.Reset();
            en.MoveNext();
            en.MoveNext();
            list.Remove(en as System.Collections.Generic.IEnumerator<int>);
            Console.WriteLine(list.Remove(2));

            foreach (int nodeValue in list)
            {
                Console.WriteLine(nodeValue);
            }
            list.Clear();

        }
    }
}
