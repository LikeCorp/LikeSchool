using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace LikeSchool.Services.DB.Services
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class CourseDB : System.Web.Services.WebService,IDB
    {
        public string InsertDB(string jsonValue)
        {
            throw new NotImplementedException();
        }

        public string DeleteAll()
        {
            throw new NotImplementedException();
        }

        public string DeleteDBOnCondition(string jsonValue)
        {
            throw new NotImplementedException();
        }

        public string UpdateDBOnCondition(string jsonValue)
        {
            throw new NotImplementedException();
        }

        public string SelectDB()
        {
            throw new NotImplementedException();
        }

        public string SelectDBOnCondition(string jsonValue)
        {
            throw new NotImplementedException();
        }
    }
}