using System;

/*
 * Out 變數: 作用域範圍
*/
namespace _01_Out_Variables_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // 01. 變數 x 的作用域範圍是從 GetDateNow 方法(line:13)開始直到 Main 方法結束
            GetDateNow(out DateTime x);
            Console.WriteLine(x);

            // 02. 變數 y 的作用域範圍是從 GetDateNow 方法(line:18)開始直到程式碼區塊右括號前結束(line:19)
            {
                GetDateNow(out DateTime y);
            }
            //Console.WriteLine(y); // error:名稱 'y' 不存在於目前的內容中
        }

        static void GetDateNow(out DateTime arg)
        {
            arg = DateTime.Now;
        }
    }
}