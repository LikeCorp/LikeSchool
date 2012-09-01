using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;

namespace LikeSchool.Modals
{
    public class StudentTableModal : IStudentTableModal 
    {
        #region IStudentTableModal Properties
        public string FirstName { get; set; }
        public string MiddelName { get; set; }
        public string LastName { get; set; }        
        public Image Image { get; set; }       
        public string AdmissionDate { get; set; }
        public int AdmissionNo { get; set; }
        #endregion
        public IClassTableModal ClassModal { get; set; }
        public IBatchTableModal BatchModal { get; set; }
        public IContactModal ContactModal { get; set; }
        public IOtherModal OtherModal { get; set; }
        public IParentModal ParentModal { get; set; }

    }
}