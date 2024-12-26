using System.ComponentModel.DataAnnotations;
using TravelManagement.Models.Shared.CustomAttributes;
using TravelManagement.Models.Shared.AuditedEntity;

namespace TravelManagement.Models.Driver
{
    public class DriverModel : AuditedEntity<long>
    {
        [MaxLength(256)]
        public required string Name { get; set; }

        [CPFValidator]
        public required string CPF { get; set; }

        [MaxLength(15)]
        public required string PhoneNumber { get; set; }
    }
}
