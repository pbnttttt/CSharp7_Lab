using System;

/*
 * Deconstruction: 解構
 * 在 C# 7 tuple 上的使用方式
 */
namespace _04_Deconstruction_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //deconstructing declaration
            //將回傳的 tulpe type 照順序解構，明確指定型別
            (int x1, string y1) = Method01();
            Console.WriteLine($"{x1}-{y1}");

            //var inside
            //將回傳的 tulpe type 照順序解構，型別可用 var 去接, 型別自動推斷
            (var x2, var y2) = Method01();
            Console.WriteLine($"{x2}-{y2}");

            //var outside
            //將回傳的 tulpe type 照順序解構，型別可用 var 去接, 型別自動推斷
            //但重複指定 var 型別很煩人，可以拉到外部去
            var (x3, y3) = Method01();
            Console.WriteLine($"{x3}-{y3}");

            //deconstructing assignment
            //將回傳的 tulpe type 照順序解構，並附值給現有的變數
            int x4;
            string y4;
            (x4, y4) = Method01();
            Console.WriteLine();
        }

        static (int x, string y) Method01()
        {
            return (1, "A");
        }
    }
}