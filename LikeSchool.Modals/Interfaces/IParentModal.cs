using System;
namespace LikeSchool.Modals
{
    public interface IParentModal
    {
        IContactModal ContactModal { get; set; }
        string DateOfBirth { get; set; }
        string Education { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string Income { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string Occupation { get; set; }
        string Relation { get; set; }
        IUpdaterDetailTableModal UpdateModal { get; set; }
    }
}
