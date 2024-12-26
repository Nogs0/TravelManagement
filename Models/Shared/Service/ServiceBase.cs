
namespace TravelManagement.Models.Shared.Service
{
    public class ServiceBase<Model, PKType>
        where Model : class
        where PKType : struct
    {
        public virtual Task<Model> CreateAsync(Model entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task DeleteAsync(PKType id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<Model>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<Model> GetAsync(PKType id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<Model> UpdateAsync(Model entity)
        {
            throw new NotImplementedException();
        }
    }
}
