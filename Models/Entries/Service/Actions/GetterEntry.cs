using Microsoft.EntityFrameworkCore;
using TravelManagement.Models.Shared.Actions;
using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Entries.Service.Actions
{
    public class GetterEntry : Getter<EntryModel, long>, IActionBase
    {
        private readonly IRepository<EntryModel, long> _repository;
        public GetterEntry(IRepository<EntryModel, long> repository)
            : base(repository)
        { 
            _repository = repository;
        }

        public override IQueryable<EntryModel> GetAll()
        {
            return _repository.GetAll().Include(x => x.Driver);
        }

        public override async Task<EntryModel> GetAsync(long id)
        {
            return await _repository.GetAll().Include(x => x.Driver).FirstOrDefaultAsync(x => x.Id == id) ?? 
                throw new Exception("Entity not found");
        }
    }
}
