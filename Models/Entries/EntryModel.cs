using System.ComponentModel.DataAnnotations.Schema;
using TravelManagement.Dtos.Entries;
using TravelManagement.Models.Driver;
using TravelManagement.Models.Shared.AuditedEntity;

namespace TravelManagement.Models.Entries
{
    public class EntryModel : AuditedEntity<long>
    {
        public string Route { get; set; }
        public double Value { get; set; }
        public bool IsExtra { get; set; }
        public DateTime Date { get; set; }

        public long DriverId { get; set; }
        [ForeignKey("DriverId")]
        public DriverModel? Driver { get; set; }

        public EntryModel() { }
        public EntryModel(EntryInput input)
        {
            Id = input.Id;
            Route = input.Route;
            Value = input.Value;
            IsExtra = input.IsExtra == "on";
            Date = input.Date;
            DriverId = input.DriverId;
        }
    }
}
