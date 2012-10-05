using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LikeSchool.Modals
{
    public class EventTableModal : IEventTableModal
    {
        private IUpdaterDetailTableModal updateModal;
        private int id;
        private DateTime startdt;
        private DateTime enddt;
        private string start;
        private string end;
        public string Start
        {
            get
            {
                return start;

            }
            set
            {
                start = value;
                startdt = DateTime.ParseExact(start, "ddd MMM d yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            }
        }
        public string End
        {
            get
            {
                return end;

            }
            set
            {
                end = value;
                enddt = DateTime.ParseExact(end, "ddd MMM d yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            }
        }
        public DateTime StartDT
        {
            get
            {
                return startdt;
            }
            set
            {
                startdt = value;
                start = startdt.ToString();
            }
        }
        public DateTime EndDT
        {
            get
            {
                return enddt;
            }
            set
            {
                enddt = value;
                end = enddt.ToString();
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