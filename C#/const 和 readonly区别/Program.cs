using System;

namespace const_和_readonly区别
{
    class Program
    {
        public const int a = 1;
        public const Test1 a11 = null;

        public void Fun()
        {
            //a = 2;
        }

        readonly int a1;
        public String a111;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Test1
    {

    }
}
