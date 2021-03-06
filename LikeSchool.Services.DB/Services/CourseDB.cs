﻿using LikeSchool.Helpers;
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
    public class CourseDB : System.Web.Services.WebService, IDB
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
            CourseAccessLayer courseLayer = new CourseAccessLayer();
            CourseCollection collection = courseLayer.SelectAll(Constants.SP_SelectCourse);
            return Serializer.GetSerialized<CourseCollection>(collection);
        }
        [WebMethod]
        public CourseCollection SelectDBWithoutSerialization()
        {
            CourseAccessLayer courseLayer = new CourseAccessLayer();
            CourseCollection collection = courseLayer.SelectAll(Constants.SP_SelectCourse);
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
            CourseModal courseModal = Serializer.GetDeserialized<CourseModal>(jsonValue);
            ILoginTableModal loginTable = Serializer.GetDeserialized<LoginTableModal>(loginValues);
            IUpdaterDetailTableModal updateModal = new UpdaterDetailTableModal();
            updateModal.CreatedById = updateModal.LastModifiedId = loginTable.Id;
            updateModal.CreatedTime = updateModal.LastModifiedTime = DateTime.Now;
            courseModal.UpdateModal = updateModal;
            CourseAccessLayer courseLayer = new CourseAccessLayer(courseModal);
            bool check = courseLayer.InsertDB(Constants.SP_InsertCourse);
            return Serializer.GetSerialized<bool>(check);
        }
    }
}