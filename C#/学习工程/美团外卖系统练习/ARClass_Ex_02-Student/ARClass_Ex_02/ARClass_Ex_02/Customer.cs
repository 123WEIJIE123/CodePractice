using System;
using System.Collections.Generic;

namespace ARClass_Ex_02
{
    /// <summary>
    /// 顾客类，代表外卖系统中的顾客
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// 顾客姓名
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; private set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">顾客姓名</param>
        /// <param name="phone">联系电话</param>
        /// <param name="address">地址</param>
        public Customer(string name, string phone, string address)
        {
            Name = name;
            Phone = phone;
            Address = address;
        }

        /// <summary>
        /// 下单
        /// TODO [空12]: 创建 Order 对象，添加商品到订单，打印下单信息，返回订单
        /// 提示:
        ///   - 使用 new Order(this, merchant, deliveryAddress) 创建订单，注意 this 代表当前顾客
        ///   - 遍历 items，调用 order.AddItem(...) 添加每个商品
        ///   - 打印下单信息并返回订单
        /// </summary>
        /// <param name="merchant">商家信息</param>
        /// <param name="deliveryAddress">配送地址</param>
        /// <param name="items">商品列表</param>
        /// <returns>创建的订单</returns>
        public Order PlaceOrder(Merchant merchant, string deliveryAddress, List<OrderItem> items)
        {
            // TODO [空12]: 在这里填写代码
            // 1. 创建 Order 对象（传入 this 作为 customer）
            Order order = new Order(this, merchant, deliveryAddress);
            // 2. 遍历 items，调用 order.AddItem(...) 添加每个商品
            foreach(var item in items)
            {
                order.AddItem(item.Name, item.Price, item.Quantity);
            }
            // 3. 打印下单成功信息和订单ID
            Console.WriteLine($"顾客 {Name} 下单成功！ 订单ID: {order.OrderId} ");
            // 4. 调用 order.DisplayOrderInfo() 显示订单
            order.DisplayOrderInfo();
            // 5. 返回订单对象
            return order;
            throw new System.NotImplementedException();
        }
    }
}
