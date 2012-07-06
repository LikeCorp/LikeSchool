using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LikeSchool.Services.DB.Insert;

namespace LikeSchool.Services.DB.Modals
{
    public class EventTableModal : SP
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
        public string InputStartDate {get;set;}
        public string InputEndDate{get;set;}

        public List<Procedure> GetInsertProcedureList()
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

        public List<Procedure> GetSelectProcedureList()
        {
            List<Procedure> procs = new List<Procedure>();
            procs.Add(new Procedure() { ProcedureParameter = Constants.SDate, ProcedureValue = StartDate, IsOutParemeter = true });
            procs.Add(new Procedure() { ProcedureParameter = Constants.STime, ProcedureValue = StartTime, IsOutParemeter = true });
            procs.Add(new Procedure() { ProcedureParameter = Constants.EDate, ProcedureValue = EndDate, IsOutParemeter = true });
            procs.Add(new Procedure() { ProcedureParameter = Constants.ETime, ProcedureValue = EndTime, IsOutParemeter = true });
            procs.Add(new Procedure() { ProcedureParameter = Constants.TitleString, ProcedureValue = Title, IsOutParemeter = true });        
            procs.Add(new Procedure() { ProcedureParameter = Constants.EventId, ProcedureValue = EventId, IsOutParemeter = true });
            procs.Add(new Procedure() { ProcedureParameter = Constants.InputSDate, ProcedureValue = InputStartDate, IsOutParemeter = false });
            procs.Add(new Procedure() { ProcedureParameter = Constants.InputEDate, ProcedureValue = InputEndDate, IsOutParemeter = false });
            return procs;
        }

        public override List<Procedure> ExecuteProcedure(string procedureName,List<Procedure> parameters)
        {
            return base.ExecuteProcedure(procedureName, parameters);
        }
    }
}