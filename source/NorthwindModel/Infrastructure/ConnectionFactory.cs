using NorthwindModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace NorthwindModel.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory, IDisposable
    {
        private IDbConnection conn;

        public IDbConnection Get()
        {
            if (this.conn == null)
            {
                this.conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Northwind"].ToString());
            }

            if (this.conn.State == ConnectionState.Closed) this.conn.Open();

            return this.conn;
        }

        public void Dispose()
        {
            this.conn.Close();
        }
    }
}
