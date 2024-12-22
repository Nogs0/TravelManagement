namespace TravelManagement.Models.Shared.Repository
{
    public interface IRepository<Model, PKType> 
        where Model : class 
        where PKType : struct
    {
        Task<Model> CreateAsync(Model entity);
        Task<PKType> CreateAndGetIdAsync(Model entity);
        Task<IEnumerable<Model>> GetAllAsync();
        Task<Model> GetAsync(PKType id);
        Task<Model> UpdateAsync(Model entity);
        Task<PKType> UpdateAndGetIdAsync(Model entity);
        Task DeleteAsync(PKType id);
    }
}
