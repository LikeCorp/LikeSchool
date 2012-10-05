using System;
namespace LikeSchool.Modals
{
    public interface ICourseModal
    {
        string CourseName { get; set; }
        int CouserId { get; set; }
        int NoOfStudents { get; set; }
        IUpdaterDetailTableModal UpdateModal { get; set; }
    }
}
