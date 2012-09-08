using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using LikeSchool.Modals;

namespace LikeSchool.Services.DB.AccesLayer
{
    public class LoginAccessLayer : Connection
    {
        ILoginTableModal modal;

        public LoginAccessLayer()
        {

        }

        public LoginAccessLayer(ILoginTableModal loginModal)
        {
            modal = loginModal;
        }

        public ILoginTableModal Modal
        {
            get
            {
                return modal;
            }
            set
            {
                modal = value;
            }
        }

        public ILoginTableModal GetLogin(string procedureName)
        {
            OpenConnection();
            var dynamic = new DynamicParameters();
            dynamic.Add(Constants.User, Modal.UserName);
            dynamic.Add(Constants.Pass, Modal.Password);
            LoginTableModal result = DbConnection.Query<LoginTableModal>(procedureName, dynamic,
            commandType: CommandType.StoredProcedure).FirstOrDefault<LoginTableModal>();
            CloseConnection();
            return result;
        }
        public bool UpdateLoginTime()
        {
            try
            {
                OpenConnection();
                var query = "update logintable set lastlogintime=@logintime where id=@id";
                var dynamic = new DynamicParameters();
                dynamic.Add(Constants.LoginId, Modal.Id);
                dynamic.Add(Constants.LoginTime, Modal.LastLoginTime);
                DbConnection.Query(query, dynamic, commandType: CommandType.Text);
                CloseConnection();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
            
        }
    }
}