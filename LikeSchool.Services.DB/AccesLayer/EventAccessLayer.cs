using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using LikeSchool.Modals;

namespace LikeSchool.Services.DB.AccesLayer
{
    public class EventAccessLayer : Connection
    {
        IEventTableModal eventModal;

        public IEventTableModal Modal
        {
            get
            {
                return eventModal;
            }
            set
            {
                eventModal = value;
            }
        }
        public EventAccessLayer()
        {

        }
        public EventAccessLayer(IEventTableModal modal)
        {
            eventModal = modal;
        }

        public string InsertEvents(string procedureName)
        {
            OpenConnection();
            var dynamic = new DynamicParameters();
            dynamic.Add(Constants.TitleString, Modal.Title);
            dynamic.Add(Constants.DescString, Modal.Description);
            dynamic.Add(Constants.SDate, Modal.Start);
            dynamic.Add(Constants.EDate, Modal.End);
            dynamic.Add(Constants.EventColor, Modal.EventColor);
            dynamic.Add(Constants.WholeDay, Modal.AllDay.ToString());
            dynamic.Add(Constants.EventId, dbType: DbType.Int32, direction: ParameterDirection.Output);
            DbConnection.Execute(Constants.SP_InsertEventTable, dynamic, null, null, CommandType.StoredProcedure);
            CloseConnection();
            return dynamic.Get<int>(Constants.EventId).ToString();
        }

        public List<EventTableModal> SelectEvents(string procedureName)
        {
            OpenConnection();
            List<EventTableModal> result = DbConnection.Query<EventTableModal>(procedureName,
            commandType: CommandType.StoredProcedure).ToList<EventTableModal>();
            CloseConnection();
            return result;
        }
    }
}