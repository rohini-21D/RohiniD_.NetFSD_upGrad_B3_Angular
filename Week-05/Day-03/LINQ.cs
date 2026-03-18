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
        static void DisplayProducts(IEnumerable<Product>products,string title)
        {
            Console.WriteLine(title);
            Console.WriteLine("-----------------------------------------------");
            foreach (var item in products)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            Console.WriteLine();
        }
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

            //1.Write a LINQ query to search and display all products with category “FMCG”.

            DisplayProducts(
                           
                   products.Where(p=>p.ProCategory=="FMCG"),
                   "All Products With Category FMC"
            );

            //2.Write a LINQ query to search and display all products with category “Grain”.

            DisplayProducts(
                
                    products.Where(p=>p.ProCategory=="Grain"),"All Products With Category Grain "
            );



            //3.Write a LINQ query to sort products in ascending order by product code.

            DisplayProducts(
                products.OrderBy(p=>p.ProCode), "Sorted by Product Code"
             );


            //4.Write a LINQ query to sort products in ascending order by product Category.

            DisplayProducts(
                products.OrderBy(p=>p.ProCategory),"Sorted by Product Category"
            );


            //5.Write a LINQ query to sort products in ascending order by product Mrp.

            DisplayProducts(
                  
                products.OrderBy(p=>p.ProMrp),"Sorting by Product MRP "
            );

            //6.Write a LINQ query to sort products in descending order by product Mrp.

            DisplayProducts(
                
                products.OrderByDescending(p=>p.ProMrp) , "sort products in descending order by product MRP."
            );
           

            //7.Write a LINQ query to display products group by product Category.

            var catgroupBy = products.GroupBy(p => p.ProCategory);
            Console.WriteLine("Products grouped by category");
            Console.WriteLine("--------------------------");

            foreach (var item in catgroupBy)
            {
                Console.WriteLine($"Category: {item.Key}");
                Console.WriteLine("--------------------------");
                foreach (var item1 in item)
                {
                    Console.WriteLine($"{item1.ProCategory}\t{item1.ProName}\t{item1.ProMrp}");
                }
            }
            Console.WriteLine();

            //8.Write a LINQ query to display products group by product Mrp.
            var grpByMrp = products.GroupBy(p => p.ProMrp);
            Console.WriteLine("Products grouped by MRP");
            Console.WriteLine("--------------------------");
            foreach (var item1 in grpByMrp)
            {
                Console.WriteLine($"MRP : {item1.Key}");
                Console.WriteLine("--------------------");
                foreach (var item in item1)
                {
                    Console.WriteLine($"{item.ProCategory}\t{item.ProName}\t{item.ProMrp}");
                }
            }
            Console.WriteLine();

            //9.Write a LINQ query to display product detail with highest price in FMCG category.
            var maxPrice = products.Where(p => p.ProCategory == "FMCG").Max(p => p.ProMrp);
            //Console.WriteLine("MAx PRICE: "+maxPrice);
            var result = products.Where(p => p.ProCategory == "FMCG" && p.ProMrp == maxPrice);
            Console.WriteLine(" product detail with highest price in FMCG category");
            Console.WriteLine("=====================================================");

            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}\t{item.ProMrp}");
            }
            Console.WriteLine();

            //10.Write a LINQ query to display count of total products.
             DisplayValue("Total Products : ",products.Count());
           
            //11.Write a LINQ query to display count of total products with category FMCG.

            var cnt = products.Count(p => p.ProCategory == "FMCG");
            Console.WriteLine("display count of total products with category FMCG.");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("total products with category FMCG is : " + cnt);
            Console.WriteLine();

            //12.Write a LINQ query to display Max price.

            DisplayValue("Max Price ", products.Max(p => p.ProMrp ));

       
            //13.Write a LINQ query to display Min price.
           
            DisplayValue("Min Price ", products.Min(p => p.ProMrp));

        
            //14.Write a LINQ query to display whether all products are below Mrp Rs.30 or not.
            
            DisplayValue("All below 30?", products.All(p => p.ProMrp < 30));

            //15.Write a LINQ query to display whether any products are below Mrp Rs.30 or not.

            DisplayValue("Any below 30?", products.Any(p => p.ProMrp < 30));

            Console.ReadLine();

        }
    }
}
