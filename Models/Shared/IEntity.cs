namespace TravelManagement.Models.Shared
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
