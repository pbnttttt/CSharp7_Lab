using System;
using System.Linq;
using System.Collections.Generic;

/*
 * Tuples: 希望從一個方法回傳多個值. 它屬於 value type，因此效能較好.
 * 
 * 以前可以做到但不方便，缺點:
 * 1. Out parameters: 無法用在 async method.
 * 2. System.Tuple<...>: 回傳後，多個值以  result.Item(n) 表數
 * 3. DTO: 為了暫時性的回傳值而建立DTO很煩
 * 4. dynamic 當回傳型別: 沒有型別檢查機制
 * 
 * C# 7.0 Tuples 有二個名詞:
 * 1. tuple type
 * 2. tuple literals
 * 
 * 要支援 Tuples，先從 NuGet 下載套件(https://www.nuget.org/packages/System.ValueTuple/)後才可使用
 */
namespace _03_Tuples_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var numList = new List<int> { 1, 2, 3, 4, 5 };

            var result1 = GetMaxMinValue01(numList);
            Console.WriteLine(result1.Item1);
            Console.WriteLine(result1.Item2);

            var result2 = GetMaxMinValue02(numList);
            Console.WriteLine(result2.max);
            Console.WriteLine(result2.min);

            //直接由 tuple literals 產生 tuple type 來使用(類似匿名型別)
            var result3 = (max: 100, min: 1);
            Console.WriteLine(result3.max);
            Console.WriteLine(result3.min);
        }

        /// <summary>
        /// 舊寫法
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        static Tuple<int, int> GetMaxMinValueOld(List<int> list)
        {
            return new Tuple<int, int>(list.Max(), list.Min());
        }

        /// <summary>
        /// 優化舊寫法，但是 caller 收到方法回傳的值後，還是必需以 Item(n) 來取得值
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        static (int, int) GetMaxMinValue01(List<int> list) //return "tuple type"
        {
            return (list.Max(), list.Min()); // tuple literal
        }

        /// <summary>
        /// 可以在 tuple type 指定回傳的屬性名稱，這樣 caller 可以使用這個屬性名稱，可讀性更高
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        static (int max, int min) GetMaxMinValue02(List<int> list) //return "tuple type"
        {
            return (list.Max(), list.Min()); // tuple literal
        }
    }
}