using System;

namespace 归并排序
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("归并排序");
            #region 知识点一 归并排序基本原理
            //归并 = 递归 + 合并

            //数组分左右
            //左右元素相比较
            //满足条件放入新数组
            //一侧用完放对面

            //递归不停分
            //分完再排序
            //排序结束往上走
            //边走边合并
            //走到头顶出结果

            //归并排序分成两部分
            //1.基本排序规则
            //2.递归平分数组

            //递归平分数组：
            //不停进行分割
            //长度小于2停止
            //开始比较
            //一层一层向上比

            //基本排序规则：
            //左右元素进行比较
            //依次放入新数组中
            //一侧没有了另一侧直接放入新数组
            #endregion

            #region 代码实现
            int[] arr = new int[] {78, 8, 7, 1, 5, 4, 2, 6, 3, 9, 156 };
            int[] arr1 = Merge(arr);
            for(int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine(arr1[i]);
            }

            //第一步：
            //基本排序规则
            //左右元素相比较
            //满足条件放进去
            //一侧用完直接放

            //第二步
            //递归平分数组
            //结束条件为长度小于2


            #endregion
        }

        public static int[] Sort(int[] left, int[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int[] arr = new int[left.Length + right.Length];

            for(int i = 0; i < arr.Length; i++)
            {
                if (leftIndex >= left.Length)
                {
                    arr[i] = right[rightIndex];
                    rightIndex++;
                }
                else if (rightIndex >= right.Length)
                {
                    arr[i] = left[leftIndex];
                    leftIndex++;
                }
                else if (left[leftIndex] > right[rightIndex])
                {
                    arr[i] = right[rightIndex];
                    rightIndex++;
                }
                else
                {
                    arr[i] = left[leftIndex];
                    leftIndex++;
                }
            }
            return arr;
        }

        public static int[] Merge(int[] arr)
        {
            if(arr.Length < 2)
            {
                return arr;
            }
            int mid = arr.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];
            for (int i = 0; i < arr.Length; i++)
            {
                if(i < mid)
                {
                    left[i] = arr[i];
                }
                else
                {
                    right[i - mid] = arr[i];
                }
            }



            return Sort(Merge(left), Merge(right));
        }
    }
}
