using System;
using static System.Console; //C# 6.0

/*
 * pattern matching 在 switch case 使用上的特色：
 * 1. 可以 switch 任何型別，不只是原始型別(primitive types)
 * 2. pattern 可以用在 case 語句
 * 3. case 語句可以含有額外的條件(when expression)
 * 
 * pattern matching 在 switch case 使用上的注意事項：
 * 1. case 語句的順序是重要的：如果 Rectangle r 放在 Rectangle s 之前，那 Rectangle s 永遠不會被評估到，就會爆錯(error：先前的案例已處理切換案例).
 * 2. default 子句總是最後被評估：所以 case null 雖然放在最後，但還是會比 default 子句早評估到，但優良的寫法最好把 default 子句放最後
 * 3. null 子句在最後面並不會無法達到：這是因為類型模式依循目前 is 表達式的例子，而並不匹配 null。這確保 null 值不會不小心被任何類型的模式給搶走；您必須更清楚要如何處理它們（或留它們給 default 子句）。
 * 4. pattern variables 也要注意作用域
 */
namespace _02_Pattern_Matching_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Method01("a");
            //Method01(null);
            Method01(new Circle { Radius = 3 });
        }

        static void Method01(object shape)
        {
            switch (shape)
            {
                case Circle c:
                    WriteLine($"circle with radius {c.Radius}");
                    break;
                case Rectangle s when (s.Length == s.Height):
                    WriteLine($"{s.Length} x {s.Height} square");
                    break;
                case Rectangle r:
                    WriteLine($"{r.Length} x {r.Height} rectangle");
                    break;
                default:
                    WriteLine("<unknown shape>");
                    break;
                case null: //constant pattern
                    throw new ArgumentNullException(nameof(shape));
            }
        }
    }

    class Circle
    {
        public int Radius { get; set; }
    }

    class Rectangle
    {
        public int Length { get; set; }
        public int Height { get; set; }
    }
}