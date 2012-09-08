using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using LikeSchool.Modals;

using System.Web.Script.Services;
using System.Text;
using LikeSchool.Services.DB.AccesLayer;
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
    public class EventTableDB : System.Web.Services.WebService
    {
        [WebMethod]
        public string InsertEventTable(string jsonValue, string loginValues)
        {
            StringBuilder outString = new StringBuilder();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            EventTableModal modal = serializer.Deserialize<EventTableModal>(jsonValue);
            ILoginTableModal lTable = serializer.Deserialize<LoginTableModal>(loginValues);
            modal.UpdateModal.CreatedById = modal.UpdateModal.LastModifiedId= lTable.Id;
            modal.UpdateModal.CreatedTime = modal.UpdateModal.LastModifiedTime= DateTime.Now;
            EventAccessLayer al = new EventAccessLayer(modal);
            int output = al.InsertEvents(Constants.SP_InsertEventTable);
            serializer.Serialize(output, outString);
            return outString.ToString();
        }

        [WebMethod]
        public string SelectEventTable()
        {
            StringBuilder outString=new StringBuilder();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            EventAccessLayer al = new EventAccessLayer();
            List<EventTableModal> output = al.SelectEvents(Constants.SP_SelectEventTable);
            serializer.Serialize(output, outString);
            return outString.ToString();
        }
        [WebMethod]
        public string DeleteEventTable(string jsonValue)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            IEventTableModal modal = serializer.Deserialize<EventTableModal>(jsonValue);
            EventAccessLayer al = new EventAccessLayer(modal);
            bool result=al.DeleteEvent(Constants.SP_DeleteEventTable);
            return result.ToString();
        }
    }
}
