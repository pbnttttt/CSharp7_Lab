using System;

/*
 * 數字 literal，可以使用 _ 做分隔，增加可讀性
 * 二進位表示法也可以
 */
namespace _06_Literal_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var salary = 11_189_513;
            Console.WriteLine(salary);

            var b = 0b1010_1011_1100_1101_1110_1111;
            Console.WriteLine(b);
        }
    }
}