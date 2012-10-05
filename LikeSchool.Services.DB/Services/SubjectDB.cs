using LikeSchool.Helpers;
using LikeSchool.Modals;
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
    public class SubjectDB : System.Web.Services.WebService, IDB
    {
        [WebMethod]
        public string InsertDB(string jsonValue)
        {
            throw new NotImplementedException();
        }
        [WebMethod]
        public string DeleteAll()
        {
            throw new NotImplementedException();
        }
        [WebMethod]
        public string DeleteDBOnCondition(string jsonValue)
        {
            throw new NotImplementedException();
        }
        [WebMethod]
        public string UpdateDBOnCondition(string jsonValue)
        {
            throw new NotImplementedException();
        }
        [WebMethod]
        public string SelectDB()
        {
            SubjectAccessLayer accesslayer = new SubjectAccessLayer();
            SubjectCollection collection = accesslayer.SelectAll(Constants.SP_SelectSubject);
            return Serializer.GetSerialized<SubjectCollection>(collection);
        }
        [WebMethod]
        public SubjectCollection SelectDBWithoutSerialization()
        {
            SubjectAccessLayer accesslayer = new SubjectAccessLayer();
            SubjectCollection collection = accesslayer.SelectAll(Constants.SP_SelectSubject);
            return collection;
        }
        [WebMethod]
        public string SelectDBOnCondition(string jsonValue)
        {
            throw new NotImplementedException();
        }

        [WebMethod]
        public string InsertDBWithLogin(string jsonValue, string loginValues)
        {
            SubjectModal subjectModal = Serializer.GetDeserialized<SubjectModal>(jsonValue);            
            ILoginTableModal loginTable = Serializer.GetDeserialized<LoginTableModal>(loginValues);
            IUpdaterDetailTableModal upModal = new UpdaterDetailTableModal();
            upModal.CreatedById = upModal.LastModifiedId = loginTable.Id;
            upModal.CreatedTime = upModal.LastModifiedTime = DateTime.Now;
            subjectModal.UpdateModal = upModal;
            SubjectAccessLayer subLayer = new SubjectAccessLayer(subjectModal);
            bool check = subLayer.InsertDB(Constants.SP_InsertSubject);
            return Serializer.GetSerialized<bool>(check);
        }
    }
}