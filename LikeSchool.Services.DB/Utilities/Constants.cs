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

        public const string LikeConnectionString = "likeconnectionstring";

        #region EventTable
        public const string SDate = "@sDate";
        public const string STime = "@sTime";
        public const string EDate = "@eDate";
        public const string ETime = "@eTime";
        public const string TitleString = "@title";
        public const string DescString = "@desc";
        public const string Recursive = "@recursive";       
        public const string EventId = "@id";
        public const string InputSDate="@iSDate";
        public const string InputEDate = "@iEDate";
        #endregion
    }
}