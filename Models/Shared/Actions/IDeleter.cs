namespace TravelManagement.Models.Shared.Actions
{
    public interface IDeleter<Model, PKType>
        where Model : class
        where PKType : struct
    {
        Task DeleteAsync(PKType id);
    }
}
