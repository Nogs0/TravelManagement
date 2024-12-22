using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Driver.Service
{
    public class UpdaterDriver
    {
        private readonly IRepository<DriverModel, long> _repository;
        public UpdaterDriver(IRepository<DriverModel, long> repository) 
        {
            _repository = repository;
        }

        public async Task<DriverModel> UpdateAsync(DriverModel input)
        {
            /*
             * >> If necessary you can add your preferences here <<
            */

            return await _repository.UpdateAsync(input);
        }
    }
}
