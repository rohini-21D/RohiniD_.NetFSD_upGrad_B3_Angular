namespace OOPS
{
    class Calculator {

        public double Add(int num1,int num2)
        {
            double result = num1 + num2;
            return result;
        }
        public double Subtract(int num1, int num2)
        {
            double result = num1 - num2;
            return result;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            
            double sum = calc.Add(10,50);
            double difference = calc.Subtract(30,20);

            Console.WriteLine("Addition : " + sum);
            Console.WriteLine("Subtraction : " + difference);

            Console.ReadLine();
        }
    }
}
