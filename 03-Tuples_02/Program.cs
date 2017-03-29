using System;
using System.Linq;
using System.Collections.Generic;

/*
 * Tuples 是實值型別，因此可以比對，當hashcode一樣則相等.
 * 也可以用在 Dictionary 當key，和list 中，效能較好
 */
namespace _03_Tuples_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // tuple 可以直接比對
            var tuple1 = (x: 1, y: "a", z: "A");
            var tuple2 = (1, "a", "A");
            Console.WriteLine(tuple1.GetHashCode());
            Console.WriteLine(tuple2.GetHashCode());
            Console.WriteLine(tuple1.CompareTo(tuple2) == 0);

            // tuple 用於 list 中
            var tuple3List = new List<(int x, string y)>
            {
                (1, "A"),
                (2, "B"),
                (3, "C")
            };
            var result = string.Join(",", tuple3List.Where(tuple => tuple.x > 1).Select(x => x.y));
            Console.WriteLine(result);

            // tuple 用於 Dictionary 中
            var tuple4Dic = new Dictionary<(int x, int y), string>
            {
                { (1, 1), "a" },
                { (2, 2), "b" },
                { (3, 3), "c" },
            };
            var result2 = tuple4Dic[(2, 2)];
            Console.WriteLine(result2);
        }
    }
}