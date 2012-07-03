using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace LikeSchool.Services.DB
{
    public class Connection
    {
       private static SqlConnection connection;
        public static void OpenConnection()
        {
            DbConnection.Open();
        }
        public static void CloseConnection()
        {
            if (connection != null)
                DbConnection.Close();
        }

        public static SqlConnection DbConnection
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