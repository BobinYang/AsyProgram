using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsyProgram
{
    class Program185
    {

        static void Main(string[] args)
        {
            DisplayPrimeCountsAysnc();
        }

        static Task DisplayPrimeCountsAysnc()
        {
            var machine = new PrimesstateMachine();
            machine.DisplayPrimeCountsFrom(0);
            return machine.Task;
        }
        public static Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() => ParallelEnumerable.Range(start, count).Count(n =>
             Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }
    }
    class PrimesstateMachine
    {
        TaskCompletionSource<Object> _tcs = new TaskCompletionSource<object>();

        public Task Task { get { return _tcs.Task; } }

        public void DisplayPrimeCountsFrom(int i)
        {
            var awaiter = Program185.GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
            awaiter.OnCompleted(() =>
                {
                    Console.WriteLine(awaiter.GetResult() + " primes between ...");
                    if (++i < 10)
                    {
                        DisplayPrimeCountsFrom(i);
                    }
                    else
                    {
                        Console.WriteLine("Done! ");
                        _tcs.SetResult(null);
                    }
                });
        }
    }
}
