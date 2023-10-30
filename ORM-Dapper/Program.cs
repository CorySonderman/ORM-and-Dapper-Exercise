using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Data;
using ORM_Dapper;


var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var productRepository = new DapperProductRepository(conn);

//var productToUpdate = productRepository.GetProduct(941);
//productToUpdate.Name = "Updated";
//productToUpdate.Price = 5.99;
//productToUpdate.CategoryID = 1;
//productToUpdate.StockLevel = 5;
//productToUpdate.OnSale = false;
//productRepository.UpdateProduct(productToUpdate);
//productRepository.DeleteProduct(941);

var products = productRepository.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine(product.ProductID);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.CategoryID);
    Console.WriteLine(product.OnSale);
    Console.WriteLine(product.StockLevel);
    Console.WriteLine();
}

//var departmentRepo = new DapperDepartmentRepository(conn);

//var departments = departmentRepo.GetAllDepartments();

//foreach (var department in departments)
//{
//    Console.WriteLine(department.DepartmentID);
//    Console.WriteLine(department.Name);
//    Console.WriteLine();
//}


