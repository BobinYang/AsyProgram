
using System;
using System.Threading.Tasks;

namespace AsyProgram
{
    class Program10
    {
        static void Main(string[] args)
        {
            var awaiter = GetAnswerToLife().GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine(awaiter.GetResult());
            });
        }

        static Task<int> GetAnswerToLife()
        {
            var tcs = new TaskCompletionSource<int>();
            var timer = new System.Timers.Timer(5000) { AutoReset = false };
            timer.Elapsed += delegate
            {
                timer.Dispose();
                tcs.SetResult(42);
            };
            timer.Start();
            return tcs.Task;
        }
    }
}