using System;

namespace 堆排序
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("堆排序");
            int[] arr = new int[] { 78, 8, 7, 1, 5, 4, 1000000, 2, 6, 3, 9, 156 };

            HeapSort(arr);

            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            #region 堆排序基本原理
            //构建二叉树
            //大堆顶调整
            //堆顶往后放
            //不停变堆顶

            //关键规则
            //最大非叶子节点:
            //数组长度/2 - 1

            //父节点和叶子节点：
            //父节点为i
            //左节点2i+1
            //右节点2i+2
            #endregion

          
        }

        #region 代码实现
        //第一步：实现父节点和左右节点比较
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr">需要排序的数组</param>
        /// <param name="nowIndex">当前作为根节点的索引</param>
        /// <param name="arrLength">哪些位置没有确定</param>
        public static void HeapCompare(int[] arr, int nowIndex, int arrLength)
        {
            int leftIndex = 2 * nowIndex + 1;
            int rightIndex = 2 * nowIndex + 2;
            int biggerIndex = nowIndex;

            if(leftIndex < arrLength && arr[leftIndex] > arr[biggerIndex])
            {
                biggerIndex = leftIndex;
            }
            if (rightIndex < arrLength && arr[rightIndex] > arr[biggerIndex])
            {
                biggerIndex = rightIndex;
            }
            if(biggerIndex != nowIndex)
            {
                int temp = arr[nowIndex];
                arr[nowIndex] = arr[biggerIndex];
                arr[biggerIndex] = temp;
                HeapCompare(arr, biggerIndex, arrLength);
            }
        }
        //第二步：构建大堆顶
        public static void BuildHeapTop(int[] arr)
        {
            int maxNotLeft = arr.Length / 2 - 1;
            for (int i = maxNotLeft; i >= 0; i--)
            {
                HeapCompare(arr, i, arr.Length);
            }
        }
        //第三步：结合大堆顶和节点比较 实现堆排序 把堆顶不停往后移动
        public static void HeapSort(int[] arr)
        {   
            BuildHeapTop(arr);
            for(int i = arr.Length - 1; i >= 1 ; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                HeapCompare(arr, 0, i);
            }
        }


        #endregion

        #region 总结
        //注意：
        //堆是一类特殊的树
        //堆的通用特点就是父节点会大于或者小于所有子节点
        //我们并没有真正的把数组变成堆
        //只是利用了堆的特点来解决排序问题
        #endregion
    }
}
