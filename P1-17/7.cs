using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsyProgram
{
    class Program7
    {
        static void Main()
        {
            Task<int> primeNumberTask = Task.Run(() =>
                 Enumerable.Range(2, 3000000).Count(n =>
                     Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)
                ));

            Task task1 = primeNumberTask.ContinueWith(task =>
              {
                  int result = task.Result;
                  Console.WriteLine(result);// Writes result
              });
            Console.ReadLine();

        }

    }
}
