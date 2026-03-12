namespace bonusCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string empName;
            double empSalary;
            int yearofExp;
            double bonus;
            double finalSalary;
            Console.WriteLine("Enter Your Name");
            empName = Console.ReadLine();

            Console.WriteLine("Enter Salary: ");
            empSalary = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Experience: ");
            yearofExp = int.Parse(Console.ReadLine());


            if (yearofExp < 2)
            {

                bonus = 0.05 * empSalary;

            }
            else if (yearofExp < 5)
            {

                bonus = 0.10 * empSalary;

            }
            else {
                bonus=0.15 * empSalary;
            }

            finalSalary = empSalary + bonus;

            Console.WriteLine("Employee Name :" + empName);
            Console.WriteLine("Bonus: " + bonus);           
            Console.WriteLine("Final Salary : " + finalSalary);

            Console.ReadLine();
        }
    }
}
