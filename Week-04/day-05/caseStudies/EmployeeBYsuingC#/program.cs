namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emp = new Employee(101,"Anna",4500,25);

            Console.WriteLine("Emplloyee ID : " + emp.EmployeeId);
            Console.WriteLine("Employee Name : " + emp.FullName);
            Console.WriteLine("Employee Age : " + emp.Age);
            Console.WriteLine("Employee Salary : " + emp.Salary);

            emp.GiveRaise(20);

            bool result = emp.DeductPenalty(5);
            Console.WriteLine("=========================");

            Console.WriteLine(result ? "Penality Applied " : "Penality Rejected");

            Console.ReadLine();
        }
    }
}
