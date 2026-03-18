namespace ConsoleApp
{
    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }
    class BankAccount
    {
        private double _balance;
        
        public BankAccount(double balance)
        {
            this._balance = balance;
        }
        public void Withdraw(double amount)
        {
            if(amount > _balance)
            {
                throw new InsufficientBalanceException("Error : Withdraal amount exceeds available balance");
            }

            _balance -= amount;
            Console.WriteLine("Withdrawal Succesful. Remaining balance : " + _balance);
        }
    }

    
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount(10000);

            try
            {
                double withdrawAmount = 5000;
                account.Withdraw(withdrawAmount);
            }
            catch(InsufficientBalanceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction Completed");
            }

            Console.WriteLine("Program Continues running ....");
            Console.ReadLine();
        }
    }
}
