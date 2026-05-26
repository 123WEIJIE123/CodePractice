using System;
using System.Collections.Generic;

namespace ARClass_Ex_02
{
    /// <summary>
    /// 订单状态枚举
    /// </summary>
    public enum OrderStatus
    {
        Pending,            // 待处理（订单刚创建）
        DeliveryAccepted,   // 快递员已接单
        Delivered,          // 已送达
        Completed,          // 已完成
        Cancelled           // 已取消
    }

    /// <summary>
    /// 订单类，管理订单信息和状态
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderId { get; private set; }
        /// <summary>
        /// 顾客信息
        /// </summary>
        public Customer Customer { get; private set; }
        /// <summary>
        /// 商家信息
        /// </summary>
        public Merchant Merchant { get; private set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus Status { get; private set; }

        /// <summary>
        /// 更新订单状态
        /// TODO [空8]: 将 newStatus 赋值给 Status 属性，并打印状态更新信息
        /// </summary>
        /// <param name="newStatus">新的订单状态</param>
        public void UpdateStatus(OrderStatus newStatus)
        {
            // TODO [空8]: 在这里填写代码
            // 1. 将 newStatus 赋值给 Status
            Status = newStatus;
            // 2. 打印状态更新信息，例如: $"订单 {OrderId} 状态已更新为: {Status}"
            Console.WriteLine($"订单 {OrderId} 状态已更新为: {Status}");
        }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderTime { get; private set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal TotalAmount { get; private set; }
        /// <summary>
        /// 订单商品列表
        /// </summary>
        public List<OrderItem> Items { get; private set; }
        /// <summary>
        /// 配送地址
        /// </summary>
        public string DeliveryAddress { get; private set; }

        /// <summary>
        /// 构造函数
        /// TODO [空11]: 初始化所有字段
        /// 提示:
        ///   - OrderId 使用 Guid.NewGuid().ToString() 生成
        ///   - Customer 和 Merchant 直接使用参数传入
        ///   - DeliveryAddress 使用参数传入
        ///   - Status 初始设为 OrderStatus.Pending
        ///   - OrderTime 设为 DateTime.Now
        ///   - Items 初始化为 new List<OrderItem>()
        ///   - TotalAmount 初始化为 0
        /// </summary>
        /// <param name="customer">顾客信息</param>
        /// <param name="merchant">商家信息</param>
        /// <param name="deliveryAddress">配送地址</param>
        public Order(Customer customer, Merchant merchant, string deliveryAddress)
        {
            // TODO [空11]: 在这里填写代码
            // 初始化所有属性字段
            this.OrderId = Guid.NewGuid().ToString();
            this.Customer = customer;
            this.Merchant = merchant;
            this.DeliveryAddress = deliveryAddress;
            this.Status = OrderStatus.Pending;
            this.OrderTime = DateTime.Now;
            this.Items = new List<OrderItem>();
            this.TotalAmount = 0;
        }

        /// <summary>
        /// 添加商品到订单
        /// TODO [空5]: 创建 OrderItem 并添加到 Items 列表，然后重新计算总金额
        /// 提示: 使用 new OrderItem(...) 创建对象，调用 CalculateTotalAmount() 更新金额
        /// </summary>
        /// <param name="itemName">商品名称</param>
        /// <param name="price">商品价格</param>
        /// <param name="quantity">商品数量</param>
        public void AddItem(string itemName, decimal price, int quantity)
        {
            // TODO [空5]: 在这里填写代码
            // 1. 创建 OrderItem 对象
            // 2. 添加到 Items 列表
            // 3. 调用 CalculateTotalAmount() 重新计算总金额
            OrderItem orderItem = new OrderItem(itemName, price, quantity);
            Items.Add(orderItem);
            CalculateTotalAmount();
        }

        /// <summary>
        /// 计算订单总金额
        /// TODO [空7]: 遍历 Items 列表，累加每个商品的 TotalPrice
        /// 提示: 使用 foreach 遍历 Items，TotalAmount += item.TotalPrice
        /// </summary>
        private void CalculateTotalAmount()
        {
            // TODO [空7]: 在这里填写代码
            // 1. 先将 TotalAmount 重置为 0
            TotalAmount = 0;
            // 2. 遍历 Items，累加每个 item.TotalPrice 到 TotalAmount
            foreach (var item in Items)
            {
                TotalAmount += item.TotalPrice;
            }
        }

        /// <summary>
        /// 显示订单信息
        /// </summary>
        public void DisplayOrderInfo()
        {
            Console.WriteLine($"订单ID: {OrderId}");
            Console.WriteLine($"顾客: {Customer.Name}");
            Console.WriteLine($"商家: {Merchant.Name}");
            Console.WriteLine($"订单状态: {Status}");
            Console.WriteLine($"下单时间: {OrderTime}");
            Console.WriteLine($"配送地址: {DeliveryAddress}");
            Console.WriteLine("商品列表:");
            foreach (var item in Items)
            {
                Console.WriteLine($"  - {item.Name}: {item.Price}元 × {item.Quantity} = {item.TotalPrice}元");
            }
            Console.WriteLine($"总金额: {TotalAmount}元");
            Console.WriteLine();
        }
    }

    /// <summary>
    /// 订单项类，代表订单中的单个商品
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        public decimal Price { get; private set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int Quantity { get; private set; }
        /// <summary>
        /// 商品总价
        /// </summary>
        public decimal TotalPrice => Price * Quantity;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">商品名称</param>
        /// <param name="price">商品单价</param>
        /// <param name="quantity">商品数量</param>
        public OrderItem(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
