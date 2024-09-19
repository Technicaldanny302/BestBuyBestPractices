using BestBuyBestPractices;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;
using System.IO;

namespace BestBuyBestPractices
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            var departmentRepo = new DapperDepartmentRepository(conn);

            departmentRepo.InsertDepartments("Johns New Department");

            var departments = departmentRepo.GetAllDepartments();
             
            foreach (var department in departments)
            {
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);
                Console.WriteLine();
                Console.WriteLine();
            }

            var repo = new DapperProductRepository(conn);
          
          
            var products = repo.GetAllProducts();

            foreach (var prod in products)
            {
                Console.WriteLine($" {prod.ProductID} {prod.Name}");
            }
                
        }
    }
}
