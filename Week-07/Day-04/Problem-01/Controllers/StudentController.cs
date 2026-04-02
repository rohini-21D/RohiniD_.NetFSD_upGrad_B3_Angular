using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Content("Model isinvalid");
            }
            
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            ViewBag.Courses = new SelectList(_context.Courses, "CourseId", "CourseName");
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Courses = new SelectList(_context.Courses, "CourseId", "CourseName");
            return View(student);
        }
        public IActionResult Index()
        {
            var students = _context.Students
                                   .Include(c=>c.Course)
                                   .ToList();
            return View(students);
        }

       public IActionResult Details()
        {
            var details = _context.Courses
                                .Include(p => p.Students)
                                .ToList();
            return View(details);
        }
    }
}
