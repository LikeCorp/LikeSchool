using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LikeSchool.Helpers
{
    public sealed class Constants
    {
        public const string TitlePrefix = "LikeSchool-{0}";
        public const string DashBoard = "DashBoard";
        public const string Attendance = "Attendance";
        public const string TimeTable = "TimeTable";
        public const string Profile = "Profile";
        public const string Leave = "Leave";
        public const string Settings = "Settings";
        public const string Calendar = "Calendar";
        public const string Defaulter = "-";

        public const string Teacher = "teacher";
        public const string ClassTeacher = "classteacher";
        public const string Student = "student";
        public const string Administrator = "admin";

        public const string SessionLoginName = "logindetails";


        #region LikeSchool.Services.DB
        public const string ErrorString = "error";
        public const string SuccessString = "success";

        /*Stored procedures need to be appended with SP_[storedprocedure name]*/
        public const string SP_InsertEventTable = "InsertEventTable";
        public const string SP_SelectEventTable = "SelectEventTable";
        public const string SP_SelectLoginTable = "SelectLoginTable";
        public const string SP_SelectClassTable = "SelectClassTable";
        public const string SP_SelectAdmissionNo = "SelectAdmissionNo";
        public const string SP_SearchByAdNo = "SearchByAdNo";
        public const string SP_SelectClassId = "SelectClassId";
        public const string SP_SearchByClass = "SearchByClass";
        public const string SP_SelectStudentDetail = "SelectStudentDetail";
        public const string SP_DeleteEventTable = "DeleteEventTable";
        public const string SP_SelectEventsConstrain = "SelectEventsConstrain";
        public const string LikeConnectionString = "likeconnectionstring";

        public const string Query_Contact = "select C.*,M.username as LastModifiedBy,C.lastmodifiedtime,L.username as CreatedBy,C.createdtime  from dbo.communicationtable C inner join logintable M on C.lastmodifiedid=M.id inner join logintable L on C.createdid=L.id where fk_admissionno=@admissionno";
        public const string Query_Other = "select C.dob as DateOfBirth,C.bg as BloodGroup,C.gender,C.nationality,C.language,C.category,C.religion,M.username as LastModifiedBy,C.lastmodifiedtime,L.username as CreatedBy,C.createdtime from dbo.othertable C inner join logintable M on C.lastmodifiedid=M.id inner join logintable L on C.createdid=L.id where fk_admissionno=@admissionno";
        public const string Query_Parent = "select firstname,middlename,lastname,relation,dob as DateOfBirth,education,occupation,income,offaddress1 as address1,offaddress2 as address2,city,state,country,pincode,offphone1 as phone1,offphone2 as phone2,mobile,M.username as LastModifiedBy,C.lastmodifiedtime,L.username as CreatedBy,C.createdtime from dbo.parenttable C inner join logintable M on C.lastmodifiedid=M.id inner join logintable L on C.createdid=L.id where fk_admissionno=@admissionno";
        #region EventTable
        public const string SDate = "@sDate";
        public const string EDate = "@eDate";
        public const string TitleString = "@title";
        public const string DescString = "@desc";
        public const string EventId = "@id";
        public const string EventColor = "@eColor";
        public const string WholeDay = "@all";
        public const string CreatedId="@createdid";
        public const string CreatedTime = "@createdtime";
        public const string LastModifiedId="@modifiedid";
        public const string LastModifiedTime = "@modifiedtime";
        #endregion

        #region Login
        public const string Id = "@id";
        public const string User = "@user";
        public const string Pass = "@pass";
        public const string LoginTime = "@logintime";
        #endregion

        public const string AdmissionNo = "@admissionno";
        public const string BatchId = "@batchid";

        public const string ClassId = "@classid";

        public const string ClassName = "@classname";
        public const string Section = "@section";
        #endregion
    }
}
