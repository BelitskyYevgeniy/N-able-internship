using System;
using System.Collections.Generic;
using System.Linq;
namespace DZ
{
    class Program
    {
        public enum SubjectType
        {
            Math,
            English
        }
        [Serializable]
        public struct Grade
        {
            private float _grade;
            public SubjectType Subject { get; set; } //made for example of modification possibility 
            public float Value
            {
                get => _grade;
                set
                {
                    if (value < 0 || value > 100)
                    {
                        throw new ArgumentException();
                    }
                    _grade = value;
                }
            }
        }

        [Serializable]
        public class Student
        {
            public int Id { get; set; }
            //something
        }
        [Serializable]
        public class ElectronicBook
        {
            public delegate void StatisticFunc<T>(Grade grade, ref T data);

            public int StudentId { get; set; }
            public IEnumerable<Grade> Grades { get; set; }
            public ElectronicBook()
            {
                //Deserialization
                Grades = new List<Grade>()
                {
                    new Grade{ Value = 50.5f, Subject = SubjectType.Math},
                    new Grade{ Value = 30.5f, Subject = SubjectType.English},
                    new Grade{ Value = 88.5f, Subject = SubjectType.Math}

                };
            }

            public void ProcessBook<T>(StatisticFunc<T> func, ref T data)
            {
                foreach (var grade in Grades)
                {
                    func(grade, ref data);
                }
            }
        }

        public static class AdditionFunctionality
        {
            private class AverageStat
            {
                public float Result { get; set; }
                public int Count { get; set; }
            }
            private static void IterAverage(Grade grab, ref AverageStat data)
            {
                data.Result += grab.Value;
                ++data.Count;
            }
            private static void CheckLowest(Grade grab, ref float data)
            {
                if (grab.Value < data)
                {
                    data = grab.Value;
                }
            }
            private static void CheckHighest(Grade grab, ref float data)
            {
                if (grab.Value > data)
                {
                    data = grab.Value;
                }
            }
            public static double Average(ElectronicBook book)
            {
                if (book == null)
                {
                    throw new NullReferenceException();
                };
                var stat = new AverageStat { Result = 0f, Count = 0 };
                book.ProcessBook<AverageStat>(IterAverage, ref stat);
                return stat.Result / stat.Count;
            }

            public static float TakeHighest(ElectronicBook book)
            {
                if (book == null)
                {
                    throw new NullReferenceException();
                };
                float highest = 0f;
                book.ProcessBook<float>(CheckHighest, ref highest);
                return highest;
            }
            public static float TakeLowest(ElectronicBook book)
            {
                if (book == null)
                {
                    throw new NullReferenceException();
                };
                float lowest = 100f;
                book.ProcessBook<float>(CheckLowest, ref lowest);
                return lowest;
            }
        }
        public static class AdditionFunctionalityUsingLINQ
        {
            
            
            public static double Average(ElectronicBook book)
            {
                if (book == null)
                {
                    throw new NullReferenceException();
                };
                var sum = book.Grades.Sum(grade => grade.Value);
                return sum / book.Grades.Count();
            }

            public static float TakeHighest(ElectronicBook book)
            {
                if (book == null)
                {
                    throw new NullReferenceException();
                };
                return book.Grades.Max(grade => grade.Value);
            }
            public static float TakeLowest(ElectronicBook book)
            {
                if (book == null)
                {
                    throw new NullReferenceException();
                };
                return book.Grades.Min(grade => grade.Value);
            }
        }


        static void Main(string[] args)
        {
            ElectronicBook book = new ElectronicBook();
            Console.WriteLine(AdditionFunctionality.Average(book));
            Console.WriteLine(AdditionFunctionality.TakeHighest(book));
            Console.WriteLine(AdditionFunctionality.TakeLowest(book));

            Console.WriteLine(AdditionFunctionalityUsingLINQ.Average(book));
            Console.WriteLine(AdditionFunctionalityUsingLINQ.TakeHighest(book));
            Console.WriteLine(AdditionFunctionalityUsingLINQ.TakeLowest(book));
        }
    }
}

