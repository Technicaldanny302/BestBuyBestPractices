using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly System.Data.IDbConnection _conn;

        public DapperProductRepository(System.Data.IDbConnection connection)
        {
            _conn = connection;
        }

        public void CreateProduct(string name, double price, int CategoryID)
        {
            _conn.Execute("INSERT INTO products (name, Price, CategoryID) VALUES (@name, @price, @categoryID)",
              new {name = name, price = price, CategoryID = CategoryID});
        }

       
        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
        }

    }
}
