namespace TravelManagement.Models.Shared.AuditedEntity
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
