using TravelManagement.Models.Shared.Actions;
using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Users.Service.Actions
{
    public class CreatorUser : Creator<UserModel, long>, IActionBase
    {
        public CreatorUser(IRepository<UserModel, long> repository) 
            : base(repository)
        {
        }
    }
}
