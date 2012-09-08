using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSchool.Modals
{
    public class BatchTableModal : IBatchTableModal
    {
        public int BatchId { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public IUpdaterDetailTableModal UpdateModal { get; set; }

    }
}