using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;

namespace LikeSchool.Services.DB.Modals
{
    public class LoginTableModal : ILoginTableModal
    {
        public string UserName
        {
            get;
            set;
        }
        public string Password { get; set; }
        public string Roles { get; set; }
        public int Id { get; set; }
        
    }
}