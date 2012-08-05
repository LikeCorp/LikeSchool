using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using LikeSchool.Services.DB.Modals;

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
        public static string SelectLoginTable(LoginTableModal modal)
        {
            StringBuilder outString = new StringBuilder();
            JavaScriptSerializer serializer = new JavaScriptSerializer();            
            LoginTableModal output = modal.GetLogin(Constants.SP_SelectLoginTable, modal.UserName, modal.Password);
            serializer.Serialize(output, outString);
            return outString.ToString();
        }
    }
}