using System;

/*
 * Deconstruction :不只可以用在解構 Tuple, 也可以用來解構物件，只要他有 Deconstruct 方法或擴充方法。
 * 如果沒有會爆錯：未包含 'Deconstruct' 的定義，也找不到擴充方法 'Deconstruct' 可接受類型 'Point' 的第一個引數
 * 
 * 行為：
 * 物件必需具有 Deconstruct 方法或者擴充方法，參數必需是 out 參數.
 * deconstructing declaration 的變數會照順序丟近物件的 Deconstruct 中，因此方法必需是 out 去接
 * 
 * Deconstruct 可覆載.
 * 
 * 就算沒用到 tuple， 同樣需要安裝 System.ValueTuple 套件
 */
namespace _04_Deconstruction_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point(2, 3);

            var (x1, y1) = point;
            Console.WriteLine($"{x1}-{y1}");

            // overloadding
            var (x2, y2, z2) = point;
            Console.WriteLine($"{x2}-{y2}-{z2}");

            // overloadding: extension method 
            var (x3, y3, z3, j3) = point;
            Console.WriteLine($"{x2}-{y2}-{z2}-{j3}");

            // 忽略其中一個參數
            var (x4, _, z4, j4) = point;
            
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }

        public void Deconstruct(out int x, out int y, out int z)
        {
            x = X;
            y = Y;
            z = x + y;
        }
    }

    public static class PointExtension
    {
        public static void Deconstruct(this Point point, out int x, out int y, out int z, out int j)
        {
            x = point.X;
            y = point.Y;
            z = x + y;
            j = x * y;
        }
    }
}