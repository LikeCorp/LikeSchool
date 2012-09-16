using System;
namespace LikeSchool.Modals
{
    public interface ICourseModal
    {
        string CourseName { get; set; }
        int CouserId { get; set; }
        int NoOfStiudents { get; set; }
        IUpdaterDetailTableModal UpdateModal { get; set; }
    }
}
