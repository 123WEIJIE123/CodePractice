using System;
using System.Collections.Generic;

namespace ARClass_Ex_02
{
    /// <summary>
    /// 快递员类，代表外卖系统中的快递员
    /// </summary>
    public class Deliveryman
    {
        /// <summary>
        /// 快递员姓名
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; private set; }
        /// <summary>
        /// 是否正在配送
        /// </summary>
        public bool IsBusy { get; private set; }
        /// <summary>
        /// 当前配送的订单
        /// </summary>
        public Order CurrentOrder { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">快递员姓名</param>
        /// <param name="phone">联系电话</param>
        public Deliveryman(string name, string phone)
        {
            Name = name;
            Phone = phone;
            IsBusy = false;
            CurrentOrder = null;
        }

        /// <summary>
        /// 接单
        /// TODO [空9]: 设置当前订单、标记忙碌状态、更新订单状态为 DeliveryAccepted
        /// 提示:
        ///   - 将 order 赋值给 CurrentOrder
        ///   - 将 IsBusy 设为 true
        ///   - 调用 order.UpdateStatus(OrderStatus.DeliveryAccepted)
        /// </summary>
        /// <param name="order">订单信息</param>
        public void AcceptOrder(Order order)
        {
            // TODO [空9]: 在这里填写代码
            // 1. 设置 CurrentOrder
            CurrentOrder = order;
            // 2. 设置 IsBusy = true
            IsBusy = true;
            // 3. 调用 order.UpdateStatus(OrderStatus.DeliveryAccepted)
            order.UpdateStatus(OrderStatus.DeliveryAccepted);
            // 4. 打印接单成功信息
            Console.WriteLine($"订单 {order.OrderId} 状态已更新为：{OrderStatus.DeliveryAccepted} \n快递员{Name} 已接单！订单ID:{order.OrderId}");
        }

        /// <summary>
        /// 送达
        /// TODO [空10]: 更新订单状态为 Delivered，打印送达通知，清空当前订单和忙碌状态
        /// 提示:
        ///   - 检查 CurrentOrder 不为 null
        ///   - 调用 order.UpdateStatus(OrderStatus.Delivered)
        ///   - 打印送达信息，包含顾客姓名和配送地址
        ///   - 将 CurrentOrder 设为 null，IsBusy 设为 false
        /// </summary>
        public void DeliverOrder()
        {
            // TODO [空10]: 在这里填写代码
            // 1. 检查 CurrentOrder 是否不为 null
            // 2. 调用 CurrentOrder.UpdateStatus(OrderStatus.Delivered)
            if (CurrentOrder != null)
            {
                CurrentOrder.UpdateStatus(OrderStatus.Delivered);
            }
            // 3. 打印送达信息
            Console.WriteLine($"订单 {CurrentOrder.OrderId} 状态已更新为：{OrderStatus.Delivered} \n快递员 {Name} 已将外卖送达!");
            // 4. 通知顾客取餐（打印顾客姓名和配送地址）
            Console.WriteLine($"通知顾客 {CurrentOrder.Customer.Name} 取餐\n配送地址 {CurrentOrder.Customer.Address}");
            // 5. 清空 CurrentOrder 和 IsBusy
            CurrentOrder = null;
            IsBusy = false;
        }
    }
}
