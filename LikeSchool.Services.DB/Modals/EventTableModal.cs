using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;


namespace LikeSchool.Services.DB.Modals
{
    public class EventTableModal : Connection
    {
        public string StartDate
        {
            get;
            set;
        }
        public int StartTime { get; set; }
        public string EndDate { get; set; }
        public int EndTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IsRecursive { get; set; }
        public int EventId { get; set; }
        public string InputStartDate { get; set; }
        public string InputEndDate { get; set; }

        public string InsertEvents(string procedureName, EventTableModal parameter)
        {
            OpenConnection();
            var dynamic = new DynamicParameters();
            dynamic.Add(Constants.SDate, parameter.StartDate);
            dynamic.Add(Constants.STime, parameter.StartTime);
            dynamic.Add(Constants.EDate, parameter.EndDate);
            dynamic.Add(Constants.ETime, parameter.EndTime);
            dynamic.Add(Constants.TitleString, parameter.Title);
            dynamic.Add(Constants.DescString, parameter.Description);
            dynamic.Add(Constants.Recursive, parameter.IsRecursive);
            dynamic.Add(Constants.EventId, dbType: DbType.Int32, direction: ParameterDirection.Output);
            DbConnection.Execute(Constants.SP_InsertEventTable, dynamic, null, null, CommandType.StoredProcedure);
            CloseConnection();
            return dynamic.Get<int>(Constants.EventId).ToString();
        }

        public List<EventTableModal> GetEvents(string procedureName, EventTableModal parameter)
        {
            OpenConnection();
            List<EventTableModal> result = DbConnection.Query<EventTableModal>(Constants.SP_SelectEventTable, new
            {
                iSDate = parameter.InputStartDate,
                iEDate = parameter.InputEndDate
            },
            commandType: CommandType.StoredProcedure).ToList<EventTableModal>();
            CloseConnection();
            return result;
        }
    }
}