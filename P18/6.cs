using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsyProgram
{
    class Program186
    {

        async static void Main(string[] args)
        {
            await DisplayPrimeCountsAysnc();
        }

        async static Task DisplayPrimeCountsAysnc()
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine(await GetPrimesCountAsync(i * 1000000 + 2, 1000000) +
                " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1));
            Console.WriteLine("Done! ");
        }

        static Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() => ParallelEnumerable.Range(start, count).Count(n =>
                   Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }

    }
}