using System;
namespace LikeSchool.Modals
{
    public interface IUpdaterDetailTableModal
    {
        string CreatedBy { get; set; }
        DateTime CreatedTime { get; set; }
        DateTime LastModifiedTime { get; set; }
        string LastModifiedBy { get; set; }
        int CreatedById { get; set; }
        int LastModifiedId { get; set; }
    }
}
