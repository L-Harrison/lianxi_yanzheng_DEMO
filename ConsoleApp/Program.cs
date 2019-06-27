using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //进度条 
            new AsyncAwait().ProgressBar();
            //异步编程
            //new AsyncAwait().DoSomethings();
            Console.ReadLine();
        }   
    }       
}
