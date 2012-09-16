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
using System.Threading;

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
            EventTableModal modal = Serializer.GetDeserialized<EventTableModal>(jsonValue);
            ILoginTableModal lTable = Serializer.GetDeserialized<LoginTableModal>(loginValues);
            modal.UpdateModal.CreatedById = modal.UpdateModal.LastModifiedId= lTable.Id;
            modal.UpdateModal.CreatedTime = modal.UpdateModal.LastModifiedTime= DateTime.Now;
            EventAccessLayer al = new EventAccessLayer(modal);
            int output = al.InsertEvents(Constants.SP_InsertEventTable);
            return Serializer.GetSerialized<int>(output);
        }

        [WebMethod]
        public string SelectEventTable()
        {
            EventAccessLayer al = new EventAccessLayer();
            EventCollection output = al.SelectEvents(Constants.SP_SelectEventTable);
            return Serializer.GetSerialized<EventCollection>(output);
        }
        [WebMethod]
        public string DeleteEventTable(string jsonValue)
        {
            IEventTableModal modal = Serializer.GetDeserialized<EventTableModal>(jsonValue);
            EventAccessLayer al = new EventAccessLayer(modal);
            bool result=al.DeleteEvent(Constants.SP_DeleteEventTable);
            return result.ToString();
        }
        [WebMethod]
        public string SelectEventTableWithConstrain(string jsonValue)
        {
            IEventTableModal eventtable = Serializer.GetDeserialized<EventTableModal>(jsonValue);
            EventAccessLayer al = new EventAccessLayer(eventtable);
            EventCollection result = al.SelectEventsWithConstrain(Constants.SP_SelectEventsConstrain);
            return Serializer.GetSerialized<EventCollection>(result);
        }
    }
}
