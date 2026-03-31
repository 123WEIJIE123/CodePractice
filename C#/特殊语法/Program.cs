using System;

namespace 特殊语法
{   
    class Person
    {
        private int money;
        public bool sex;

        public string Name
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public Person(int money)
        {
            this.money = money;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region 知识点二 设置对象初始值
            //申明对象时
            //可以通过直接写大括号的形式初始化公共成员变量和属性
            Person p = new Person(100) { sex = true, Age = 18, Name = "WEIJIE" };
            Person p2 = new Person(200) { Age = 18 };
            #endregion
        }
    }
}
