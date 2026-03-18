using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp
{

    internal class Program
    {
        static void DisplayValue(string title, object value)
        {
            Console.WriteLine(title);
            Console.WriteLine("------------------------------------");
            Console.WriteLine(value);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Product product = new Product();
            var products = product.GetProducts();


            //1. FMCG Products
            var result1 = from p in products
                          where p.ProCategory == "FMCG"
                          select p;

            Console.WriteLine("FMCG Products");
            foreach (var item in result1)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            Console.WriteLine();

            //2. Grain Products
            var result2 = from p in products
                          where p.ProCategory == "Grain"
                          select p;

            Console.WriteLine("Grain Products");
            foreach (var item in result2)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            Console.WriteLine();

            //3. Sort by ProCode
            var sortCode = from p in products
                           orderby p.ProCode
                           select p;

            Console.WriteLine("Sort by Code");
            foreach (var item in sortCode)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            Console.WriteLine();

            //4. Sort by Category
            var sortCategory = from p in products
                               orderby p.ProCategory
                               select p;

            Console.WriteLine("Sort by Category");
            foreach (var item in sortCategory)
                Console.WriteLine($"{item.ProCategory}\t{item.ProName}");
            Console.WriteLine();

            //5. Sort by MRP Asc
            var sortMrp = from p in products
                          orderby p.ProMrp
                          select p;

            Console.WriteLine("Sort by MRP Asc");
            foreach (var item in sortMrp)
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");
            Console.WriteLine();

            //6. Sort by MRP Desc
            var sortDesc = from p in products
                           orderby p.ProMrp descending
                           select p;

            Console.WriteLine("Sort by MRP Desc");
            foreach (var item in sortDesc)
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");
            Console.WriteLine();

            //7. Group by Category
            var groupCategory = from p in products
                                group p by p.ProCategory;

            Console.WriteLine("Group by Category");
            foreach (var grp in groupCategory)
            {
                Console.WriteLine("Category: " + grp.Key);
                foreach (var item in grp)
                    Console.WriteLine($"{item.ProName}\t{item.ProMrp}");
            }
            Console.WriteLine();

            //8. Group by MRP
            var groupMrp = from p in products
                           group p by p.ProMrp;

            Console.WriteLine("Group by MRP");
            foreach (var grp in groupMrp)
            {
                Console.WriteLine("MRP: " + grp.Key);
                foreach (var item in grp)
                    Console.WriteLine($"{item.ProName}");
            }
            Console.WriteLine();

            //9. Highest price FMCG
            var maxPrice = (from p in products
                            where p.ProCategory == "FMCG"
                            select p.ProMrp).Max();

            var highestFmcg = from p in products
                              where p.ProCategory == "FMCG" && p.ProMrp == maxPrice
                              select p;

            Console.WriteLine("Highest FMCG Product");
            foreach (var item in highestFmcg)
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");
            Console.WriteLine();

            //10. Total count
            DisplayValue("Total Products", products.Count());

            //11. Count FMCG
            int countFmcg = (from p in products
                             where p.ProCategory == "FMCG"
                             select p).Count();

            DisplayValue("FMCG Count", countFmcg);

            //12. Max price
            DisplayValue("Max Price", products.Max(p => p.ProMrp));

            //13. Min price
            DisplayValue("Min Price", products.Min(p => p.ProMrp));

            //14. All below 30
            DisplayValue("All below 30?", products.All(p => p.ProMrp < 30));

            //15. Any below 30
            DisplayValue("Any below 30?", products.Any(p => p.ProMrp < 30));

            Console.ReadLine();

        }
    }
}
