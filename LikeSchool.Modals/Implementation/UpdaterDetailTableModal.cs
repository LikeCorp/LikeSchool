using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LikeSchool.Modals
{
    public class UpdaterDetailTableModal : IUpdaterDetailTableModal
    {
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }



        public int CreatedById
        {
            get;
            set;
        }

        public int LastModifiedId
        {
            get;
            set;
        }
    }
}
