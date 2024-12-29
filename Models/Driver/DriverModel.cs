using System.ComponentModel.DataAnnotations;
using TravelManagement.Models.Shared.CustomAttributes;
using TravelManagement.Models.Shared.AuditedEntity;

namespace TravelManagement.Models.Driver
{
    public class DriverModel : AuditedEntity<long>
    {
        [MaxLength(256)]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public required string Name { get; set; }

        [CPFValidator]
        [Required(ErrorMessage = "O CPF é obrigatório!")]
        public required string CPF { get; set; }

        [MaxLength(15)]
        [Required(ErrorMessage = "O telefone é obrigatório")]
        public required string PhoneNumber { get; set; }
    }
}
