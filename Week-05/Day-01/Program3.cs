using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Product
    {
        private string _name;
        private double _price;
        public string Name 
        { 
            get { return _name; }
            set {  _name = value;} 
        }

        public double Price 
        { 
            get { return _price; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Price cannot be negative");
                    return;
                }
                _price = value;
            } 
        }

        public virtual double CalculateDiscount()
        {
            return Price;
        }

    }

    class Electronics : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.05);
        }
    }

    class Clothing : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.15);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Product electronics = new Electronics();
            electronics.Name = "Laptop";
            electronics.Price = 85000;

            Product clothing=new Clothing();
            clothing.Name = "Jacket";
            clothing.Price = 8000;

            Console.WriteLine("Electonics Final price afetr 5% discount = " + electronics.CalculateDiscount());
            Console.WriteLine("clothing Final peice after 15% discpunt  = " + clothing.CalculateDiscount());

            Console.ReadLine();
        }
    }
}
