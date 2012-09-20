using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using LikeSchool.Helpers;
using LikeSchool.Modals;

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

        public AdmissionCollection GetAdmissionIds(string procedureName)
        {
            return GetQueryied<AdmissionCollection,AdmissionModal>(procedureName);
        }
        public StudentCollection GetStudentByAdmissionId(string procedureName, IAdmissionModal adModal)
        {
            DynamicParameters par = new DynamicParameters();
            par.Add(Constants.AdmissionNo, adModal.AdmissionNo);
            return GetStudents(procedureName, par);
        }

        public StudentCollection GetStudentByClass(string procedureName, IClassTableModal classModal)
        {
            DynamicParameters par = new DynamicParameters();
            par.Add(Constants.ClassId, classModal.ClassId);
            return GetStudents(procedureName, par);
        }

        public IStudentTableModal GetStudentData(string procedureName, int admissionNo, int batchId)
        {
            DynamicParameters par = new DynamicParameters();
            par.Add(Constants.AdmissionNo, admissionNo);
            par.Add(Constants.BatchId, batchId);
            IStudentTableModal studentModal = GetStudents(procedureName, par).First<IStudentTableModal>();
            par = new DynamicParameters();
            par.Add(Constants.AdmissionNo, admissionNo);
            studentModal.ContactModal = GetContactDetails(Constants.Query_Contact, par);
            studentModal.OtherModal = GetOtherDetails(Constants.Query_Other, par);
            studentModal.ParentModal = GetParentDetails(Constants.Query_Parent, par);
            return studentModal;
        }

        internal IParentModal GetParentDetails(string sql, DynamicParameters parameters)
        {
            try
            {
                OpenConnection();
                var parentdetail = DbConnection.Query<ParentModal, ContactModal, ParentModal>(sql, (parent, contact) =>
                {
                    parent.ContactModal = contact;
                    return parent;
                }, parameters, splitOn: "address1");

                IParentModal result = parentdetail.FirstOrDefault<IParentModal>();
                CloseConnection();
                return result;
            }
            catch (Exception err)
            {
                return null;
            }
        }

        internal IContactModal GetContactDetails(string sql, DynamicParameters parameters)
        {
            try
            {
                OpenConnection();
                var contactdetail = DbConnection.Query<ContactModal, UpdaterDetailTableModal, ContactModal>(sql, (contact, update) =>
                {
                    contact.UpdateModal = update;
                    return contact;
                }, parameters, splitOn: "LastModifiedBy");

                IContactModal result = contactdetail.FirstOrDefault<ContactModal>();
                CloseConnection();
                return result;
            }
            catch (Exception err)
            {
                return null;
            }
        }
        internal IOtherModal GetOtherDetails(string sql, DynamicParameters parameters)
        {
            try
            {
                OpenConnection();
                var contactdetail = DbConnection.Query<OtherModal, UpdaterDetailTableModal, OtherModal>(sql, (other, update) =>
                {
                    other.UpdateModal = update;
                    return other;
                }, parameters, splitOn: "LastModifiedBy");

                IOtherModal result = contactdetail.FirstOrDefault<IOtherModal>();
                CloseConnection();
                return result;
            }       
            catch (Exception err)
            {
                return null;
            }
        }

        

        internal StudentCollection GetStudents(string procedureName, DynamicParameters parameters)
        {
            OpenConnection();

            var studs = DbConnection.Query<StudentTableModal, ClassTableModal, BatchTableModal, UpdaterDetailTableModal, StudentTableModal>(
           procedureName, (student, classm, batchm, updatem) =>
           {
               student.ClassModal = classm;
               student.BatchModal = batchm;
               student.UpdateModal = updatem;
               return student;
           }, parameters, splitOn: "classid,batchid,LastModifiedBy", commandType: CommandType.StoredProcedure);

            StudentCollection result = GetTypeCastedCollection<StudentCollection,StudentTableModal>(studs.ToList<StudentTableModal>());
            CloseConnection();
            return result;
        }

    }
}