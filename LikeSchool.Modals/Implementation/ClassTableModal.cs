using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSchool.Modals
{
    public class ClassTableModal : IClassTableModal
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
        public IUpdaterDetailTableModal UpdateModal { get; set; }
    }
}