using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsyProgram
{
    class Program6
    {
        static void Main()
        {
            Task<int> primeNumberTask = Task.Run(() =>
                 Enumerable.Range(2, 3000000).Count(n =>
                     Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)
                ));

            var awaiter = primeNumberTask.GetAwaiter();
            //var awaiter = primeNumberTask.ConfigureAwait(false).GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int result = awaiter.GetResult();
                Console.WriteLine(result);// Writes result
            });
            Console.ReadLine();

        }
    }
}