using System;

/*
 * ref return 可以回傳一個值的參考位置，然後呼叫端再 ref return 存到一個 ref local 變數中
 * 之後修改這個變數，會修改變數所參考位置的值
 * 
 * ref return:
 * ref 型別 方法名(參數){ 
 *     return ref 要回傳的東西
 * }
 * 
 * ref local:
 * ref 型別 = ref 方法名(參數);
 */
namespace _07_Ref_return_And_Locals_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 15, -39, 0, 7, 14, -12 };
            ref int place = ref Find(array[1], array);  //ref local
            Console.WriteLine(place);
            Console.WriteLine(array[1]); //array[1] is 15
            place = 100;
            Console.WriteLine(array[1]); //array[1] is 100
        }

        static void Method01(ref string str)
        {
            str = str.ToUpper();
        }

        /// <summary>
        /// 回傳陣列中，元素值為 number 的參考位置
        /// </summary>
        /// <param name="number"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        static ref int Find(int number, int[] array)  //ref return
        {
            //return ref array[number];
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] == number)
                {
                    return ref array[i];
                }
            }
            throw new IndexOutOfRangeException($"{nameof(number)} not found");
        }
    }
}