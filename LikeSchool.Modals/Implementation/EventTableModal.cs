using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LikeSchool.Modals
{
    public class EventTableModal : IEventTableModal
    {
        private IUpdaterDetailTableModal updateModal;
        private int id;
        private DateTime start;
        private DateTime end;
        public string Start
        {
            get;
            set;
        }
        public string End
        {
            get;
            set;
        }
        internal DateTime StartDT
        {
            get
            {
                return
             DateTime.ParseExact(Start, "yyyy-MM-dd HH:mm tt",
                                          null);
            }
        }
        internal DateTime EndDT
        {
            get
            {
                return DateTime.ParseExact(End, "yyyy-MM-dd HH:mm tt",
                                          null);
            }
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = Convert.ToInt32(value);
            }
        }
        public bool AllDay { get; set; }
        public string EventColor { get; set; }
        public IUpdaterDetailTableModal UpdateModal
        {

            get
            {
                if (updateModal == null)
                    updateModal = new UpdaterDetailTableModal();

                return updateModal;
            }
            set
            {
                updateModal = value;
            }
        }
    }
    public class EventOutputTableModal
    {
        public int Id { get; set; }
    }
}