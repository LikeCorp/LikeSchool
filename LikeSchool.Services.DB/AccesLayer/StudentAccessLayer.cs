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

        public List<IAdmissionModal> GetAdmissionIds(string procedureName)
        {
            OpenConnection();
            List<IAdmissionModal> result = DbConnection.Query<AdmissionModal>(procedureName,
           commandType: System.Data.CommandType.StoredProcedure).ToList<IAdmissionModal>();
            CloseConnection();
            return result;
        }
        public List<IStudentTableModal> GetStudentByAdmissionId(string procedureName, IAdmissionModal adModal)
        {
            DynamicParameters par = new DynamicParameters();
            par.Add(Constants.AdmissionNo, adModal.AdmissionNo);
            return GetStudents(procedureName, par);
        }

        public List<IStudentTableModal> GetStudentByClass(string procedureName, IClassTableModal classModal)
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
            studentModal.ContactModal = GetContactDetails("select C.*,M.username as LastModifiedBy,C.lastmodifiedtime,L.username as CreatedBy,C.createdtime  from dbo.communicationtable C inner join logintable M on C.lastmodifiedid=M.id inner join logintable L on C.createdid=L.id where fk_admissionno=@admissionno", par);
            studentModal.OtherModal = GetOtherDetails("select C.dob as DateOfBirth,C.bg as BloodGroup,C.gender,C.nationality,C.language,C.category,C.religion,M.username as LastModifiedBy,C.lastmodifiedtime,L.username as CreatedBy,C.createdtime from dbo.othertable C inner join logintable M on C.lastmodifiedid=M.id inner join logintable L on C.createdid=L.id where fk_admissionno=@admissionno", par);
            studentModal.ParentModal = GetParentDetails("select firstname,middlename,lastname,relation,dob as DateOfBirth,education,occupation,income,offaddress1 as address1,offaddress2 as address2,city,state,country,pincode,offphone1 as phone1,offphone2 as phone2,mobile,M.username as LastModifiedBy,C.lastmodifiedtime,L.username as CreatedBy,C.createdtime from dbo.parenttable C inner join logintable M on C.lastmodifiedid=M.id inner join logintable L on C.createdid=L.id where fk_admissionno=@admissionno", par);
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
            catch(Exception err)
            {
                return null;
            }
        }

        internal IContactModal GetContactDetails(string sql,DynamicParameters parameters)
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

        internal List<T> GetQuery<T>(string sql, DynamicParameters parameters)
        {
            OpenConnection();
            var query = DbConnection.Query<T>(sql, parameters);
            List<T> result = query.ToList<T>();
            CloseConnection();
            return result;
        }

        internal List<IStudentTableModal> GetStudents(string procedureName, DynamicParameters parameters)
        {
            OpenConnection();

            var studs = DbConnection.Query<StudentTableModal, ClassTableModal, BatchTableModal,UpdaterDetailTableModal, StudentTableModal>(
           procedureName, (student, classm, batchm,updatem) =>
           {
               student.ClassModal = classm;
               student.BatchModal = batchm;
               student.UpdateModal = updatem;
               return student;
           }, parameters, splitOn: "classid,batchid,LastModifiedBy", commandType: CommandType.StoredProcedure);

            List<IStudentTableModal> result = studs.ToList<IStudentTableModal>();
            CloseConnection();
            return result;
        }

    }
}