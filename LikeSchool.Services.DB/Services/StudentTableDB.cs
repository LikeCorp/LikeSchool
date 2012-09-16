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
    public class StudentTableDB : System.Web.Services.WebService
    {
        [WebMethod]
        public string SelectClassTable()
        {
            ClassAccessLayer al = new ClassAccessLayer();
            ClassCollection output = al.SelectClass(Constants.SP_SelectClassTable);
            return Serializer.GetSerialized<ClassCollection>(output);
        }
        [WebMethod]
        public string SelectAdmissionNoTable()
        {
            StudentAccessLayer al = new StudentAccessLayer();
            AdmissionCollection output = al.GetAdmissionIds(Constants.SP_SelectAdmissionNo);
            return Serializer.GetSerialized<AdmissionCollection>(output);
        }

        [WebMethod]
        public IStudentTableModal SelectStudentData(int admissionno, int batchId)
        {
            StudentAccessLayer al = new StudentAccessLayer();
            IStudentTableModal output = al.GetStudentData(Constants.SP_SelectStudentDetail,admissionno,batchId);
            return output;    
            
        }

    }
}
