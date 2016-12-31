using Dapper;
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
    public class ProductRepository
    {
        private readonly IDbConnection conn;

        public ProductRepository()
        {
            this.conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Northwind"].ToString());
        }
        public IEnumerable<Product> GetAll()
        {
            ConnectionOpen();
            return this.conn.Query<Product>("GetProducts", commandType: CommandType.StoredProcedure);
        }

        private void ConnectionOpen()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
        }
    }
}
