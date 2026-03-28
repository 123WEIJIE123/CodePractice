using System;
using System.Collections.Generic;

namespace List排序
{
    
    class 自定义类的排序
    {   
                
        //static void Main(string[] args)
        //{ 
        //    Console.WriteLine("Hello World!");
        //    #region 知识点二 自定义类的排序
        //    List<Item> itemList = new List<Item>();
        //    itemList.Add(new Item(45));
        //    itemList.Add(new Item(10));
        //    itemList.Add(new Item(99)); 
        //    itemList.Add(new Item(24));
        //    itemList.Add(new Item(100));
        //    itemList.Add(new Item(12));
        //    //排序方法
        //    itemList.Sort();
        //    for(int i = 0; i < itemList.Count; i++)
        //    {
        //        Console.WriteLine(itemList[i].money);
        //    }
        //    #endregion
        //}
    }

    class Item : IComparable<Item>
    {
        public int money;

        public Item(int money)
        {
            this.money = money;
        }

        public int CompareTo(Item other)
        {   
            //返回值的含义
            //小于0
            //放在传入对象的前面
            //等于0
            //保持当前的位置不变
            //大于0
            //放在传入对象的后面

            //可以简单理解 传入对象的位置 就是0
            //如果你的返回值是负数 就放在它的左边 也就是前面
            //如果你返回正数 就放在它的右边 也就是后边

            if(this.money > other.money)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
