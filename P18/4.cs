using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsyProgram
{
    class Program184
    {

        static void Main(string[] args)
        {
            DisplayPrimeCounts();
        }

        static void DisplayPrimeCounts()
        {
            DisplayPrimeCountsFrom(0);
        }

        static void DisplayPrimeCountsFrom(int i)
        {
            var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
            awaiter.OnCompleted(() =>
                {
                    Console.WriteLine(awaiter.GetResult() + " primes between ...");
                    if (++i < 10)
                    {
                        DisplayPrimeCountsFrom(i);
                    }
                    else Console.WriteLine("Done! ");
                });
        }

        static Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() => ParallelEnumerable.Range(start, count).Count(n =>
              Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }

    }
}