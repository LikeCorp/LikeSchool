using System;
namespace LikeSchool.Modals
{
    public interface IClassTableModal
    {
        string ClassName { get; set; }
        int ClassId { get; set; }
        string Section { get; set; }
    }
}
