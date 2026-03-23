using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;


namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Application Started");

            var t1= WriteLogAsync("Rohini");
            var t2 = WriteLogAsync("Rekha");
            var t3 = WriteLogAsync("Pavan Kumar");
            var t4 = WriteLogAsync("Sandy");

            Console.WriteLine("Application Ended");
            Console.WriteLine();
            await Task.WhenAll(t1,t2,t3);

            Console.WriteLine("All logs are written");

            Console.ReadLine();
        }

        public static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"Heloooo..Start Writing Messages {message}");

            await Task.Delay(3000);

            Console.WriteLine($"Thnak youu..For Completing the message {message}");
        }
    }
}
