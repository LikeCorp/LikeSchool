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
    public class SearchStudentTableDB : System.Web.Services.WebService
    {
        [WebMethod]
        public string SearchByAdmission(string jsonValue)
        {
                IAdmissionModal modal = Serializer.GetDeserialized<AdmissionModal>(jsonValue);
                StudentAccessLayer al = new StudentAccessLayer();
                StudentCollection output = al.GetStudentByAdmissionId(Constants.SP_SearchByAdNo, modal);
                return Serializer.GetSerialized<StudentCollection>(output);            
        }

        [WebMethod]
        public string SearchByClass(string jsonValue)
        {
                IClassTableModal modal = Serializer.GetDeserialized<ClassTableModal>(jsonValue);
                ClassAccessLayer al = new ClassAccessLayer(modal);
                IClassTableModal resultModal = al.SelectClassById(Constants.SP_SelectClassId);
                StudentAccessLayer sl = new StudentAccessLayer();
                StudentCollection ouput = sl.GetStudentByClass(Constants.SP_SearchByClass, resultModal);
                return Serializer.GetSerialized<StudentCollection>(ouput);          
        }
    }
}
