using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LikeSchool.Modals
{
    public class ContactModal : IContactModal
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public IUpdaterDetailTableModal UpdateModal { get; set; }
    }
}
