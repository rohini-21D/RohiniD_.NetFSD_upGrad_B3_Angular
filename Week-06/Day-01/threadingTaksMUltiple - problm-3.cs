using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task GenerateSalesReport()
        {
            Console.WriteLine("Sales Report Started....");
            await Task.Delay(5000);
            Console.WriteLine("Sales Report Ended....");
        }
        static async Task GenerateInventoryReport()
        {
            Console.WriteLine("Inventory Report Started....");
            await Task.Delay(6000);
            Console.WriteLine("Inventory Report Ended....");
        }
        static async Task GenerateCustomerReport()
        {
            Console.WriteLine("Customer Report Started....");
            await Task.Delay(5000);
            Console.WriteLine("Customer Report Ended....");
        }
        static async Task Main()
        {
            Console.WriteLine("Starting All Reports");

            var task1 = Task.Run(() =>  GenerateSalesReport());
            var task2= Task.Run(() =>  GenerateInventoryReport());
            var task3= Task.Run(() =>  GenerateCustomerReport());

            await Task.WhenAll(task1, task2, task3);

            Console.WriteLine("\nAll Reports generated Successfully !");
            Console.ReadLine();
        }
    }

}
