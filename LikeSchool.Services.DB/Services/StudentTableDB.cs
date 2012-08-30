using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using LikeSchool.Services.DB.Modals;

using System.Web.Script.Services;
using System.Text;
using LikeSchool.Services.DB.AccesLayer;

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
    public class StudentTableDB : System.Web.Services.WebService
    {
        [WebMethod]
        public string SelectClassTable()
        {
            StringBuilder outString = new StringBuilder();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ClassAccessLayer al = new ClassAccessLayer();
            List<IClassTableModal> output = al.SelectClass(Constants.SP_SelectClassTable);
            serializer.Serialize(output, outString);
            return outString.ToString();
        }
        [WebMethod]
        public string SelectAdmissionNoTable()
        {
            StringBuilder outString = new StringBuilder();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            StudentAccessLayer al = new StudentAccessLayer();
            List<IAdmissionModal> output = al.SelectAdmissionNo(Constants.SP_SelectAdmissionNo);
            serializer.Serialize(output, outString);
            return outString.ToString();
        }

        [WebMethod]
        public string SearchByAdmission(string jsonValue)
        {
            StringBuilder outString = new StringBuilder();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            IAdmissionModal modal = serializer.Deserialize<AdmissionModal>(jsonValue);
            StudentAccessLayer al = new StudentAccessLayer();
            List<IStudentTableModal> output = al.SelectStudentByAdmissionNo(Constants.SP_SearchByAdNo, modal);
            serializer.Serialize(output, outString);
            return outString.ToString();
        }

        [WebMethod]
        public string SearchByClass(string jsonValue)
        {
            StringBuilder outString = new StringBuilder();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            IClassTableModal modal = serializer.Deserialize<ClassTableModal>(jsonValue);
            ClassAccessLayer al = new ClassAccessLayer(modal);
            IClassTableModal resultModal = al.SelectClassById(Constants.SP_SelectClassId);
            StudentAccessLayer sl=new StudentAccessLayer();
            List<IStudentTableModal> ouput = sl.SelectStudentByClass(Constants.SP_SearchByClass, resultModal);
            serializer.Serialize(ouput, outString);
            return outString.ToString();
        }
    }
}
