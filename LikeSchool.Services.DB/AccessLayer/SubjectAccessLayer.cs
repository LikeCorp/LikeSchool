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
    public class SubjectAccessLayer:Connection
    {
        private SubjectModal subjectModal;
        public SubjectAccessLayer()
        {
        
        }
        public SubjectAccessLayer(SubjectModal subModal)
        {
            subjectModal = subModal;
        }

        public SubjectModal SubjectModal
        {
            get
            {
                return subjectModal;
            }
            set
            {
                subjectModal = value;
            }
        }

        public bool InsertDB(string procedureName)
        {
            try
            {
                OpenConnection();
                var dynamic = new DynamicParameters();
                dynamic.Add(Constants.SubjectName, SubjectModal.SubjectName);
                dynamic.Add(Constants.CreatedBy, SubjectModal.UpdateModal.CreatedById);
                dynamic.Add(Constants.CreatedTime, SubjectModal.UpdateModal.CreatedTime);
                dynamic.Add(Constants.LastModifiedBy, SubjectModal.UpdateModal.LastModifiedId);
                dynamic.Add(Constants.LastModifiedTime, SubjectModal.UpdateModal.LastModifiedTime);
                DbConnection.Execute(procedureName, dynamic, null, null, CommandType.StoredProcedure);
                CloseConnection();
            }
            catch(Exception err)
            {
                return false;
            }
            return true;
        }

        public SubjectCollection SelectAll(string procedureName)
        {

            OpenConnection();

            var subs= DbConnection.Query<SubjectModal, UpdaterDetailTableModal, SubjectModal>(
           procedureName, (subject, updatem) =>
           {
               subject.UpdateModal = updatem;
               return subject;
           }, splitOn: "createdby", commandType: CommandType.StoredProcedure);

            SubjectCollection result = GetTypeCastedCollection<SubjectCollection, SubjectModal>(subs.ToList<SubjectModal>());
            CloseConnection();
            return result;
        }

    }
}
