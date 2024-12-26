using TravelManagement.Models.Shared.Actions;
using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Entries.Service.Actions
{
    public class UpdaterEntry : Updater<EntryModel, long>, IActionBase
    {
        public UpdaterEntry(IRepository<EntryModel, long> repository)
            : base(repository)
        { }
    }
}
