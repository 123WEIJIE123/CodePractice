using System;

namespace 快速排序
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("快速排序");

            #region 快速排序基本原理
            //选取基准
            //产生左右标识
            //左右比基准
            //满足则换位
            
            //排完一次
            //基准定位

            //左右递归
            //直到有序
            #endregion

            #region 代码实现
            int[] arr = new int[] { 8, 7, 1, 5, 10, 4, 2, 6, 3, 9 , 0 , 122, 22 };
            QuiklySort(arr, 0, arr.Length - 1);
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }



            #endregion
        }

        public static void QuiklySort(int[] arr, int left, int right)
        {   
            if(left >= right)
            {
                return;
            }
            int tempLeft = left, tempRight = right, temp = arr[left];

            while(tempLeft != tempRight)
            {   
                while (arr[tempRight] > temp && tempLeft < tempRight)
                {
                    tempRight--;
                }
                arr[tempLeft] = arr[tempRight];

                while (arr[tempLeft] < temp && tempLeft < tempRight)
                {
                    tempLeft++;
                }
                arr[tempRight] = arr[tempLeft];
            }

            arr[tempRight] = temp;

            QuiklySort(arr, left, tempRight - 1);
            QuiklySort(arr, tempRight + 1, right);
        }
    }
}
