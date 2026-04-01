using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("calculate")]
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("add")]
        public IActionResult Add(int num1,int num2)
        {
            int result = num1 + num2;

            ViewData["Result"] = result;

            return View();
        }
    }
}
