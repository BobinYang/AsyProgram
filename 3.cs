using System;
using System.Threading.Tasks;

namespace AsyProgram
{
    class Program3
    {
        static void Main()
        {
            Task<int> task = Task.Run(() =>
            {
                Console.WriteLine("Foo");
                return 3;
            });
            int result = task.Result;
            Console.WriteLine(result);

        }
    }
}