using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }

        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }

    class Manager : Employee
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.20);
        }
    }

    class Developer : Employee 
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.10);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee manager = new Manager();
            manager.Name = "Rohini";
            manager.BaseSalary = 50000;
           

            Employee developer =new Developer();
            developer.Name = "Alex";
            developer.BaseSalary = 50000;


            Console.WriteLine("Manager Salary : " +manager.CalculateSalary());
            Console.WriteLine("Developer Salary : " + developer.CalculateSalary());
            Console.ReadLine();
        }
    }
}
