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
        public string Start
        {
            get;
            set;
        }

        public string End { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public int Id { get; set; }
        public bool AllDay { get; set; }
        public string EventColor { get; set; }

        public string InsertEvents(string procedureName, EventTableModal parameter)
        {
            OpenConnection();
            var dynamic = new DynamicParameters();
            dynamic.Add(Constants.TitleString, parameter.Title);
            dynamic.Add(Constants.DescString, parameter.Description);
            dynamic.Add(Constants.SDate, parameter.Start);
            dynamic.Add(Constants.EDate, parameter.End);
            dynamic.Add(Constants.EventColor, parameter.EventColor);
            dynamic.Add(Constants.WholeDay, parameter.AllDay.ToString());
            dynamic.Add(Constants.EventId, dbType: DbType.Int32, direction: ParameterDirection.Output);
            DbConnection.Execute(Constants.SP_InsertEventTable, dynamic, null, null, CommandType.StoredProcedure);
            CloseConnection();
            return dynamic.Get<int>(Constants.EventId).ToString();
        }

        public List<EventTableModal> GetEvents(string procedureName)
        {
            OpenConnection();
            List<EventTableModal> result = DbConnection.Query<EventTableModal>(procedureName,
            commandType: CommandType.StoredProcedure).ToList<EventTableModal>();
            CloseConnection();
            return result;
        }
    }
}