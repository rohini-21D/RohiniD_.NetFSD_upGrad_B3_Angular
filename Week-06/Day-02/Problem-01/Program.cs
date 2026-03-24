
using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.IO;

namespace ConsoleApp
{
    //Model

    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            // Build configuration

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            

            //Read ConnectionString From SQL

            string connStr = configuration.GetConnectionString("DefaultConnection");

            while (true)
            {
                Console.WriteLine("\n1.Insert |  2. View | 3. Update | 4.Delete | 5.GetByID | 6.Exit " );
                int Choice=int.Parse(Console.ReadLine());

                try
                {
                    switch (Choice)
                    {
                        case 1:
                            InsertProduct(connStr);
                            break;
                        case 2:
                            ViewProducts(connStr);
                            break;
                        case 3:
                            UpdateProduct(connStr);
                            break;
                        case 4:
                            DeleteProduct(connStr);
                            break;
                        case 5:
                            GetProductById(connStr);
                            break;
                        case 6:
                            return;
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Error : " +ex.Message);
                }
            }
        }

        //  INSERT
        static void InsertProduct(string connStr)
        {
            Console.WriteLine("Enter Product Name : ");
            string prodName = Console.ReadLine();

            Console.WriteLine("Enter Product Category : ");
            string prodCatg = Console.ReadLine();

            Console.WriteLine("Enter Product Price : ");
            decimal prodPrice = decimal.Parse(Console.ReadLine());

            using SqlConnection conn = new SqlConnection(connStr);
            using SqlCommand cmd = new SqlCommand("usp_InsertProduct", conn);
            
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@ProductName";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Size = 100;
            param1.Value = prodName;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@Category";
            param2.SqlDbType = SqlDbType.VarChar;
            param2.Size = 50;
            param2.Value = prodCatg;

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@Price";
            param3.SqlDbType = SqlDbType.Decimal;
            param3.Value = prodPrice;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);

            conn.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Product Inserted");
            
        }

        //  VIEW ALL
        static void ViewProducts(string connStr)
        {
            using SqlConnection conn = new SqlConnection(connStr);
            using SqlCommand cmd = new SqlCommand("usp_GetAllProducts", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["ProductId"]} | {reader["ProductName"]} | {reader["Category"]} | {reader["Price"]}");
            }
          
        }

        // GET BY ID
        static void GetProductById(string connStr)
        {
            Console.Write("Enter Product ID: ");
            int id = int.Parse(Console.ReadLine());

            using SqlConnection conn = new SqlConnection(connStr);
            using SqlCommand cmd = new SqlCommand("usp_GetProductById", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductId", id);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductId"]} | {reader["ProductName"]} | {reader["Category"]} | {reader["Price"]}");
                }
            }
            else
            {
                Console.WriteLine("Product not found");
            }
        }

        //  UPDATE
        static void UpdateProduct(string connStr)
        {
            Console.WriteLine("Enter Product Id to Update : ");
            int updateId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter New Product Name:");
            string newName = Console.ReadLine();

            Console.WriteLine("Enter New Category:");
            string newCategory = Console.ReadLine();

            Console.WriteLine("Enter New Price:");
            decimal newPrice = decimal.Parse(Console.ReadLine());

            using SqlConnection conn = new SqlConnection(connStr);
            using SqlCommand cmd = new SqlCommand("usp_UpdateProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@ProductId";
            p1.SqlDbType = SqlDbType.Int;
            p1.Value = updateId;

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@ProductName";
            p2.SqlDbType = SqlDbType.VarChar;
            p2.Size = 100;
            p2.Value = newName;

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@Category";
            p3.SqlDbType = SqlDbType.VarChar;
            p3.Size = 50;
            p3.Value = newCategory;

            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@Price";
            p4.SqlDbType = SqlDbType.Decimal;
            p4.Value = newPrice;

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);

            conn.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Product Updated ");
        }

        // 🔹 DELETE
        static void DeleteProduct(string connStr)
        {
            Console.WriteLine("Enter Product Id to Delete : ");
            int deleteId = int.Parse(Console.ReadLine());

            using SqlConnection conn = new SqlConnection(connStr);
            using SqlCommand cmd = new SqlCommand("usp_DeleteProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@ProductId";
            p1.SqlDbType = SqlDbType.Int;
            p1.Value = deleteId;

            cmd.Parameters.Add(p1);

            conn.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Product Deleted ");
        }
    }
}
