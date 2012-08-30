using System;
namespace LikeSchool.Services.DB.Modals
{
    public interface IStudentTableModal:IClassTableModal,IAdmissionModal
    {
        int BatchId { get; set; }
        string FirstName { get; set; }
        System.Drawing.Image Image { get; set; }
        string LastName { get; set; }
        string MiddelName { get; set; }
    }
}
