using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;

namespace LikeSchool.Services.DB.Modals
{
    public class StudentTableModal : IStudentTableModal
    {
        public string FirstName { get; set; }
        public string MiddelName { get; set; }
        public string LastName { get; set; }
        public int BatchId { get; set; }
        public Image Image { get; set; }

        public string ClassName
        {
            get;
            set;
        }

        public int ClassId
        {
            get;
            set;
        }

        public string Section
        {
            get;
            set;
        }

        public string AdmissionDate
        {
            get;
            set;
        }

        public int AdmissionNo
        {
            get;
            set;
        }
    }
}