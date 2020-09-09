using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyProgram
{
    class Program8
    {
        static void Main()
        {
            var tcs = new TaskCompletionSource<int>();
            new Thread(() =>
            {
                Thread.Sleep(5000);
                tcs.SetResult(42);
            })
            {
                IsBackground = true
            }.Start();

            Task<int> task = tcs.Task;
            Console.WriteLine(task.Result);

        }
    }
}