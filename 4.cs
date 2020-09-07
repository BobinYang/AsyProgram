using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsyProgram
{
    class Program4
    {
        static void Main()
        {
            Task<int> primeNumberTask = Task.Run(() =>
                 Enumerable.Range(2, 3000000).Count(n =>
                     Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)
                ));

            Console.WriteLine("Task Rungin...");
            Console.WriteLine("The answer is " + primeNumberTask.Result);
        }
    }
}