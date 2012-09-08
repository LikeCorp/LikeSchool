using System;
namespace LikeSchool.Modals
{
    public interface IStudentTableModal
    {
        string AdmissionDate { get; set; }
        int AdmissionNo { get; set; }
        IBatchTableModal BatchModal { get; set; }
        IClassTableModal ClassModal { get; set; }
        IContactModal ContactModal { get; set; }
        string FirstName { get; set; }
        System.Drawing.Image Image { get; set; }
        string LastName { get; set; }
        string MiddelName { get; set; }
        IOtherModal OtherModal { get; set; }
        IParentModal ParentModal { get; set; }
        IUpdaterDetailTableModal UpdateModal { get; set; }
    }
}
