using Microsoft.EntityFrameworkCore;
using TravelManagement.Models.Shared.Actions;
using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Users.Service.Actions
{
    public class GetterUser : Getter<UserModel, long>, IActionBase
    {
        private readonly IRepository<UserModel, long> _repository;
        public GetterUser(IRepository<UserModel, long> repository) 
            : base(repository)
        { 
            _repository = repository;
        }

        public async Task<UserModel> GetByUsernameAsync(string username)
        {
            return await _repository.GetAll().FirstOrDefaultAsync(x => x.Username.Trim() == username.Trim()) ??
                throw new Exception("User not found!");
        }
    }
}
