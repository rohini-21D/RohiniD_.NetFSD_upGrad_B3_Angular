using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> products = new List<Product>
            {
                new Product { ProdId = 1, ProdName = "Laptop", ProdCategory="Electronics" ,ProdPrice = 50000 },
                new Product { ProdId = 2, ProdName = "Mobile", ProdCategory="Electronics", ProdPrice = 20000 },
                new Product { ProdId = 3, ProdName = "Tablet",ProdCategory="Electronics", ProdPrice = 15000 },
                new Product { ProdId = 4, ProdName = "Office Chair", ProdCategory = "Furniture", ProdPrice = 5000 },
                new Product { ProdId = 5, ProdName = "Dining Table", ProdCategory = "Furniture", ProdPrice = 12000 },
                new Product { ProdId = 6, ProdName = "T-Shirt", ProdCategory = "Clothing", ProdPrice = 800 },
                new Product { ProdId = 7, ProdName = "Running Shoes", ProdCategory = "Footwear", ProdPrice = 2500 },
                new Product { ProdId = 8, ProdName = "Refrigerator", ProdCategory = "Home Appliances", ProdPrice = 30000 }
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

            if (product == null)
                return RedirectToAction("Index");

            return  View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                products.Add(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.ProdId == id); 
            return View(product);
        }
        [HttpPost]

        public IActionResult Edit(Product product)
        {
            var existing = products.FirstOrDefault(p => p.ProdId == product.ProdId);
            if(existing != null)
            {
                existing.ProdName = product.ProdName;
                existing.ProdCategory = product.ProdCategory;
                existing.ProdPrice = product.ProdPrice;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.ProdId == id);

            if(product==null)
                return RedirectToAction("Index");

            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(int id, Product product)
        {
            var existin = products.FirstOrDefault(p => p.ProdId == id);

            if (existin != null)
            {
                products.Remove(existin);
            }
            return RedirectToAction("Index");
        }
    }
}
