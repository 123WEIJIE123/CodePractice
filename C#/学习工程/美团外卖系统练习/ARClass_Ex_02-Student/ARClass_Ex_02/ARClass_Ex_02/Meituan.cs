using System;
using System.Collections.Generic;
using System.Linq;

namespace ARClass_Ex_02
{
    /// <summary>
    /// 美团平台类，作为外卖系统的中间协调者
    /// </summary>
    public class Meituan
    {
        /// <summary>
        /// 顾客列表
        /// </summary>
        public List<Customer> Customers { get; private set; }
        /// <summary>
        /// 商家列表
        /// </summary>
        public List<Merchant> Merchants { get; private set; }
        /// <summary>
        /// 快递员列表
        /// </summary>
        public List<Deliveryman> Deliverymen { get; private set; }
        /// <summary>
        /// 所有订单列表（用于跟踪订单历史）
        /// TODO: 在构造函数中初始化此列表
        /// </summary>
        public List<Order> Orders { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Meituan()
        {
            Customers = new List<Customer>();
            Merchants = new List<Merchant>();
            Deliverymen = new List<Deliveryman>();
            // TODO: 初始化 Orders 列表
            Orders = new List<Order>();
        }

        /// <summary>
        /// 注册顾客
        /// TODO [空1]: 创建 Customer 对象并添加到 Customers 列表中，然后返回
        /// 提示: 使用 new Customer(...) 创建对象，使用 Customers.Add(...) 添加到列表
        /// </summary>
        /// <param name="name">顾客姓名</param>
        /// <param name="phone">联系电话</param>
        /// <param name="address">地址</param>
        /// <returns>注册的顾客</returns>
        public Customer RegisterCustomer(string name, string phone, string address)
        {
            // TODO [空1]: 在这里填写代码
            // 1. 创建 Customer 对象
            Customer customer = new Customer(name, phone, address);
            // 2. 添加到 Customers 列表
            Customers.Add(customer);
            // 3. 返回 customer 对象
            return customer;
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 注册商家
        /// TODO [空2]: 创建 Merchant 对象并添加到 Merchants 列表中，然后返回
        /// 提示: 使用 new Merchant(...) 创建对象，使用 Merchants.Add(...) 添加到列表
        /// </summary>
        /// <param name="name">商家名称</param>
        /// <param name="address">商家地址</param>
        /// <param name="phone">联系电话</param>
        /// <returns>注册的商家</returns>
        public Merchant RegisterMerchant(string name, string address, string phone)
        {
            // TODO [空2]: 在这里填写代码
            // 1. 创建 Merchant 对象
            Merchant merchant = new Merchant(name, address, phone);
            // 2. 添加到 Merchants 列表
            Merchants.Add(merchant);
            // 3. 返回 merchant 对象
            return merchant;
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 注册快递员
        /// TODO [空3]: 创建 Deliveryman 对象并添加到 Deliverymen 列表中，然后返回
        /// 提示: 使用 new Deliveryman(...) 创建对象，使用 Deliverymen.Add(...) 添加到列表
        /// </summary>
        /// <param name="name">快递员姓名</param>
        /// <param name="phone">联系电话</param>
        /// <returns>注册的快递员</returns>
        public Deliveryman RegisterDeliveryman(string name, string phone)
        {
            // TODO [空3]: 在这里填写代码
            // 1. 创建 Deliveryman 对象
            Deliveryman deliveryman = new Deliveryman(name, phone);
            // 2. 添加到 Deliverymen 列表
            Deliverymen.Add(deliveryman);
            // 3. 返回 deliveryman 对象
            return deliveryman;
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 找到空闲的快递员
        /// TODO [空6]: 遍历 Deliverymen 列表，找到 IsBusy 为 false 的第一个快递员
        /// 提示: 可以使用 foreach 循环遍历，检查 d.IsBusy == false；也可以使用 LINQ 的 FirstOrDefault
        /// </summary>
        /// <returns>空闲的快递员，如果没有则返回null</returns>
        public Deliveryman FindAvailableDeliveryman()
        {
            // TODO [空6]: 在这里填写代码
            // 遍历 Deliverymen 列表，返回第一个 IsBusy == false 的快递员
            for(int i = 0; i < Deliverymen.Count; i++)
            {
                if(Deliverymen[i].IsBusy == false)
                {
                    return Deliverymen[i];
                }
            }
            return null;
            // 如果找不到，返回 null
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 顾客下单
        /// TODO [空13]: 委托 customer.PlaceOrder 创建订单，打印平台确认信息
        /// 提示: 调用 customer.PlaceOrder(merchant, deliveryAddress, items) 获取订单
        /// </summary>
        /// <param name="customer">顾客信息</param>
        /// <param name="merchant">商家信息</param>
        /// <param name="deliveryAddress">配送地址</param>
        /// <param name="items">商品列表</param>
        /// <returns>创建的订单</returns>
        public Order PlaceOrder(Customer customer, Merchant merchant, string deliveryAddress, List<OrderItem> items)
        {
            // TODO [空13]: 在这里填写代码
            // 1. 调用 customer.PlaceOrder(...) 创建订单
            Order order = customer.PlaceOrder(merchant, deliveryAddress, items);
            // 2. 将订单添加到 Orders 列表
            Orders.Add(order);
            // 3. 打印 "美团平台已接收订单"
            Console.WriteLine("美团平台已接收订单");
            // 4. 返回订单对象
            return order;
            throw new System.NotImplementedException();
        }

        // ============================================================
        // TODO [空15]: 新增方法 FindMerchantByName(string name)
        // 功能: 在 Merchants 列表中查找名称匹配的商家
        // 返回: 匹配的第一个 Merchant，未找到返回 null
        // 提示: 可以使用 foreach 遍历 Merchants，检查 m.Name == name
        //       也可以使用 LINQ: Merchants.FirstOrDefault(m => m.Name == name)
        // ============================================================
        // TODO [空15]: 在这里实现 FindMerchantByName 方法
        public Merchant FindMerchantByName(string name)
        {
            foreach (var m in Merchants)
            {
                if (m.Name == name)
                {
                    return m;
                }
            }
            return null;
        }

        // ============================================================
        // TODO [空16]: 新增方法 GetMerchantRevenue(string merchantName)
        // 功能: 统计指定商家已完成订单的总金额
        // 返回: decimal 类型的总收入
        // 提示:
        //   - 遍历 Orders 列表
        //   - 检查 order.Merchant.Name == merchantName
        //   - 检查 order.Status == OrderStatus.Delivered 或 Completed
        //   - 累加符合条件的订单 TotalAmount
        // ============================================================

        // TODO [空16]: 在这里实现 GetMerchantRevenue 方法
        public decimal GetMerchantRevenue(string merchantName)
        {
            foreach (var order in Orders)
            {
                if(order.Merchant.Name == merchantName)
                {
                    if (order.Status == OrderStatus.Delivered || order.Status == OrderStatus.Completed)
                    {
                        return order.TotalAmount;
                    }
                }
            }
            return 0;
        }
    }
}
