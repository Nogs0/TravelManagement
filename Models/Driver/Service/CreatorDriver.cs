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

        public async Task<DriverModel> CreateAsync(DriverModel input)
        {
            /*
             *  >> if necessary you can add your preferences here <<
            */

            return await _repository.CreateAsync(input);
        }
    }
}
