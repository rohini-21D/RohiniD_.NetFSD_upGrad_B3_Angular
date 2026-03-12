namespace calculatorUsingSwitch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1;
            int num2;
            char op;
            int result = 0;

            Console.WriteLine("Enter num1: ");
            num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter num2: ");
            num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter operator (+,-,*,/): ");
            op = Convert.ToChar(Console.ReadLine());

            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;

                case '-':
                    result = num1 - num2;
                    break;

                case '*':
                    result = num1 * num2;
                    break;

                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine("Division by 0 not allowed");
                        return;
                    }
                    result = num1 / num2;
                    break;

                default:
                    Console.WriteLine("Invalid Operator");
                    return;
            }

            Console.WriteLine("Result : " + result);

            Console.ReadLine();
        }
    }
}
