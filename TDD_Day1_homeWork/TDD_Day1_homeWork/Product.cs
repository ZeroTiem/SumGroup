using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using VariousType;

namespace TDD_Day1_homeWork
{
    //參考500分同學作法
    //來源[https://github.com/bagamoon/SumByGroup]

    public class Product
    {
        //物件狀態 初次使用?不知道什麼狀況下該使用
        //public bool valiDateStatus { get; set; }
        //public Type SumGroupResultype { get; set; }


        //private VariousType VariousType;
        //public Product()
        //{
        //    VariousType = new VariousType();
        //}

        /// <summary>
        /// 全組加總
        /// </summary>
        /// <typeparam name="T">傳入Class型別</typeparam>
        /// <param name="x">委派</param> 初次使用 參考：[https://msdn.microsoft.com/zh-tw/library/bb549151(v=vs.110).aspx]
        /// <param name="item">集合</param>
        /// <returns></returns>
        public IEnumerable<object> SumGroup<T>(IEnumerable<T> items, Func<T, object> x, int groupCount)
        {
            List<object> results = new List<object>();
            Type type;
            object sum = null;
            int itemsCount = items.Count();//總比數
            int skipIndex = 0;//取得位置     
            int takeIndex = 0;//取幾筆

            //給予取幾筆初始值
            takeIndex = groupCount;

            //如果總比數 大於等於 取得位置 而且 總比數 不等於 0
            while (itemsCount >= skipIndex && itemsCount != 0)
            {
                sum = null;
                //取得一群組集合
                var Groups = items.Skip(skipIndex).Take(takeIndex);

                foreach (var item in Groups.Select(x))
                {
                    //※缺點
                    //這裡該如何使用此方法自動帶入型別或是有什麼其他方法可以簡化
                    //每個可預期型態都要寫一次
                    //本來想要再拆開使用 T 來自動帶入型別 可是失敗
                    type = item.GetType();
                    if (item.GetType() == typeof(int))//如果是INT
                    {
                        sum = sum == null ? (int)item : (int)sum + (int)item;
                    }
                    else if (item.GetType() == typeof(double))//如果是double
                    {
                        sum = sum == null ? (double)item : (double)sum + (double)item;
                    }
                    else//如果什麼都不是當文字處理
                    {
                        sum = sum == null ? (string)item : (string)sum + (string)item;
                    }
                }

                //Debug不會進入此處除錯~可以使用~放棄!
                //yield return Sum; MSDN https://msdn.microsoft.com/zh-tw/library/9k7k7cf0.aspx
                results.Add(sum);

                skipIndex = skipIndex + groupCount;

                if (skipIndex > itemsCount - groupCount)
                {
                    takeIndex -= skipIndex - (itemsCount - groupCount);
                }
            }

            return results;
        }

    }


}
