using Dapper;
using NorthwindModel.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindModel.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection conn;

        public ProductRepository()
        {
            this.conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Northwind"].ToString());
        }

        public void Add(Product product)
        {
            ConnectionOpen();
            this.conn.Execute(
                "AddProducts",
                param:
                new
                {
                    ProductName = product.ProductName,
                    SupplierID = product.SupplierID,
                    CategoryID = product.CategoryID,
                    QuantityPerUnit = product.QuantityPerUnit,
                    UnitPrice = product.UnitPrice,
                    UnitsInStock = product.UnitsInStock,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    Discontinued = false
                },
                commandType: CommandType.StoredProcedure);
        }

        public Product FindByName(string productName)
        {
            return GetAll().Where(p => p.ProductName == productName).FirstOrDefault();
        }

        public IEnumerable<Product> GetAll()
        {
            ConnectionOpen();
            return this.conn.Query<Product>("GetProducts", commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Category> GetAllCategory()
        {
            ConnectionOpen();
            return this.conn.Query<Category>("GetCategories", commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Supplier> GetAllSupplier()
        {
            ConnectionOpen();
            return this.conn.Query<Supplier>("GetSuppliers", commandType: CommandType.StoredProcedure);
        }

        public void Update(Product product)
        {
            ConnectionOpen();
            this.conn.Execute(
                "UpdateProducts",
                param: product,
                commandType: CommandType.StoredProcedure);
        }

        private void ConnectionOpen()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
        }
    }
}
