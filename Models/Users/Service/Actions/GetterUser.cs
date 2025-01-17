using TravelManagement.Models.Shared.Actions;
using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Users.Service.Actions
{
    public class GetterUser : Getter<UserModel, long>
    {
        public GetterUser(IRepository<UserModel, long> repository) 
            : base(repository)
        {
        }
    }
}
