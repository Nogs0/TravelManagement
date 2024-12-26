using TravelManagement.Models.Shared.Actions;
using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Driver.Service.Actions
{
    public class GetterDriver : Getter<DriverModel, long>, IActionBase
    {
        private readonly IRepository<DriverModel, long> _repository;

        public GetterDriver(IRepository<DriverModel, long> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
