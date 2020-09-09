using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyProgram
{
    class Program9
    {
        static void Main()
        {
            Task<int> task = Run(() =>
            {
                Thread.Sleep(5000);
                return 42;
            });

        }

        static Task<TResult> Run<TResult>(Func<TResult> function)
        {
            var tcs = new TaskCompletionSource<TResult>();
            new Thread(() =>
            {
                try
                {
                    tcs.SetResult(function());
                }
                catch (System.Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).Start();
            return tcs.Task;
        }
    }
}