using System;

/*
 * Out 變數: 忽略 out 參數
*/
namespace _01_Out_Variables_04
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 如果要忽略某個 out 參數，可以使用: _.
             */
            Method(out int x, out _);
            Console.WriteLine(x);


            /*
             * 例如我們只想知道某個值可不可以轉為數值，但我們不在乎數值是什麼，可以這樣做
             */
            if (int.TryParse("x", out _))
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        static void Method(out int x, out int y)
        {
            x = 1;
            y = 2;
        }
    }
}