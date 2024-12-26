namespace TravelManagement.Models.Shared.AuditedEntity
{
    public interface IAuditedEntity<T> : IEntity<T>, ISoftDelete
    {
        public DateTime CreationTime { get; set; }
        public long CreatorUserId { get; set; }
    }
}
