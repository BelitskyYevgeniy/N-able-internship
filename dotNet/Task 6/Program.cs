using System;
using System.Collections.Generic;
using System.Linq;

namespace DZ
{
    public class Program
    { 
        public static class LinqUsageExampleClass
        {
            public static int[] TakeEvenNumbers(IEnumerable<int> collection)
            {
                return collection.Where(element => element % 2 == 0).ToArray();
            }
            public static string[] TakeWordsStartedFrom(IEnumerable<string> collection, char startCharacter)
            {
                return collection.Where(element => element[0]=='A').ToArray();
            }
        }
        public static void Main(string[] args)
        {
            var numbers = new int[] { 1, 2, 3, 4 };
            foreach (var number in LinqUsageExampleClass.TakeEvenNumbers(numbers))
            {
                Console.WriteLine(number);
            }
            var words = new string[] { "asdf", "Array", "24124", "AsA" };

            foreach (var word in LinqUsageExampleClass.TakeWordsStartedFrom(words, 'A'))
            {
                Console.WriteLine(word);
            }
            
        }
    }

}
