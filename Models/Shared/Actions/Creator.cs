
using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Shared.Actions
{
    public class Creator<Model, PKType> : ICreator<Model, PKType>
        where Model : class
        where PKType : struct
    {

        private readonly IRepository<Model, PKType> _repository;

        public Creator(IRepository<Model, PKType> repository)
        {
            _repository = repository;
        }

        public virtual async Task<Model> CreateAsync(Model model)
        {
            return await _repository.CreateAsync(model);
        }
    }
}
