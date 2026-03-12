using System.Numerics;

namespace OOPS
{
    class Student
    {
        public double CalculateAverage(int m1,int m2,int m3)
        {
            return ( m1 + m2 + m3 ) / 3;      
        }

        public string GetGrade(double avg)
        {
            if (avg >= 80)
                return "A";
            else if (avg >= 60)
                return "B";
            else if (avg >= 40)
                return "C";
            else
                return "Fail";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            double average =student.CalculateAverage(50, 60, 80);
            string Grade = student.GetGrade(average);

            Console.WriteLine("Average = " + average + " ,Grade = " + Grade);

            Console.ReadLine();
        }
    }
}
