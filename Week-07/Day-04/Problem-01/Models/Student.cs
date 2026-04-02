namespace WebApplication5.Models
{
    public class Student
    {
        public int StudentId { get;set; }
        public string? StudName { get; set; }
        public int CourseId { get;set; } //Foreign key
        public Course? Course { get;set; }//Naviagtion Property

    }
}
