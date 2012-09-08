using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using LikeSchool.Services.DB.AccesLayer;
using LikeSchool.Modals;
using LikeSchool.Helpers;

namespace LikeSchool.Services.DB.Services
{
    /// <summary>
    /// Summary description for EventTableDB
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LoginDB : System.Web.Services.WebService
    {
        [WebMethod]
        public static string SelectLoginTable(ILoginTableModal modal)
        {
            StringBuilder outString = new StringBuilder();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            LoginAccessLayer al = new LoginAccessLayer(modal);
            ILoginTableModal output = al.GetLogin(Constants.SP_SelectLoginTable);
            serializer.Serialize(output, outString);
            return outString.ToString();
        }
        [WebMethod]
        public static string UpdateLoginTable(ILoginTableModal modal)
        {
            LoginAccessLayer al = new LoginAccessLayer(modal);
            bool result = al.UpdateLoginTime();
            return result.ToString();
        }
        
    }
}