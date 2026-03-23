using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
       
        static async Task VerifyPaymentAsync()
        {
            Console.WriteLine("Verifying Payment");
            await Task.Delay(2000);
            Console.WriteLine("Payment successsfull ");
        }

        static async Task CheckInventoryAsync()
        {
            Console.WriteLine("Checking Inventory");
            await Task.Delay(3000);
            Console.WriteLine("Available Inventory");
        }

        static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("Confirming Order");
            await Task.Delay(4000);
            Console.WriteLine("Order Confirmed...");
        }
        static async Task Main()
        {
            Console.WriteLine("Order Processing Started");
            //Execute steps asynchronously while maintaining the logical order of operations.
           
            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();

            Console.WriteLine("\n Order Process Completed Succesfully");
            Console.ReadLine();
        }
    }

}
