using System;


namespace ConsoleApp
{
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }

    public class RegularCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.05;
        }
    }

    public class PremiumCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.10;
        }
    }

    public class VIPCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.20;
        }
    }

    public class PriceCalculator
    {
        private IDiscountStrategy discountStrategy;
        
        public PriceCalculator(IDiscountStrategy discountStrategy)
        {
            this.discountStrategy = discountStrategy;
        }

        public void CalculateFinalPrice(double amount)
        {
            double discount = discountStrategy.CalculateDiscount(amount);
            double finalPrice = amount - discount;

            Console.WriteLine($"Original Price : {amount}");
            Console.WriteLine($"Discount       : {discount}");
            Console.WriteLine($"Final Price    : {finalPrice}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            double amount = 1000;
            IDiscountStrategy strategy=new RegularCustomerDiscount();
            PriceCalculator calculator = new PriceCalculator(strategy);

            calculator.CalculateFinalPrice(amount);
            Console.ReadLine();
        }
    }
}
