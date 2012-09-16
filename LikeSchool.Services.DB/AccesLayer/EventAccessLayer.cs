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
        public EventCollection SelectEventsWithConstrain(string procedureName)
        {
            OpenConnection();
            var dynamic = new DynamicParameters();
            dynamic.Add(Constants.SDate, Modal.StartDT);
            dynamic.Add(Constants.EDate, Modal.EndDT);
            EventCollection lists = new EventCollection();
            DbConnection.Query<EventTableModal, UpdaterDetailTableModal, EventCollection>(procedureName, (eventTable, updateTable) =>
            {
                eventTable.UpdateModal = updateTable;
                lists.Add(eventTable);
                return lists;
            }, dynamic, splitOn: "CreatedById",
            commandType: CommandType.StoredProcedure);

            CloseConnection();
            return lists;
        }
        public int InsertEvents(string procedureName)
        {
            OpenConnection();
            var dynamic = new DynamicParameters();
            dynamic.Add(Constants.TitleString, Modal.Title);
            dynamic.Add(Constants.DescString, Modal.Description);
            dynamic.Add(Constants.SDate, Modal.StartDT);
            dynamic.Add(Constants.EDate, Modal.EndDT);
            dynamic.Add(Constants.EventColor, Modal.EventColor);
            dynamic.Add(Constants.WholeDay, Modal.AllDay.ToString());
            dynamic.Add(Constants.CreatedId, Modal.UpdateModal.CreatedById);
            dynamic.Add(Constants.CreatedTime, Modal.UpdateModal.CreatedTime);
            dynamic.Add(Constants.LastModifiedId, Modal.UpdateModal.LastModifiedId);
            dynamic.Add(Constants.LastModifiedTime, Modal.UpdateModal.LastModifiedTime);
            dynamic.Add(Constants.EventId, dbType: DbType.Int32, direction: ParameterDirection.Output);
            DbConnection.Execute(procedureName, dynamic, null, null, CommandType.StoredProcedure);
            CloseConnection();
            return dynamic.Get<int>(Constants.EventId);

        }

        public bool DeleteEvent(string procedureName)
        {
            try
            {
                OpenConnection();
                var dynamic = new DynamicParameters();
                dynamic.Add(Constants.Id, Modal.Id);
                DbConnection.Query(procedureName, dynamic, null, true, null, CommandType.StoredProcedure);
                CloseConnection();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public EventCollection SelectEvents(string procedureName)
        {
            OpenConnection();
            EventCollection lists = new EventCollection();
            DbConnection.Query<EventTableModal, UpdaterDetailTableModal, EventCollection>(procedureName, (eventTable, updateTable) =>
            {
                eventTable.UpdateModal = updateTable;
                lists.Add(eventTable);
                return lists;
            }, splitOn: "CreatedById",
            commandType: CommandType.StoredProcedure);
            CloseConnection();
            return lists;
        }
    }
}