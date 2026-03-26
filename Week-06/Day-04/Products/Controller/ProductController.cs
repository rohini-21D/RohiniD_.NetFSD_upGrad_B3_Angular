using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        List<Product> products = new List<Product>()
            {
                new Product { ProdId = 1, ProdName = "Laptop", ProdCategory="Electronics" ,ProdPrice = 50000 },
                new Product { ProdId = 2, ProdName = "Mobile", ProdCategory="Electronics", ProdPrice = 20000 },
                new Product { ProdId = 3, ProdName = "Tablet",ProdCategory="Electronics", ProdPrice = 15000 }
            };
        
        //Index 	---	to display collection of products
        public IActionResult Index()
        {
            return View(products);
        }

        //b.Details ---  to display  single product information
        public IActionResult Details(int id)
        {
            var product = products.Find(p => p.ProdId == id);
            return  View(product);
        }
    }
}
