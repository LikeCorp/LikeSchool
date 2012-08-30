using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using LikeSchool.Services.DB.Modals;

namespace LikeSchool.Services.DB.AccesLayer
{
    public class StudentAccessLayer : Connection
    {
        IStudentTableModal modal;
        public StudentAccessLayer()
        {

        }
        public StudentAccessLayer(IStudentTableModal mod)
        {
            modal = mod;
        }

        public List<IAdmissionModal> SelectAdmissionNo(string procedureName)
        {
            OpenConnection();
            List<IAdmissionModal> result = DbConnection.Query<AdmissionModal>(procedureName,
           commandType: System.Data.CommandType.StoredProcedure).ToList<IAdmissionModal>();
            CloseConnection();
            return result;
        }
        public List<IStudentTableModal> SelectStudentByAdmissionNo(string procedureName, IAdmissionModal adModal)
        {
            OpenConnection();
            var dynamic = new DynamicParameters();
            dynamic.Add(Constants.AdmissionNo, adModal.AdmissionNo);
            List<IStudentTableModal> result = DbConnection.Query<StudentTableModal>(procedureName, dynamic,
           commandType: System.Data.CommandType.StoredProcedure).ToList<IStudentTableModal>();
            CloseConnection();
            return result;
        }

        public List<IStudentTableModal> SelectStudentByClass(string procedureName, IClassTableModal classModal)
        {
            OpenConnection();
            var dynamic = new DynamicParameters();
            dynamic.Add(Constants.ClassId, classModal.ClassId);
            List<IStudentTableModal> result = DbConnection.Query<StudentTableModal>(procedureName, dynamic,
                commandType: System.Data.CommandType.StoredProcedure).ToList<IStudentTableModal>();
            CloseConnection();
            return result;
        }
    }
}