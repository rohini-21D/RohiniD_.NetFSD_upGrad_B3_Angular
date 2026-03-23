using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Product Name : ");
            string prodName=Console.ReadLine();

            Console.WriteLine("Enter Product Price : ");
            double prodPrice=Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Discount % (percentage) : ");
            double discount=Convert.ToDouble(Console.ReadLine());

            if(discount<0 || discount > 100)
            {
                Console.WriteLine("Invalid Dsicount Value");
                return;
            }
            double FinalPrice = prodPrice - (prodPrice * discount / 100);

            Console.WriteLine("\n ----- Bill Details -----");
            Console.WriteLine($"Product : {prodName}");
            Console.WriteLine($"Origial Price : {prodPrice}");
            Console.WriteLine($"Discount : {discount}");
            Console.WriteLine($"FinalPrice : {FinalPrice}");

            Console.ReadLine();
        }
    }

}
