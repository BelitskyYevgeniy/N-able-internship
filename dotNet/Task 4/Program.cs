using System;

namespace DZ
{
    class Program
    {
        public static class Converter
        {
            public const decimal BYNInUSD = 2.589m;



            public static int ConvertToInt32<T>(T value)
            {
                if (value == null)
                    return 0;
                var type = value.GetType().ToString();
                switch (type)
                {

                    case "System.String":
                        {
                            int result;
                            if (!Int32.TryParse((string)Convert.ToString(value), out result))
                            {
                                throw new ArgumentException();
                            }
                            return result;

                        }
                    case "System.Single": return (int)Convert.ToSingle(value);
                    case "System.Double": return (int)Convert.ToDouble(value);
                    default: throw new ArgumentException();
                }
            }
            public static string ConvertToString<T>(T value)
            {
                return value.ToString();
            }

            public static decimal ConvertBYNToUSD(decimal value)
            {
                return value / BYNInUSD;
            }
            public static decimal ConvertUSDToBYN(decimal value)
            {
                return value * BYNInUSD;
            }


        }

        public static class SpecCalculator
        {
            public static double CalculateMean(int a, int b)
            {
                var numbers = new int[2] { a, b };
                return CalculateMean(numbers);
            }

            public static double CalculateMean(int[] numbers)//should i throw my null reference exception if indexing of null will throw exception without my handling
            {
                /*if (numbers == null)
                {
                    throw new ArgumentNullException();
                }*/
                int result = 0;
                foreach (var i in numbers)
                {
                    result += i;
                }
                return (double)result / numbers.Length;
            }

            public static void Swap(ref dynamic a, ref dynamic b)
            {
                a = a + b;
                b = a - b;
                a = a - b;
            }

            public static void Swap<T>(ref T a, ref T b)
                where T : struct
            {
                T c = a;
                a = b;
                b = c;
            }
        }



        static void Main(string[] args)
        {
            Console.WriteLine(Converter.ConvertToInt32<double>(5.5));
            Console.WriteLine(Converter.ConvertToInt32<string>("5"));
            Console.WriteLine(Converter.ConvertToInt32<float>(5.5f));

            Console.WriteLine(Converter.ConvertToString(DateTime.Now));

            Console.WriteLine(SpecCalculator.CalculateMean(3, 4));

            Console.WriteLine(Converter.ConvertBYNToUSD(2m));


            int a = 2;
            int b = 5;
            SpecCalculator.Swap<int>(ref a, ref b);
            Console.WriteLine($"a={ a}; b={b}");
            dynamic a_ = 2;
            dynamic b_ = 5;
            SpecCalculator.Swap(ref a_, ref b_);
            Console.WriteLine($"a={ a_}; b={b_}");
        }
    }
}
