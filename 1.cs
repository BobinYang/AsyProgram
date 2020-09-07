using System;
using System.Threading.Tasks;

namespace AsyProgram
{
    class Program1
    {
        static void Main()
        {
            Task.Run(() => Console.WriteLine("a"));
            Task.Factory.StartNew(() => Console.WriteLine("a"));


        }
    }
}