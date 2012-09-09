using System;
namespace LikeSchool.Modals
{
    public interface IEventTableModal
    {
        bool AllDay { get; set; }
        string Description { get; set; }
        string End { get; set; }
        string EventColor { get; set; }
        int Id { get; set; }
        string Start { get; set; }
        string Title { get; set; }
        IUpdaterDetailTableModal UpdateModal { get; set; }
        DateTime StartDT { get; set; }
        DateTime EndDT { get; set; }
    }
}
