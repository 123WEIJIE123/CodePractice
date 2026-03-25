using System;

namespace 双向链表练习
{   
    /// <summary>
    /// 实现一个双向链表
    /// 提供以下方法和属性
    /// 数据的个数 头节点 尾节点
    /// 增加数据到链表最后
    /// 删除指定位置节点
    /// </summary>
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
            LinkedNode<int> node = linkedList.Head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.nextNode;
            }
            linkedList.RemoveAt(4);
            linkedList.RemoveAt(0);//移除1
            linkedList.RemoveAt(2);//移除4
            node = linkedList.Head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.nextNode;
            }
            linkedList.Add(100);
            Console.WriteLine("正向遍历");
            node = linkedList.Head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.nextNode;
            }
            Console.WriteLine("反向遍历");
            node = linkedList.Last;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.frontNode;
            }
        }
    }

    class LinkedNode<T>
    {
        public T value;
        public LinkedNode<T> frontNode;
        public LinkedNode<T> nextNode;

        public LinkedNode(T value)
        {
            this.value = value;
        }
    }
    
    class LinkedList<T>
    {
        private int count = 0;
        private LinkedNode<T> head;
        private LinkedNode<T> last;

        public int Count
        {
            get
            {
                return count;
            }
        }
        public LinkedNode<T> Head
        {
            get
            {
                return head;
            }
        }
        public LinkedNode<T> Last
        {
            get
            {
                return last;
            }
        }
        
        public void Add(T value)
        {   
            //新加节点
            LinkedNode<T> node = new LinkedNode<T>(value);
            if(head == null)
            {
                head = node;
            }
            else
            {   
                //添加到尾部
                last.nextNode = node;
                //尾部添加的节点 记录自己的上一个节点是谁
                node.frontNode = last;
            }
            last = node;
            count++;
        }

        public void RemoveAt(int index)
        {   
            //先判断 有没有越界
            if(index < 0 || index > count - 1)
            {
                Console.WriteLine("索引{0}错误，有{1}个节点", index, count);
                return;
            }

            if(count == 0)
            {
                Console.WriteLine("无元素");
                return;
            }


            int tempCount = 0;
            LinkedNode<T> node = head;
            while (true)
            {
                if (tempCount == index)
                {
                    if(node.frontNode != null)
                    {
                        node.frontNode.nextNode = node.nextNode;
                    }
                    if(node.nextNode != null)
                    {
                        node.nextNode.frontNode = node.frontNode;
                    }
                    #region 我自己的写法
                    //if(node == head)
                    //{
                    //    head = node.nextNode;
                    //}
                    //if (node == last)
                    //{
                    //    last = last.frontNode;
                    //}
                    #endregion
                    
                    if(index == 0)
                    {
                        head = node.nextNode;
                    }
                    else if(index == count - 1)
                    {
                        last = last.frontNode;
                    }
                    count--;
                    break;
                }
                node = node.nextNode;
                ++tempCount;
            }
        }
    }
}
