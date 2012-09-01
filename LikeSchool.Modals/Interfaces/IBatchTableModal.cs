using System;
namespace LikeSchool.Modals
{
   public interface IBatchTableModal
    {
        int BatchId { get; set; }
        int From { get; set; }
        int To { get; set; }
    }
}
