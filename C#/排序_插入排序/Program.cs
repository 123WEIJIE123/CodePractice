using System;

namespace 插入排序
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("插入排序");

            #region 知识点一 插入排序的基本原理
            // 8 7 1 5 4 2 6 3 9
            //两个区域
            //排序区
            //未排序区
            //用一个索引值做分水岭

            //未排序区元素
            //与排序区元素比较
            //插入到合适位置
            //直到未排序区清空  
            #endregion

            #region 代码实现
            int[] arr = new int[] { 8, 7, 1, 5, 4, 2, 6, 3, 9 };

            for(int i = 1; i < arr.Length; i++)
            {
                //1.取出排序区最后一个元素的索引
                int sortIndex = i - 1;
                //2.取出未排序区第一个元素
                int noSortNum = arr[i];

                while(sortIndex >= 0 && noSortNum < arr[sortIndex])
                {
                    arr[sortIndex + 1] = arr[sortIndex];

                    sortIndex--;
                }

                arr[sortIndex + 1] = noSortNum;
            }


            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            #endregion
        }
    }
}
