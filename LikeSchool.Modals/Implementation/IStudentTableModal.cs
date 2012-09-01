using System;
namespace LikeSchool.Modals
{
    public interface IStudentTableModal
    {
        string AdmissionDate { get; set; }
        int AdmissionNo { get; set; }
        LikeSchool.Modals.IBatchTableModal BatchModal { get; set; }
        LikeSchool.Modals.IClassTableModal ClassModal { get; set; }
        LikeSchool.Modals.IContactModal ContactModal { get; set; }
        string FirstName { get; set; }
        System.Drawing.Image Image { get; set; }
        string LastName { get; set; }
        string MiddelName { get; set; }
        LikeSchool.Modals.IOtherModal OtherModal { get; set; }
        LikeSchool.Modals.IParentModal ParentModal { get; set; }
    }
}
