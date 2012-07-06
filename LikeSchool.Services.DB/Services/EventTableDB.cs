using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using LikeSchool.Services.DB.Modals;
using LikeSchool.Services.DB.Insert;
using System.Web.Script.Services;

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
    public class EventTableDB : System.Web.Services.WebService
    {
        [WebMethod]
        public string InsertEventTable(string jsonValue)
        {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                EventTableModal modal = serializer.Deserialize<EventTableModal>(jsonValue);
                List<Procedure> outs=modal.ExecuteProcedure(Constants.SP_InsertEventTable,modal.GetInsertProcedureList());
                return outs[0].OutValue.ToString();            
        }
        [WebMethod]
        public string SelectEventTable(string jsonValue)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            EventTableModal modal = serializer.Deserialize<EventTableModal>(jsonValue);
            List<Procedure> outs = modal.ExecuteProcedure(Constants.SP_SelectEventTable, modal.GetSelectProcedureList());
            return serializer.Serialize(outs);
        }
       
    }
}
