using System;

/*
 * Out 變數: 與舊版的差界
*/
namespace _01_Out_Variables_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // before C# 7.0
            M1();

            //C# 7.0
            M2();
        }

        private static void M1()
        {
            /*
             * 要先宣告變數才可傳入有 out 參數的方法，通常宣告時也不會初始化，因為他會在方法中被覆寫.
             * 不可使用 var 宣告，必需指定明確的型別
             */
            int x, y;
            int.TryParse("1", out x);
            int.TryParse("2", out y);
            Console.WriteLine(x);
            Console.WriteLine(y);
        }

        private static void M2()
        {
            /*
             * 可以直接在 out 參數位置宣告變數當作參數
             */
            int.TryParse("1", out int x);
            Console.WriteLine(x);
        }
    }
}