using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    internal class Employee
    {
        private int _empId;
        private string _fullName;
        private int _age;
        private decimal _salary;

        //readonly property
        public int EmployeeId { get; }

        public string FullName
        {
            get => _fullName; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Full Name Cannot be empty or White Space");
                }
                //automatically remove the extra spaces
                _fullName = value.Trim();
            }
        }

        public int Age
        {
            get => _age; 
            set
            {
                if(value< 18 || value > 80)
                {
                    throw new ArgumentException("Age must be between 18 and 80");
                }
                _age = value;
            }
        }

        public decimal Salary
        {
            get => _salary; 
            private set
            {
                if (value < 1000)
                {
                    throw new ArgumentException("Salary Cannot be less Than 1000");
                }
                _salary = value;
            }
        }
        //Object Creation(Constructors)

        public Employee(int empId,string fullName,decimal salary,int age)
        {
            EmployeeId = empId;
            FullName = fullName;
            Age = age;
            Salary=salary;
        }

        public void GiveRaise(decimal percentage)
        {
            if(percentage<=0 || percentage > 30)
            {
                throw new ArgumentException("Raise Percenage Must be between 0 and 30 .");
            }
            Salary += (Salary * percentage / 100);
            Console.WriteLine($"Salary incresed by {percentage} %");
            Console.WriteLine($"New Salary is {Salary}");
        }
        public bool DeductPenalty(decimal amount)
        {
            if(amount <=0)
            {
                throw new ArgumentException("Penality amount must be Positive");
            }

            if (Salary - amount < 1000)
                return false;

            Salary -= amount;
            return true;
        }
    }
}
