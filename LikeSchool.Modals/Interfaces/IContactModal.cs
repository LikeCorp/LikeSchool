using System;
namespace LikeSchool.Modals
{
    public interface IContactModal
    {
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string Email { get; set; }
        string Mobile { get; set; }
        string Phone1 { get; set; }
        string Phone2 { get; set; }
        string Pincode { get; set; }
        string State { get; set; }
    }
}
