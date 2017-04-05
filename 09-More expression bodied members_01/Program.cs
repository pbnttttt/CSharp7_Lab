using System;
using System.Collections.Concurrent;

/*
 * expression bodied 是 C# 6.0 引進的一種語法，目的用於簡化程式碼，但只可用在成員中的方法和屬性上
 * 可參考以下連結
 * http://www.informit.com/articles/article.aspx?p=2414582
 * 
 * 在 C# 7.0 引進了更多選擇，可以用在「建構式」「解構式」「存取子」
 * 
 * 這是社群 contributed 的功能
 */
namespace _09_More_expression_bodied_members_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Person
    {
        private static ConcurrentDictionary<Guid, string> names = new ConcurrentDictionary<Guid, string>();
        private Guid id => Guid.NewGuid();

        public Person(string name) => names.TryAdd(id, name); // constructors
        ~Person() => names.TryRemove(id, out _);              // destructors
        public string Name
        {
            get => names[id];                                 // getters
            set => names[id] = value;                         // setters
        }
    }
}