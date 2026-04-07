using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;
        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetMovies());
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
                _service.CreateMovie(movies);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Movie Name";
                return View();
            }
        }

        public IActionResult Details(int id)
        {
            return View(_service.GetMovieById(id));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_service.GetMovieById(id));
        }

        [HttpPost]
        public IActionResult Edit(Movies movies)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateMovie(movies);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Movie details";
                return View(movies);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie=_service.GetMovieById(id);
            return View(movie);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteCinfirmed(int id)
        {
            var movie = _service.GetMovieById(id);

            if (movie == null)
            {
                ViewBag.ErrorMessage = "Requested movie doesnot exist";
                return View();
            }

            _service.DeleteMovie(id);
            return RedirectToAction("Index");
        }
    }
}
