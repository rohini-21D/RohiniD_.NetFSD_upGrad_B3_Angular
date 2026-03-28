
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Marks { get; set; }
    }

    public class StudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }
    }
    public class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            Console.WriteLine("-----STUDENT REPORT-------");

            foreach (var student in students)
            {
                Console.WriteLine($"ID     : {student.Marks}");
                Console.WriteLine($"Name   : {student.StudentName}");
                Console.WriteLine($"Marks  : {student.Marks}");

                string result = student.Marks >= 40 ? "Pass" : "Fail";
                Console.WriteLine($"Result : {result}");

                Console.WriteLine("----------------------------------");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var repository = new StudentRepository();
            var reportGenerator = new ReportGenerator();

            repository.AddStudent(new Student
            {
                StudentId = 101,
                StudentName = "Rohini",
                Marks = 85
            });

            repository.AddStudent(new Student
            {
                StudentId = 102,
                StudentName = "Rekha",
                Marks=35
            });

            var students=repository.GetAllStudents();

            reportGenerator.GenerateReport(students);

            Console.ReadLine();
        }
    }
}
