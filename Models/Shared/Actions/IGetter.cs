namespace TravelManagement.Models.Shared.Actions
{
    public interface IGetter<Model, PKType>
        where Model : class
        where PKType : struct
    {
        Task<Model> GetAsync(PKType id);
        Task<IEnumerable<Model>> GetAllAsync();
    }
}
