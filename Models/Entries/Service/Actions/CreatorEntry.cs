using TravelManagement.Models.Driver;
using TravelManagement.Models.Shared.Actions;
using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Entries.Service.Actions
{
    public class CreatorEntry : Creator<EntryModel, long>, IActionBase
    {
        public CreatorEntry(IRepository<EntryModel, long> repository) 
            : base(repository)
        { }
    }
}
