using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LikeSchool.Modals
{
    public class ParentModal : IParentModal 
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Relation { get; set; }
        public string DateOfBirth { get; set; }
        public string Education { get; set; }
        public string Occupation { get; set; }
        public string Email { get; set; }
        public string Income { get; set; }
        public IContactModal ContactModal { get; set; }
    }
}
