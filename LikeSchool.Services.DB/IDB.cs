using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services;

namespace LikeSchool.Services.DB
{
    public interface IDB
    {
        [WebMethod]
        string InsertDB(string jsonValue);
        [WebMethod]
        string DeleteAll();
        [WebMethod]
        string DeleteDBOnCondition(string jsonValue);
        [WebMethod]
        string UpdateDBOnCondition(string jsonValue);
        [WebMethod]
        string SelectDB();
        [WebMethod]
        string SelectDBOnCondition(string jsonValue);


    }
}
