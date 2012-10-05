using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services;

namespace LikeSchool.Services.DB
{
    public interface IDB
    {
        string InsertDB(string jsonValue);
        string InsertDBWithLogin(string jsonValue, string loginValues);
       
        string DeleteAll();
       
        string DeleteDBOnCondition(string jsonValue);
       
        string UpdateDBOnCondition(string jsonValue);
       
        string SelectDB();
       
        string SelectDBOnCondition(string jsonValue);


    }
}
