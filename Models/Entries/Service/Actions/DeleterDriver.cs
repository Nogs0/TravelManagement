using TravelManagement.Models.Shared.Actions;
using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Entries.Service.Actions
{
    public class DeleterDriver : Deleter<EntryModel, long>, IActionBase
    {
        public DeleterDriver(IRepository<EntryModel, long> repository)
            : base(repository)
        { }
    }
}
