using TravelManagement.Models.Driver.Service.Actions;
using TravelManagement.Models.Shared.Service;

namespace TravelManagement.Models.Driver.Service
{
    public class DriverService : IServiceBase
    {
        private readonly CreatorDriver _creator;
        private readonly GetterDriver _getter;
        private readonly UpdaterDriver _updater;
        private readonly DeleterDriver _deleter;

        public DriverService(CreatorDriver creator, GetterDriver getter, UpdaterDriver updater, DeleterDriver deleter)
        {
            _creator = creator;
            _getter = getter;
            _updater = updater;
            _deleter = deleter;
        }

        public async Task<DriverModel> CreateAsync(DriverModel input)
        {
            return await _creator.CreateAsync(input);
        }

        public async Task<IEnumerable<DriverModel>> GetAllAsync()
        {
            return await _getter.GetAllAsync();
        }

        public async Task<DriverModel> GetAsync(long id)
        {
            return await _getter.GetAsync(id);
        }

        public async Task<DriverModel> UpdateAsync(DriverModel entity)
        {
            return await _updater.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            await _deleter.DeleteAsync(id);
        }
    }
}
