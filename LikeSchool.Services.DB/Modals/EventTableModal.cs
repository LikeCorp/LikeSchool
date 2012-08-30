using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;


namespace LikeSchool.Services.DB.Modals
{
    public class EventTableModal : IEventTableModal
    {
        public string Start { get; set; }
        public string End { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public bool AllDay { get; set; }
        public string EventColor { get; set; }
    }
}