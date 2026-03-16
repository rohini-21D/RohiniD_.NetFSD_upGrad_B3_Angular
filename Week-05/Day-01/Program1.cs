using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BankAccount
    {
        private string _accountnumber;
        private double _balance;

        public string AccountNumber
        {
            get { return _accountnumber; }
            set { _accountnumber = value; }
        }

        public double Balance
        {
            get { return _balance; }
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive");
                return;
            }

            _balance += amount;
            Console.WriteLine("Amount Deposited: " + amount);
            Console.WriteLine("Current Balance: " + _balance);
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive");
                return;
            }

            if (amount > _balance)
            {
                Console.WriteLine("Insufficient Balance");
                return;
            }

            _balance -= amount;
            Console.WriteLine("Withdraw Successful: " + amount);
            Console.WriteLine("Total Balance: " + _balance);
        }
        public string GetMaskedAccountNumber()
        {
            if (string.IsNullOrEmpty(_accountnumber))
                return "Account Not Set";

            string last4 = _accountnumber.Substring(_accountnumber.Length - 4);
            string masked = new string('*', _accountnumber.Length - 4);

            return masked + last4;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            account.AccountNumber = "055147852369215";

            account.Deposit(10000);
            account.Withdraw(2000);

            Console.WriteLine("Your Account NUmber : " + account.GetMaskedAccountNumber());
            Console.WriteLine("Total BAlance: " + account.Balance);

            Console.ReadLine();
        }
    }
}
