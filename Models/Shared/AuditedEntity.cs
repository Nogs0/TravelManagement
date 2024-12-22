
namespace TravelManagement.Models.Shared
{
    public class AuditedEntity<T> : IAuditedEntity<T>
    {
        public DateTime CreationTime { get; set; }
        public long CreatorUserId { get; set; }
        public required T Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
