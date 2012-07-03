using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LikeSchool.Services.DB.Insert;

namespace LikeSchool.Services.DB.Modals
{
    public class EventTableModal : InsertSP
    {

        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IsRecursive { get; set; }
        public string IsReminder { get; set; }
        public string EventId { get; set; }

        public List<Procedure> GetProcedureList()
        {
            List<Procedure> procs = new List<Procedure>();
            procs.Add(new Procedure() { ProcedureParameter = Constants.SDate, ProcedureValue = StartDate,IsOutParemeter=false });
            procs.Add(new Procedure() { ProcedureParameter = Constants.STime, ProcedureValue = StartTime, IsOutParemeter = false });
            procs.Add(new Procedure() { ProcedureParameter = Constants.EDate, ProcedureValue = EndDate, IsOutParemeter = false });
            procs.Add(new Procedure() { ProcedureParameter = Constants.ETime, ProcedureValue = EndTime, IsOutParemeter = false });
            procs.Add(new Procedure() { ProcedureParameter = Constants.TitleString, ProcedureValue = Title, IsOutParemeter = false });
            procs.Add(new Procedure() { ProcedureParameter = Constants.DescString, ProcedureValue = Description, IsOutParemeter = false });
            procs.Add(new Procedure() { ProcedureParameter = Constants.Recursive, ProcedureValue = IsRecursive, IsOutParemeter = false });
            procs.Add(new Procedure() { ProcedureParameter = Constants.Reminder, ProcedureValue = IsReminder, IsOutParemeter = false });
            procs.Add(new Procedure(){ ProcedureParameter=Constants.EventId,ProcedureValue= EventId,IsOutParemeter=true});
            return procs;
        }

        public override List<Procedure> InsertProcedure(string procedureName)
        {
            base.Parameters = GetProcedureList();
            return base.InsertProcedure(procedureName);
        }
    }
}