using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DZ
{
    public class Program
    {
        static Task taskIO;
        public static async Task DoIOBoundOperationAsync(Action IOBoundOperation)
        {
            await Task.Factory.StartNew(IOBoundOperation);
            Console.WriteLine("I/O bound operation is end");
        }
        public static async Task<object> DoCPUBoundOperationAsync(Func<object> CPUBoundOperation)
        {
            var task = Task.Run(() => CPUBoundOperation());
            await taskIO;
            var result = await task;
            return result;
        }

        public static async Task Main(string[] args)
        {
            
            taskIO = DoIOBoundOperationAsync(() =>
            {
                 int i = 0;
                 while (i < 100)
                 {
                     Console.Write("-");
                     ++i;
                 }
                 Console.WriteLine();
            });
             
             
            var taskCPU = DoCPUBoundOperationAsync(() =>
            {
                    var matrixes = new List<int[,]>();
                    Random rnd = new Random();
                    for (int index = 0; index < 3; ++index)
                    {
                        matrixes.Add(new int[20, 20]);
                        if (index < 2)
                        {
                            for (int i = 0; i < 20; ++i)
                            {
                                for (int j = 0; j < 20; ++j)
                                {
                                    matrixes[index][i, j] = rnd.Next(20);
                                }
                            }
                        }
                    }
                    for (int i = 0; i < 20; ++i)
                    {
                        for (int j = 0; j < 20; ++j)
                        {
                            for (int iter = 0; iter < 20; ++iter)
                            {
                                matrixes[2][i, j] = matrixes[0][i, iter] * matrixes[1][iter, j];
                            }
                        }
                    }
                    return matrixes[2];
            });

            var result = (int[,])await taskCPU;

            for (int i = 0; i < 20; ++i)
            {
                for (int j = 0; j < 20; ++j)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        
    }

}
