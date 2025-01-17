using TravelManagement.Models.Shared.Actions;
using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Users.Service.Actions
{
    public class DeleterUser : Deleter<UserModel, long>, IActionBase
    {
        public DeleterUser(IRepository<UserModel, long> repository) 
            : base(repository)
        {
        }
    }
}
