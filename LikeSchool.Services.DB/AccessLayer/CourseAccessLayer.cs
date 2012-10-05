using Dapper;
using LikeSchool.Helpers;
using LikeSchool.Modals;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LikeSchool.Services.DB.Services
{
    public class CourseAccessLayer : Connection
    {
        private CourseModal courseModal;
        public CourseAccessLayer(CourseModal course)
        {
            courseModal = course;

        }
        public CourseAccessLayer()
        {

        }

        public CourseModal Modal
        {
            get
            {
                return courseModal;
            }
            set
            {
                courseModal = value;
            }
        }

        public bool InsertDB(string procedureName)
        {
            try
            {
                OpenConnection();
                var dynamic = new DynamicParameters();
                dynamic.Add(Constants.CourseName, Modal.CourseName);
                dynamic.Add(Constants.NoOfStudents, Modal.NoOfStudents);
                dynamic.Add(Constants.SubjectIds, Modal.SubjectIds);
                dynamic.Add(Constants.CreatedBy, Modal.UpdateModal.CreatedById);
                dynamic.Add(Constants.CreatedTime, Modal.UpdateModal.CreatedTime);
                dynamic.Add(Constants.LastModifiedBy, Modal.UpdateModal.LastModifiedId);
                dynamic.Add(Constants.LastModifiedTime, Modal.UpdateModal.LastModifiedTime);

                DbConnection.Execute(procedureName, dynamic, null, null, CommandType.StoredProcedure);
                CloseConnection();
            }
            catch (Exception err)
            {
                return false;
            }
            return true;
        }

        public CourseCollection SelectAll(string procedureName)
        {
            OpenConnection();

            var courses = DbConnection.Query<CourseModal, UpdaterDetailTableModal, CourseModal>(
           procedureName, (course, updatem) =>
           {
               course.UpdateModal = updatem;
               return course;
           }, splitOn: "createdby", commandType: CommandType.StoredProcedure);

            CourseCollection result = GetTypeCastedCollection<CourseCollection, CourseModal>(courses.ToList<CourseModal>());
            CloseConnection();
            return result;

        }
    }
}
