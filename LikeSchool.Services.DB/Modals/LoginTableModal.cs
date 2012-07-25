using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;


namespace LikeSchool.Services.DB.Modals
{
    public class LoginTableModal : Connection
    {
        public string UserName
        {
            get;
            set;
        }
        public string Password { get; set; }
        public string Roles { get; set; }
        public int Id { get; set; }
        
        public LoginTableModal GetLogin(string procedureName, string user, string pass)
        {
            OpenConnection();
            var dynamic = new DynamicParameters();
            dynamic.Add(Constants.User, user);
            dynamic.Add(Constants.Pass, pass);
            LoginTableModal result = DbConnection.Query<LoginTableModal>(procedureName, dynamic,
            commandType: CommandType.StoredProcedure).FirstOrDefault<LoginTableModal>();
            CloseConnection();
            return result;
        }
    }
}