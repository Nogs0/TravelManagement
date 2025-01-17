namespace TravelManagement.Models.Shared.AuditedEntity
{
    public class AuditedEntity<T> : IAuditedEntity<T>
    {
        public DateTime CreationTime { get; set; }
        public long CreatorUserId { get; set; }
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
