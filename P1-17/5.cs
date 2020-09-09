using System;
using System.Threading.Tasks;

namespace AsyProgram
{
    class Program5
    {
        static void Main()
        {
            Task task = Task.Run(() => { throw null; });
            try
            {
                task.Wait();
            }
            catch (AggregateException aex)
            {
                if (aex.InnerException is NullReferenceException)
                    Console.WriteLine("Null");
                else
                    throw;

            }
        }
    }
}