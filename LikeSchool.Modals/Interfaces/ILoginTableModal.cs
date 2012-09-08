using System;
namespace LikeSchool.Modals
{
    public interface ILoginTableModal
    {
        int Id { get; set; }
        string Password { get; set; }
        string Roles { get; set; }
        string UserName { get; set; }
        DateTime LastLoginTime { get; set; }
    }
}
