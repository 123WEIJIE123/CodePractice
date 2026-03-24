 using System;

namespace 链表
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            LinkedNode<int> node = linkedList.head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.nextNode;
            }

            linkedList.Remove(4);
            linkedList.Remove(3);
            node = linkedList.head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.nextNode;
            }
        }
    }

    #region 简单的单链表的实现

    /// <summary>
    /// 单向链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedNode<T>
    {
        public T value;
        //这个存储下一个元素是谁 相当与钩子
        public LinkedNode<T> nextNode;
            
        public LinkedNode(T value)
        {
            this.value = value;
        }
    }

    /// <summary>
    /// 单向链表类 管理 节点 添加 移除等等
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedList<T>
    {
        public LinkedNode<T> head;
        public LinkedNode<T> last;

        public void Add(T value)
        {   
            //添加节点 必然是new一个新的节点
            LinkedNode<T> node = new LinkedNode<T>(value);
            if (head == null)
            {
                head = node;
                last = head;
            }
            last.nextNode = node;
            last = last.nextNode;
        }

        public void Remove(T value)
        {
            if(head == null)
            {
                Console.WriteLine("链表为空无法移除");
                return;
            }
            if (head.value.Equals(value))
            {
                head = head.nextNode;
                //如果头节点 被移除 发现头节点变空
                //证明只有一个节点 那尾节点也要清空
                if(head == null)
                {
                    last = null;
                }
                return;
            }

            LinkedNode<T> node = head;
            while (node.nextNode != null)
            {

                if (node.nextNode.value.Equals(value))
                {   
                    //让当前找到的这个元素的 上一个节点
                    //指向 自己的下一个节点
                    node.nextNode = node.nextNode.nextNode;
                    break;
                }
                node = node.nextNode;
            }
        }
    }


    #endregion
}
