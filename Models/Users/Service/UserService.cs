using TravelManagement.Models.Shared.Service;
using TravelManagement.Models.Users.Service.Actions;

namespace TravelManagement.Models.Users.Service
{
    public class UserService : IServiceBase
    {
        private readonly CreatorUser _creator;
        private readonly GetterUser _getter;
        private readonly UpdaterUser _updater;
        private readonly DeleterUser _deleter;

        public UserService(CreatorUser creator,
                            GetterUser getter,
                            UpdaterUser updater,
                            DeleterUser deleter)
        {
            _creator = creator;
            _getter = getter;
            _updater = updater;
            _deleter = deleter;
        }

        public async Task<UserModel> CreateAsync(UserModel input)
        {
            return await _creator.CreateAsync(input);
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await _getter.GetAllAsync();
        }

        public async Task<UserModel> GetAsync(long id)
        {
            return await _getter.GetAsync(id);
        }

        public async Task<UserModel> GetByUsernameAsync(string username)
        {
            return await _getter.GetByUsernameAsync(username);
        }

        public async Task<UserModel> UpdateAsync(UserModel entity)
        {
            return await _updater.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            await _deleter.DeleteAsync(id);
        }
    }
}
