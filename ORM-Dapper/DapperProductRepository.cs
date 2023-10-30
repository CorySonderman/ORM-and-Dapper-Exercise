using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public void DeleteProduct(int id)
        {
          _conn.Execute("Delete FROM sales WHERE ProductID = @id;", new { id = id});
          _conn.Execute("Delete FROM reviews WHERE ProductID = @id;", new { id = id});
          _conn.Execute("Delete FROM products WHERE ProductID = @id;", new { id = id});

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id;",
               new { id });
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products" +
                " SET Name = @name," +
                " Price = @price," +
                " CategoryID = @catID," +
                " Onsale = @onSale," +
                " StockLevel = @stock" +
                " WHERE ProductID = @id;",
                new
                {
                    id = product.ProductID,
                    name = product.Name,
                    price = product.Price,
                    catID = product.CategoryID,
                    onSale = product.OnSale,
                    stock = product.StockLevel
                });


        }
    }
}
