using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSchool.Services.DB.Modals
{
    public class ClassTableModal : LikeSchool.Services.DB.Modals.IClassTableModal
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
    }
}