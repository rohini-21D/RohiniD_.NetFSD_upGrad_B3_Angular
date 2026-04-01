using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;
        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Create(Movies movies)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movies);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            return View(_context.Movies.Find(id));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_context.Movies.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Movies movies)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(movies);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movies);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteCinfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                var movie = _context.Movies.Find(id);

                _context.Movies.Remove(movie);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
