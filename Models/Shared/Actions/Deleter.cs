
using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Shared.Actions
{
    public class Deleter<Model, PKType> : IDeleter<Model, PKType>
        where Model : class
        where PKType : struct
    {
        private readonly IRepository<Model, PKType> _repository;

        public Deleter(IRepository<Model, PKType> repository)
        {
            _repository = repository;
        }

        public virtual async Task DeleteAsync(PKType id)
        {
            await _repository.DeleteAsync(id);         
        }
    }
}
