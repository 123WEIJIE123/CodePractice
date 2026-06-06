using System;
using System.Collections.Generic;
using System.Linq;

namespace ARClass_Ex_02
{
    class Program
    {
        static void Main(string[] args)
        {


            Meituan meituan = new Meituan();
            InitializeTestData(meituan);

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("          美团外卖系统");
                Console.WriteLine("====================================");
                Console.WriteLine("1. 顾客操作");
                Console.WriteLine("2. 退出系统");
                Console.WriteLine("====================================");
                Console.Write("请选择操作：");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CustomerOperation(meituan);
                        break;
                    case "2":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("输入无效，请重新输入");
                        Console.ReadKey();
                        break;
                }
            }
        }

        /// <summary>
        /// 初始化测试数据
        /// TODO [空14]: 注册商家、添加菜单、注册顾客、注册快递员
        /// 提示:
        ///   - 使用 meituan.RegisterMerchant(...) 注册商家，返回 Merchant 对象
        ///   - 使用 merchant.AddMenuItem(...) 添加菜品
        ///   - 使用 meituan.RegisterCustomer(...) 注册顾客
        ///   - 使用 meituan.RegisterDeliveryman(...) 注册快递员
        /// </summary>
        static void InitializeTestData(Meituan meituan)
        {
            // TODO [空14]: 在这里填写代码
            // 1. 注册商家"肯德基"（地址: 北京市朝阳区, 电话: 13800138001）
            //    添加菜品: 原味鸡(12.5元), 香辣鸡腿堡(15.0元), 薯条(9.0元)
            Merchant merchant = meituan.RegisterMerchant("肯德基", "北京市朝阳区", "13800138001");
            merchant.AddMenuItem("原味鸡", 12.5m);
            merchant.AddMenuItem("香辣鸡腿堡", 15.0m);
            merchant.AddMenuItem("薯条", 9.0m);
            // 2. 注册商家"麦当劳"（地址: 北京市海淀区, 电话: 13800138002）
            //    添加菜品: 巨无霸(18.0元), 麦乐鸡(10.0元), 可乐(8.0元)
            Merchant merchan1 = meituan.RegisterMerchant("麦当劳", "北京市海淀区", "13800138002");
            merchan1.AddMenuItem("巨无霸", 18.0m);
            merchan1.AddMenuItem("麦乐鸡", 10.0m);
            merchan1.AddMenuItem("可乐", 8.0m);
            // 3. 注册顾客: 王五(13700137001, 北京市朝阳区建国路88号), 赵六(13700137002, 北京市海淀区中关村大街1号)
            meituan.RegisterCustomer("王五", "13700137001", "北京市朝阳区建国路88号");
            meituan.RegisterCustomer("赵六", "13700137002", "北京市海淀区中关村大街1号");
            // 4. 注册快递员: 张三(13900139001), 李四(13900139002)
            meituan.RegisterDeliveryman("张三", "13900139001");
            meituan.RegisterDeliveryman("李四", "13900139002");
        }

        static void CustomerOperation(Meituan meituan)
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("          顾客操作");
            Console.WriteLine("====================================");

            Console.WriteLine("选择为谁点餐：");
            for (int i = 0; i < meituan.Customers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {meituan.Customers[i].Name}");
            }
            Console.Write("请选择：");
            int customerIndex = int.Parse(Console.ReadLine()) - 1;
            if (customerIndex < 0 || customerIndex >= meituan.Customers.Count)
            {
                Console.WriteLine("选择无效");
                Console.ReadKey();
                return;
            }
            var customer = meituan.Customers[customerIndex];

            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine($"当前顾客：{customer.Name}");
                Console.WriteLine("====================================");
                Console.WriteLine("1. 下单");
                Console.WriteLine("2. 返回上一级");
                Console.WriteLine("====================================");
                Console.Write("请选择操作：");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        PlaceOrder(meituan, customer);
                        break;
                    case "2":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("输入无效，请重新输入");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void PlaceOrder(Meituan meituan, Customer customer)
        {
            Console.WriteLine("选择商家：");
            for (int i = 0; i < meituan.Merchants.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {meituan.Merchants[i].Name}");
            }
            Console.Write("请选择：");
            int merchantIndex = int.Parse(Console.ReadLine()) - 1;
            if (merchantIndex < 0 || merchantIndex >= meituan.Merchants.Count)
            {
                Console.WriteLine("选择无效");
                Console.ReadKey();
                return;
            }
            var merchant = meituan.Merchants[merchantIndex];

            merchant.DisplayMenu();

            List<OrderItem> items = new List<OrderItem>();
            bool addMore = true;
            while (addMore)
            {
                Console.WriteLine("选择商品编号（输入0结束）：");
                for (int i = 0; i < merchant.Menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {merchant.Menu[i].Name} - {merchant.Menu[i].Price}元");
                }
                int itemIndex = int.Parse(Console.ReadLine()) - 1;
                if (itemIndex == -1)
                {
                    addMore = false;
                }
                else if (itemIndex >= 0 && itemIndex < merchant.Menu.Count)
                {
                    Console.Write("请输入数量：");
                    int quantity = int.Parse(Console.ReadLine());
                    var menuItem = merchant.Menu[itemIndex];
                    items.Add(new OrderItem(menuItem.Name, menuItem.Price, quantity));
                    Console.WriteLine($"已添加：{menuItem.Name} × {quantity}");
                }
                else
                {
                    Console.WriteLine("选择无效");
                }
            }

            if (items.Count > 0)
            {
                var order = meituan.PlaceOrder(customer, merchant, customer.Address, items);
                ProcessOrderDelivery(meituan, order);
            }
            Console.ReadKey();
        }

        static void ProcessOrderDelivery(Meituan meituan, Order order)
        {
            Console.WriteLine("\n等待快递员接单...");
            for (int i = 5; i > 0; i--)
            {
                Console.Write($"倒计时 {i} 秒...\r");
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine();

            var deliveryman = meituan.FindAvailableDeliveryman();
            if (deliveryman != null)
            {
                deliveryman.AcceptOrder(order);

                Console.WriteLine("\n快递员取餐配送中...");
                for (int i = 10; i > 0; i--)
                {
                    Console.Write($"预计送达时间 {i} 秒...\r");
                    System.Threading.Thread.Sleep(1000);
                }
                Console.WriteLine();

                deliveryman.DeliverOrder();
            }
            else
            {
                Console.WriteLine("暂无空闲快递员，请稍后重试");
            }
        }
    }
}
