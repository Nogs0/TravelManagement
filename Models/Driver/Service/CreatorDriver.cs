using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Driver.Service
{
    public class CreatorDriver
    {
        private readonly IRepository<DriverModel, long> _repository;

        public CreatorDriver(IRepository<DriverModel, long> repository)
        {
            _repository = repository;
        }
    }
}
