using System;
using System.Collections.Generic;

namespace DZ
{
    class Program
    {
        public static class DelegateUsageExample
        {
            public delegate T ChangeFunc<T>(T arg);

            private static double CalculateDueTime(DateTime time)
            {
                return (time - DateTime.Now).TotalMilliseconds;
            }

            public static void Transform<T>(IList<T> collection, int start, int end, ChangeFunc<T> func)
            {
                /*if(collection == null || func == null)
                {
                    throw new ArgumentNullException();
                }
                if(end >= start || start < 0 || collection.Count > end)
                {
                    throw new ArgumentException();
                }*/
                for(;start < end; ++start)
                {
                    collection[start] = func(collection[start]);
                }
            }
           
            public static System.Threading.Timer StartAlarm(DateTime time, System.Threading.TimerCallback timerCallback, long period)
            {
                /*if(timerCallback == null)
                {
                    throw new NullReferenceException();
                }*/
                if (time < DateTime.Now)
                    return null;
                var dueTime = CalculateDueTime(time);
                //Console.WriteLine(dueTime);
                return new System.Threading.Timer(timerCallback, (object)time, (long)dueTime, period);

                
            }
            public static System.Threading.Timer StartAlarm(DateTime time, System.Threading.TimerCallback timerCallback)
            {
                return StartAlarm(time, timerCallback, 1000 * 60 * 60 * 24);
            }
        }


         

        static void Main(string[] args)
        {

            var list = new List<int>() { 1, 2, 3, 4 };
            DelegateUsageExample.Transform(list, 0, 4, 
                delegate(int arg)
                {
                    return arg % 2;
                });
            foreach(var i in  list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-------------------------");
            DelegateUsageExample.StartAlarm(DateTime.Now.AddMinutes(1) ,
                 delegate (object obj)
                 {
                     Console.WriteLine(DateTime.Now);
                     Console.Beep();
                 });
            Console.ReadKey();
        }
    }
}
