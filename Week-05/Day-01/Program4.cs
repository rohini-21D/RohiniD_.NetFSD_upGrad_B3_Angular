using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Vehicle
    {
        private string _brand;
        private double _rentalRatePerDay;

        public string Brand 
        {
            get { return _brand; }
            set { _brand = value; }
        
        }

        public double RentalRatePerDay
        {
            get { return _rentalRatePerDay; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Rental cannot be negative ");
                    return;
                }
                _rentalRatePerDay = value;
            }
        }
        public virtual double CalculateRental(int days)
        {
            return RentalRatePerDay * days;
        }
    }

    class Car : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double total = base.CalculateRental(days);

            if (total == 0)
                return 0;

            return total += 500;
        }
    }

    class Bike : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double total= base.CalculateRental(days);

            if (total == 0) return 0;

            return total - (total * 0.05);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = new Car();
            car.Brand = "BMW X7";
            car.RentalRatePerDay = 3500;

            int days = 3;

            Console.WriteLine("Car Brand : " +car.Brand);
            Console.WriteLine("Total RentalPerDay : " +car.CalculateRental(days));

            Vehicle bike = new Bike();
            bike.Brand = "Royal Enfield Himalayan 750";
            bike.RentalRatePerDay = 100000;

            Console.WriteLine("Bike Brand : " + bike.Brand);
            Console.WriteLine("Total RentPerDay : " + bike.CalculateRental(days));

            Console.ReadLine();
        }
    }
}
