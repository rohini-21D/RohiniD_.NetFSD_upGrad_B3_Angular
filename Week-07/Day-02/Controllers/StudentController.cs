using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(string name,int age,string course)
        {
            if (string.IsNullOrEmpty(name))
            {
                ViewBag.Error = "Name is required";
                return View();
            }
            if (age <= 0)
            {
                ViewBag.Error = "Age must be a Positive number";
                return View();
            }
            if (string.IsNullOrEmpty(course))
            {
                ViewBag.Error = "Course is required";
                return View();
            }
            return RedirectToAction("Display", new {name,age,course});
        }

        [HttpGet("display")]
        public IActionResult Display(string name,int age,string course)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;
            return View();
        }
    }
}
