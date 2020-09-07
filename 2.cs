using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyProgram
{
    class Program2
    {
        static void Main()
        {
            Task task = Task.Run(() =>
             {
                 Thread.Sleep(3000);
                 Console.WriteLine("Foo");
             });
            Console.WriteLine(task.IsCompleted);
            task.Wait();
            Console.WriteLine(task.IsCompleted);
        }
    }
}