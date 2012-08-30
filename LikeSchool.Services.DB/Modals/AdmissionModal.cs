using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSchool.Services.DB.Modals
{
    public class AdmissionModal : IAdmissionModal
    {
        public int AdmissionNo { get; set; }
        public string AdmissionDate { get; set; }
    }
}