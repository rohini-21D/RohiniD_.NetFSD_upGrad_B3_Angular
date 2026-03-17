namespace ConsoleApp
{
    //Define a Record to store student details.
    public record Student(int RollNumber, string Name, string Course, int Marks);

    internal class Program
    {
        static Student[] student = new Student[100];
        static int count = 0;
        static void AddStudents()
        {
            Console.WriteLine("Enter number of Students : ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEnter Details For Student {i + 1}: ");

                int rollNo;
                string name, course;
                int marks;

                // Roll validation
                while (true)
                {
                    Console.WriteLine("Enter Roll Number : ");
                    if (int.TryParse(Console.ReadLine(), out rollNo) && rollNo > 0)
                        break;
                    else
                        Console.WriteLine("Invalid Roll Number! Try again.");
                }

                // Name
                Console.WriteLine("Enter Name : ");
                name = Console.ReadLine();

                // Course
                Console.WriteLine("Enter Course : ");
                course = Console.ReadLine();

                // Marks validation
                while (true)
                {
                    Console.WriteLine("Enter Marks (0-100) : ");
                    if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100)
                        break;
                    else
                        Console.WriteLine("Invalid Marks! Try again.");
                }

                student[count++] = new Student(rollNo, name, course, marks);
            }
        }

        static void DisplayStudents()
        {
            if (count == 0)
            {
                Console.WriteLine("\nNo Records Found");
                return;
            }

            Console.WriteLine("\nStudent Records:");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Roll No: {student[i].RollNumber} | Name: {student[i].Name} | Course: {student[i].Course} | Marks: {student[i].Marks}");
            }
        }

        static void SearchStudents()
        {
            Console.WriteLine("Enter Roll No To search : ");
            int roll=int.Parse(Console.ReadLine());

            bool found = false;

            for(int i = 0; i < count; i++)
            {
                if (student[i].RollNumber== roll)
                {
                    Console.WriteLine("\nStudent Details Found : ");
                    Console.WriteLine($"Roll No :  {student[i].RollNumber} | Name :{student[i].Name} | Course :{student[i].Course}| Marks :{student[i].Marks}");
                    found = true;
                    break;
                }
            }
            
            if (!found)
            {
                Console.WriteLine("REcord not found...");
            }
        }
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("\n====Student Record System====");
                Console.WriteLine("1.Add Students");
                Console.WriteLine("2.Display Students : ");
                Console.WriteLine("3.Search Students : ");
                Console.WriteLine("4.Exit");
                Console.WriteLine("Enter Your Choice : ");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        AddStudents();
                        break;
                    case 2:
                        DisplayStudents();
                        break;
                    case 3:
                        SearchStudents();
                        break;
                    case 4:
                        Console.WriteLine("Exiting Choices..");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice !");
                        break;
                }

            }

            while (choice != 4);
            Console.ReadLine();
        }
    }
}
