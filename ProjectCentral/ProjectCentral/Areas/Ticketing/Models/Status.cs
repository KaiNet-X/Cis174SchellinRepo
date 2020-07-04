
namespace ProjectCentral.Areas.Ticketing.Models
{
    //Instead of creating database object, use enum for statuses
    public enum Status : byte
    {
        ToDo,
        InProgress,
        QualityAssurance,
        Done
    }
}
