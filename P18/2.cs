using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsyProgram
{
    class Program182
    {

        static void Main(string[] args)
        {
            //DisplayPrimeCounts();
            Task.Run(() => DisplayPrimeCounts());
        }

        static void DisplayPrimeCounts()
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine(GetPrimesCount(i * 1000000 + 2, 1000000) +
                " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1));
            Console.WriteLine("Done! ");
        }

        static int GetPrimesCount(int start, int count)
        {
            return ParallelEnumerable.Range(start, count).Count(n =>
            Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
        }

    }
}