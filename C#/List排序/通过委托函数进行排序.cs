using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List排序
{
    
    class ShopItem
    {

        public int id;

        public ShopItem(int id)
        {
            this.id = id;
        }
    }
     
    class 通过委托函数进行排序
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            #region 知识点三 通过委托函数进行排序
            List<ShopItem> shopItems = new List<ShopItem>();
            shopItems.Add(new ShopItem(2));
            shopItems.Add(new ShopItem(1));
            shopItems.Add(new ShopItem(4));
            shopItems.Add(new ShopItem(3));
            shopItems.Add(new ShopItem(6));
            shopItems.Add(new ShopItem(5));

            //shopItems.Sort(SortShopItem);
            shopItems.Sort((a, b) =>
            {
                return a.id > b.id ? 1 : -1;
            });
            Console.WriteLine("***********************");
            for(int i = 0; i< shopItems.Count; i++)
            {
                Console.WriteLine(shopItems[i].id);
            }
            #endregion
        }

        static int SortShopItem(ShopItem a, ShopItem b)
        {
            //传入的两个对象 为列表中的两个对象
            //进行两两的比较 用左边的和右边条件 比较
            //返回值规则 和之前一样 0做标准 负数在左(前) 正数在右(后)
            if(a.id > b.id)
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
