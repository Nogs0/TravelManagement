using TravelManagement.Models.Shared.Actions;
using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Driver.Service.Actions
{
    public class DeleterDriver : Deleter<DriverModel, long>, IActionBase
    {
        private readonly IRepository<DriverModel, long> _repository;

        public DeleterDriver(IRepository<DriverModel, long> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
