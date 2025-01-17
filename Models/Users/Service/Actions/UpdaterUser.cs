using TravelManagement.Models.Shared.Actions;
using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Users.Service.Actions
{
    public class UpdaterUser : Updater<UserModel, long>
    {
        public UpdaterUser(IRepository<UserModel, long> repository) 
            : base(repository)
        {
        }
    }
}
