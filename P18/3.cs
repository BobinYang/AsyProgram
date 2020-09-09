using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsyProgram
{
    class Program183
    {

        static void Main(string[] args)
        {
            DisplayPrimeCounts();
        }

        static void DisplayPrimeCounts()
        {
            for (int i = 0; i < 10; i++)
            {
                var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
                awaiter.OnCompleted(() =>
                    Console.WriteLine(awaiter.GetResult() +
                    " primes between ..."));
            }
            Console.WriteLine("Done! ");
        }

        static Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() => ParallelEnumerable.Range(start, count).Count(n =>
              Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }
    }
}