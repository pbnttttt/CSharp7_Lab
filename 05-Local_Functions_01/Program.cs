using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*
 * Local Function: 區域函式
 * 1. 當A方法只在使用它的B方法中才有意義時，可以將這個A方法使用 local functoin的型式定義在B方法中
 * 2. A方法可以存取得到B方法的參數和變數，就如同匿名方法一樣
 */
namespace _05_Local_Functions_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Class01 obj = new Class01();

            var result = obj.Method01(5);
            Console.WriteLine(result);

            //local funtion 可以存取使用他的方法的區域變數
            var result2 = obj.Method02("LocalFunction");
            Console.WriteLine(result2);

            //local function 也可以使用 value tuple
            var result3 = obj.Method03("ab", "cde");
            Console.WriteLine(result3);
        }
    }

    public class Class01
    {
        public int Method01(int x)
        {
            return LocalFunction(x);

            int LocalFunction(int y)
            {
                return y * y;
            }
        }

        public string Method02(string x)
        {
            return LocalFunction(x.Length);

            string LocalFunction(int length)
            {
                return $"{x}:{length}";
            }
        }

        public int Method03(string firstName, string lastName)
        {
            var result = LocalFunction();
            return result.x + result.y;

            (int x, int y) LocalFunction()
            {
                return (firstName.Length, lastName.Length);
            }
        }
    }
}