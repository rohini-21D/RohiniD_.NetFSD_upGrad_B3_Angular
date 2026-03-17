namespace ConsoleApp
{
    class Calculator
    {
        public void Divide(int numerator, int denominator)
        {
            try
            {
                
                int result = numerator / denominator;
                Console.WriteLine("Result : "+ result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: numerator cannot be diivded by ZERO");
            }
            finally
            {
                Console.WriteLine("Operation Completed Succesfully");
            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Calculator calculator = new Calculator();
                int numerator = 80;
                int denominator = 40;
                calculator.Divide(numerator, denominator);

                Console.WriteLine("Program is Still Running....");

                Console.ReadLine();
            }
        }
    }
}
