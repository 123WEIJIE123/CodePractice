using System;
using System.Collections.Generic;

namespace ARClass_Ex_02
{
    /// <summary>
    /// 商家类，代表外卖系统中的商家
    /// </summary>
    public class Merchant
    {
        /// <summary>
        /// 商家名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 商家地址
        /// </summary>
        public string Address { get; private set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; private set; }
        /// <summary>
        /// 菜单列表
        /// </summary>
        public List<MenuItem> Menu { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">商家名称</param>
        /// <param name="address">商家地址</param>
        /// <param name="phone">联系电话</param>
        public Merchant(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Menu = new List<MenuItem>();
        }

        /// <summary>
        /// 添加菜品到菜单
        /// TODO [空4]: 创建 MenuItem 对象并添加到 Menu 列表中
        /// 提示: 使用 new MenuItem(name, price) 创建对象，使用 Menu.Add(...) 添加
        /// </summary>
        /// <param name="name">菜品名称</param>
        /// <param name="price">菜品价格</param>
        public void AddMenuItem(string name, decimal price)
        {
            // TODO [空4]: 在这里填写代码
            // 1. 创建 MenuItem 对象
            // 2. 添加到 Menu 列表
            Menu.Add(new MenuItem(name, price));
        }

        /// <summary>
        /// 显示菜单
        /// </summary>
        public void DisplayMenu()
        {
            Console.WriteLine($"商家 {Name} 的菜单：");
            foreach (var item in Menu)
            {
                Console.WriteLine($"  - {item.Name}: {item.Price}元");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// 菜单项类，代表商家菜单中的单个菜品
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// 菜品名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 菜品价格
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">菜品名称</param>
        /// <param name="price">菜品价格</param>
        public MenuItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
