using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            #region 接口实现demo 注意区分
            Console.ReadLine();
            InterfaceDemo_1.Mayor mayor = new InterfaceDemo_1.Mayor();
            mayor.Do();
            ((InterfaceDemo_1.Person)mayor).Do();
            ((InterfaceDemo_1.IPerson)mayor).Do();

            Console.ReadLine();
            InterfaceDemo_2.Mayor mayor1 = new InterfaceDemo_2.Mayor();
            mayor1.Do();
            ((InterfaceDemo_2.Person)mayor1).Do();
            ((InterfaceDemo_2.IPerson)mayor1).Do();
            Console.ReadLine();
            InterfaceDemo_3.Mayor mayor2 = new InterfaceDemo_3.Mayor();
            mayor2.Do();
            ((InterfaceDemo_3.Person)mayor2).Do();
            ((InterfaceDemo_3.IPerson)mayor2).Do();
            Console.ReadLine();
            #endregion

            #region 异步
            //进度条 
            new AsyncAwait().ProgressBar();
            //异步编程
            //new AsyncAwait().DoSomethings();
            Console.ReadLine();
            #endregion
        }
    }
}
