using System.ComponentModel.DataAnnotations.Schema;
using TravelManagement.Models.Driver;
using TravelManagement.Models.Shared.AuditedEntity;

namespace TravelManagement.Dtos.Entries
{
    public class EntryInput : AuditedEntity<long>
    {
        public string Route { get; set; }
        public double Value { get; set; }
        public string IsExtra { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("DriverId")]
        public DriverModel? Driver { get; set; }
        public required long DriverId { get; set; }
    }
}
