namespace NumberAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            int evenCount = 0;
            int oddCount = 0;
            int sum = 0;
            int i=1;
            Console.WriteLine("Enter the Number : ");
            n=int.Parse(Console.ReadLine());

            if (n < 1)
            {
                Console.WriteLine("Invalid Input, Please enter a Positive integer.");
                return;
            }

            while (i <= n)
            {
                sum += i;

                if (i % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }

                i++;
            }

            Console.WriteLine("Even Count : " + evenCount);
            Console.WriteLine("Odd Count : " + oddCount);
            Console.WriteLine("Sum : " + sum);

            Console.ReadLine();
        }
    }
}
