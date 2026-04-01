using System;

namespace 希尔排序
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("希尔排序");

            #region 知识点一 希尔排序的基本原理
            //希尔排序是
            //插入排序的升级版
            //必须先掌握插入排序

            //希尔排序原理
            //将整个待排序序列
            //分割成为诺干子序列
            //分别进行插入排序

            //总而言之
            //希尔排序对插入排序的升级主要就是加入了一个步长的概念
            //通过步长每次可以把原序列分为多个子序列
            //对子序列进行插入排序
            //在极限情况下可以有效降低普通插入排序的时间复杂度
            //提升算法效率
            #endregion

            #region 代码实现
            int[] arr = new int[] { 8, 7, 1, 5, 10, 4, 2, 6, 3, 9 };
            //学习希尔排序的前提
            //先掌握插入排序
            //第一步：实现插入排序

            //第二步：确定步长  
            //基本规则：每次步长变化都是/2

            //第三步：执行插入排序


            for(int step = arr.Length/2; step > 0; step /= 2)
            {
                for(int i = step; i < arr.Length; i++)
                {
                    int sortIndex = i - step;
                    int noSortNum = arr[i];

                    while(sortIndex >= 0 && noSortNum < arr[sortIndex])
                    {
                        arr[sortIndex + step] = arr[sortIndex];
                        sortIndex -= step;
                    }

                    arr[sortIndex + step] = noSortNum;
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            #endregion
        }
    }
}
