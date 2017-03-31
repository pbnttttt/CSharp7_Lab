using System;
using System.Threading.Tasks;

/*
 * 需要安裝包:System.Threading.Tasks.Extensions
 * 
 * 一般 Task<T> 用於 Async /Await 上，T 通常是一個參考型別(class)
 * 
 * 如果 T 是一個實值型別，效能就有所浪費，所以新增了一個 ValueTask<T> 的結構(struc)，讓效能更好
 * 
 */
namespace _08_Generalized_async_return_types_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Class01 obj = new Class01();

            var GetDateStringTask = obj.GetDateString();
            GetDateStringTask.Wait();
            Console.WriteLine(GetDateStringTask.Result);

            var GetDateTicketTask = obj.GetDateTicket();
            Console.WriteLine(GetDateTicketTask.Result);
        }
    }

    public class Class01
    {
        public async Task<string> GetDateString()
        {
            await Task.Delay(1000);
            return DateTime.Now.ToString();
        }

        public async ValueTask<long> GetDateTicket()
        {
            await Task.Delay(1000);
            return DateTime.Now.Ticks;
        }
    }
}