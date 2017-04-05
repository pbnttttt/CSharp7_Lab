using System;

/*
 * throw 運算式增強：
 * 現在可以在特定的地方使用 throw 運算式
 */
namespace _10_Throw_expressions_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = 3;
            bool result() => i == 3 ? true : false;
            bool result1() => i == 3 ? true : throw new Exception(); // 在 c# 7 之前，會爆錯，現在ok
        }
    }

    class Person
    {
        public string Name { get; }
        public Person(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));
        public string GetFirstName()
        {
            var parts = Name.Split(' ');
            return (parts.Length > 0) ? parts[0] : throw new InvalidOperationException("No name!");
        }
        public string GetLastName() => throw new NotImplementedException();
    }
}