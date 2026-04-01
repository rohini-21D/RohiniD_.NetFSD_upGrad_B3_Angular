using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        
        [HttpGet("form")]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost("submit")]
        public IActionResult Submit(string name, string comments, int rating)
        {
            if (rating >= 4)
            {
                ViewData["Message"] = "Thank You for your positive feedback!";
            }
            else
            {
                ViewData["Message"] = "We will improve based on your feedback.";
            }

            return View("Form"); // return same page with message
        }
    }
}