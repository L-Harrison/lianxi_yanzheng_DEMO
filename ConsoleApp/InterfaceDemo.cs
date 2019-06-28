using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    /// <summary>
    /// 接口测试
    /// </summary>
    public static class InterfaceDemo_1
    {
        public interface IPerson
        {
            void Do();
        }
        public class Person : IPerson
        {

            public void Do()
            {
                Console.WriteLine("p");
            }
        }
        public class Mayor : Person
        {
            
            public void Do()
            {
              //  base.Do();
                Console.WriteLine("m");
            }
        }

    }
    public static class InterfaceDemo_2
    {
        public interface IPerson
        {
            void Do();
        }
        public class Person : IPerson
        {

            public virtual void Do()
            {
                Console.WriteLine("p");
            }
        }
        public class Mayor : Person
        {
            public override void Do()
            {
                Console.WriteLine("m");
            }
        }

    }

    public static class InterfaceDemo_3
    {
        public interface IPerson
        {
            void Do();
        }
        public class Person : IPerson
        {

            public void Do()
            {
                Console.WriteLine("p");
            }
        }
        public class Mayor : Person, IPerson
        {
            public void Do()
            {
                Console.WriteLine("m");
            }
        }

    }

}
