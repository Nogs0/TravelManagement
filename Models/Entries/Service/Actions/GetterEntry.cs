using TravelManagement.Models.Shared.Actions;
using TravelManagement.Models.Shared.Repository;

namespace TravelManagement.Models.Entries.Service.Actions
{
    public class GetterEntry : Getter<EntryModel, long>, IActionBase
    {
        public GetterEntry(IRepository<EntryModel, long> repository)
            : base(repository)
        { }
    }
}
