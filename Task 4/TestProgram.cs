using System;
using System.Threading;
using System.Collections.Generic;
namespace Synchronization
{

    class TestProgram
    {

        static Syncronizer ts = new Syncronizer();
        static bool isAllowedToEnd = false;

        static void ThreadLog(string typeThread)
        {
            Console.WriteLine(  $"Type of thread: {typeThread}\n" +
                                $"Threads id: {Thread.CurrentThread.ManagedThreadId}\n");
            Console.WriteLine(  $"Writers Count: {ts.WritersCount}\n" +
                                $"Readers Count: {ts.ReadersCount}\n" +
                                "-------------------------------------------");
        }
        
        static void TestFunc(object IsWriter)
        {
            bool isWriter = (bool)IsWriter;
            if (isWriter)
                ts.EnterWriter();
            else
                ts.EnterReader();

            ThreadLog(isWriter?"Writer":"Reader");

            while (!isAllowedToEnd)
            {
                Thread.Sleep(5);
            }
                if (isWriter)
                    ts.ReleaseWriter();
                else
                    ts.ReleaseReader();
            
        }
        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();

            threads.Add(new Thread(new ParameterizedThreadStart(TestFunc)));
            threads[0].Start(false);
            Console.ReadKey();
            threads.Add(new Thread(new ParameterizedThreadStart(TestFunc)));
            threads[1].Start(true);
            Console.ReadKey();
            threads.Add(new Thread(new ParameterizedThreadStart(TestFunc)));
            threads[2].Start(false);
            Console.ReadKey();
            isAllowedToEnd = true;

            foreach(var t in threads)
            {
                if(t.IsAlive)
                    t.Join();
            }
        }
    }
}