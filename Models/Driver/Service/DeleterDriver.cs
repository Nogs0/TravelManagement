using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Driver.Service
{
    public class DeleterDriver
    {
        private readonly IRepository<DriverModel, long> _repository;

        public DeleterDriver(IRepository<DriverModel, long> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
