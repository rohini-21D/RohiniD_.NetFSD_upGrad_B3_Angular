namespace handsOn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName;
            int userMarks;
            Console.WriteLine("Enter Your Name: ");
            userName = Console.ReadLine();

            Console.WriteLine("Enter Your Marks: ");
            userMarks =int.Parse (Console.ReadLine());

            if(userMarks<0 || userMarks > 100)
            {
                Console.WriteLine("Invalid Marks Entered");
            }
            else if(userMarks>=90){
                Console.WriteLine("Student : " + userName);
                Console.WriteLine("Grade : A");
            }
            else if(userMarks>=75){
                Console.WriteLine("Student : " + userName);
                Console.WriteLine("Grade : B");
            }
            else if(userMarks>=60){
                Console.WriteLine("Student : " + userName);
                Console.WriteLine("Grade : C");
            }
            else if (userMarks >= 50){
                Console.WriteLine("Student : " + userName);
                Console.WriteLine("Grade : D");
            }
            else
            {
                Console.WriteLine("Grade : Fail");
            }
            Console.ReadLine();
        }
    }
}
