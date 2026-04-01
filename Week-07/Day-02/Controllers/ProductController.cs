using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using System.Collections.Generic;

namespace WebApplication3.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        
        private static List<Product> products = new List<Product>();

        
        [HttpGet("index")]
        public IActionResult Index()
        {
            ViewBag.Products = products;
            return View();
        }

     
        [HttpPost("add")]
        public IActionResult Add(string name, int price, int quantity)
        {
            Product p = new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity
            };

            products.Add(p);

            

            return RedirectToAction("Index");
        }
    }
}