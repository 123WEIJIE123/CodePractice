using System;

namespace 匿名函数
{
    class Program
    {
        static event Action a = delegate ()
        {
            Console.WriteLine("匿名函数逻辑");
        };

        static void Main(string[] args)
        {
            a();
        }
    }
}
