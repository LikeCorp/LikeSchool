using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LikeSchool.Services.DB
{
    public abstract class Connection
    {
       private IDbConnection connection;
       public virtual void OpenConnection()
        {
            if (DbConnection.State == ConnectionState.Closed)
            {
                DbConnection.Open();
            }
        }
       public virtual void CloseConnection()
        {
            if (connection != null)
                DbConnection.Close();
        }

        public IDbConnection DbConnection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.LikeConnectionString].ConnectionString);
                }
                return connection;
            }
        }
    }
}