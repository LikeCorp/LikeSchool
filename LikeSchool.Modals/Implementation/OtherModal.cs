using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LikeSchool.Modals
{
    public class OtherModal : IOtherModal
    {
        public string DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
        public string Religion { get; set; }
    }
}
