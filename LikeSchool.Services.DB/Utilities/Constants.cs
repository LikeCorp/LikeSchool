using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSchool.Services.DB
{
    public sealed class Constants
    {
        public const string ErrorString = "error";
        public const string SuccessString = "success";

        /*Stored procedures need to be appended with SP_[storedprocedure name]*/
        public const string SP_InsertEventTable = "InsertEventTable";
        public const string SP_SelectEventTable = "SelectEventTable";
        public const string SP_SelectLoginTable = "SelectLoginTable";

        public const string LikeConnectionString = "likeconnectionstring";

        #region EventTable
        public const string SDate = "@sDate";       
        public const string EDate = "@eDate";       
        public const string TitleString = "@title";
        public const string DescString = "@desc";           
        public const string EventId = "@id";        
        public const string EventColor = "@eColor";
        public const string WholeDay = "@all";
        #endregion

        #region Login
        public const string User = "@user";
        public const string Pass = "@pass";
        #endregion
    }
}