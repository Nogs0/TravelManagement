using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Driver.Service
{
    public class GetterDriver
    {
        private readonly IRepository<DriverModel, long> _repository;

        public GetterDriver(IRepository<DriverModel, long> repository)
        {
            _repository = repository;
        }

        public async Task<DriverModel> GetAsync(long id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<DriverModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
