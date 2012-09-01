using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
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
            studentModal.ContactModal = GetQuery<ContactModal>("select * from dbo.communicationtable where fk_admissionno=@admissionno", par).FirstOrDefault<IContactModal>();
            studentModal.OtherModal = GetQuery<OtherModal>("select dob as DateOfBirth,bg as BloodGroup,gender,nationality,language,category,religion from dbo.othertable where fk_admissionno=@admissionno", par).FirstOrDefault<IOtherModal>();
            studentModal.ParentModal = GetParentDetails("select firstname,middlename,lastname,relation,dob as DateOfBirth,education,occupation,income,offaddress1 as address1,offaddress2 as address2,city,state,country,pincode,offphone1 as phone1,offphone2 as phone2,mobile from dbo.parenttable where fk_admissionno=@admissionno", par).FirstOrDefault<IParentModal>();
            return studentModal;
        }

        internal List<IParentModal> GetParentDetails(string sql, DynamicParameters parameters)
        {
            try
            {
                OpenConnection();
                var parentdetail = DbConnection.Query<ParentModal, ContactModal, ParentModal>(sql, (parent, contact) =>
                {
                    parent.ContactModal = contact;
                    return parent;
                }, parameters, splitOn: "address1");

                List<IParentModal> result = parentdetail.ToList<IParentModal>();
                CloseConnection();
                return result;
            }
            catch(Exception err)
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

            var studs = DbConnection.Query<StudentTableModal, ClassTableModal, BatchTableModal, StudentTableModal>(
           procedureName, (student, classm, batchm) =>
           {
               student.ClassModal = classm;
               student.BatchModal = batchm;
               return student;
           }, parameters, splitOn: "classid,batchid", commandType: CommandType.StoredProcedure);

            List<IStudentTableModal> result = studs.ToList<IStudentTableModal>();
            CloseConnection();
            return result;
        }

    }
}