
using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Shared.Actions
{
    public class Updater<Model, PKType> : IUpdater<Model, PKType>
        where Model : class
        where PKType : struct
    {

        private readonly IRepository<Model, PKType> _repository;

        public Updater(IRepository<Model, PKType> repository)
        {
            _repository = repository;
        }

        public virtual async Task<Model> UpdateAsync(Model model)
        {
            return await _repository.UpdateAsync(model);
        }
    }
}
