
using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Shared.Actions
{
    public class Getter<Model, PKType> : IGetter<Model, PKType>
        where Model : class
        where PKType : struct
    {
        private readonly IRepository<Model, PKType> _repository;

        public Getter(IRepository<Model, PKType> repository)
        {
            _repository = repository;
        }

        public virtual Task<IEnumerable<Model>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public virtual IQueryable<Model> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual Task<Model> GetAsync(PKType id)
        {
            return _repository.GetAsync(id);
        }
    }
}
