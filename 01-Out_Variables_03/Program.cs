using System;

/*
 * Out 變數: 作用 var 宣告
*/
namespace _01_Out_Variables_03
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 01. out 變數可以使用 var 來宣告，因為編譯器可以型別推斷出來真實的型別是什麼
             */
            if(int.TryParse("1", out var x))
            {
                Console.WriteLine($"x is: {x}");
            }

            /*
             * 02. 如果是 conflicting overloads，就無法使用 var 來宣告了，編譯器無法型別推斷出來
             */
            //Method(out var y); //error: 以下方法或屬性之間的呼叫模稜兩可: 'Program.Method(out int)' 和 'Program.Method(out string)'
            Method(out int y); //OK
        }

        static void Method(out int x)
        {
            x = 1;
        }
        static void Method(out string x)
        {
            x = "a";
        }
    }
}