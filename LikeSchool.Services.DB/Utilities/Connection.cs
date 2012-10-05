using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using LikeSchool.Helpers;
using Dapper;
using LikeSchool.Modals;
using System.Reflection;

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
        public T GetQueryied<T,TModal>(string sql)
        {
            return GetQueryied<T,TModal>(sql, CommandType.StoredProcedure);
        }
        public T GetQueryied<T,TModal>(string sql, DynamicParameters parameters)
        {
            return GetQueryied<T,TModal>(sql, parameters, CommandType.StoredProcedure);
        }
        public T GetQueryied<T, TModal>(string sql, CommandType cmdType)
        {
            return GetQueryied<T, TModal>(sql,new DynamicParameters(), cmdType);
        }
        public T GetQueryied<T, TModal>(string sql, DynamicParameters parameters, CommandType cmdType)
        {
            OpenConnection();
            var query = DbConnection.Query<TModal>(sql, parameters, commandType: cmdType);
            T result = GetTypeCastedCollection<T, TModal>(query as List<TModal>);
            CloseConnection();
            return result;
        }
        public T GetQueryiedFirst<T>(string sql, DynamicParameters parameters)
        {
            return GetQueryiedFirst<T>(sql, parameters, CommandType.StoredProcedure);
        }
        
        public T GetQueryiedFirst<T>(string sql, DynamicParameters parameters, CommandType cmdType)
        {
            OpenConnection();
            var query = DbConnection.Query<T>(sql, parameters, commandType: cmdType);
            T result = query.FirstOrDefault<T>();
            CloseConnection();
            return result;
        }

        public T GetTypeCastedCollection<T,TModal>(List<TModal> value)
        {
            T x = (T)Activator.CreateInstance(typeof(T));
            foreach(TModal modal in value)
            {
               MethodInfo method= x.GetType().GetMethod("Add");             
               method.Invoke(x as object,new object[]{modal});
            }
            return x;
        }
    }
}