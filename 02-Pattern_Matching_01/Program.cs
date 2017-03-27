using System;

/*
 * Pattern Matching 稱為模式匹配
 * 1.是一種新語法，可以用來「測試」值是否為某個型別，是的話還可以進一步取得值的訊息
 * 
 * 2.有三種 pattern
 *   2.1 Constant patterns(常數模式): 以 c 表示( c 為常數). 測試輸入是否等於 c
 *   2.2 Type patterns(類型模式): 以 T x 表示( T 為型別， x 為以 T 宣告的變數). 測試輸入是否等於 T, 是的話將輸入 assign 給 x 變數.
 *   2.3 Var patterns(Var 模式): ??
 *   
 * 3. pattern matching 強化了現有二種語法結構
 *   3.1 is-expression (is 運算式). ex: value is pattern
 *   3.2 switch 的 case 語句
 *   
 * 4. 值為 dynamic 型別時，是否可處理
 *    Constant patterns: 可
 *    Type patterns: 不可
 * 
 * 5. x 稱為 pattern variables，與 out variables 類似，要注意作用域.
      pattern variables & out variables 可稱為 "expression variables"
 */
namespace _02_Pattern_Matching_01
{
    /*
     * Constant patterns(常數模式)
     */
    class Program
    {
        const string KEY = "ABCD";

        static void Main(string[] args)
        {
            //Constant patterns
            Method01("ABCD");

            //Type patterns
            Method02(5);

            //可以接受值的型別為 int or string , 但值必需是數字
            Method03("5");
            Method03(5);
        }

        static void Method01(dynamic o)
        {
            if(o is KEY) 
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        static void Method02(object o)
        {
            if(o is int x)
            {
                Console.WriteLine(x);
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        static void Method03(object o)
        {
            if(o is int x || 
                (o is string s && int.TryParse(s, out x))) //因為 x 在之前的 type patterns 宣告了，在相同作用域下，TryParse 時可以帶入
            {
                Console.WriteLine(x);
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        /// <summary>
        /// Method03, 的舊寫法，醜!!
        /// </summary>
        /// <param name="o"></param>
        static void Method4(object o)
        {
            int x;
            if (o is int)
                x = (int)o;
            else if(o is string && int.TryParse((o as string), out x))
            {
                Console.WriteLine(x);
            }
        }
    }

    class C1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}