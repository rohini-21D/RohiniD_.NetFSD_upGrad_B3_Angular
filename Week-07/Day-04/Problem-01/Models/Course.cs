using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage ="Enter the Course")]
        public string CourseName { get; set; }

        //while a course can have multiple students.
        public List<Student> Students { get; set; } = new List<Student>();//Navigation Property
    }
}
