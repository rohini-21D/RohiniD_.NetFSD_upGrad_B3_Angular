using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
namespace ConsoleApp
{
    class Program
    {
        static void Main()
        { 
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
            Trace.AutoFlush = true;

            Console.WriteLine("Order Placed Started...\n");

            try
            {
                validateOrder();
                processPayment();
                updateInventory();
                GenerateInvoice();

                Trace.TraceInformation("Order Proceesed successfully");

                Console.WriteLine("Order completed successfully");
            }

            catch(Exception ex)
            {
                Trace.WriteLine("ERROR" + ex.Message);
                Console.WriteLine("Order Failed");
            }

            Console.WriteLine("\n Check log.txt file for trace details");

            Console.ReadLine();
        }

        static void validateOrder()
        {
            Trace.WriteLine("Step 1: Validating Ordeer...");
        }
        static void processPayment()
        {
            Trace.WriteLine("Step 3: Processing Payment");
        }
        static void updateInventory()
        {
            Trace.WriteLine("step 4: Updating Inventory");

            throw new Exception("Inventory Update Failed");
        }
        static void GenerateInvoice()
        {
            Trace.WriteLine("step 5: Generating Invoice");
        }

    }

}
