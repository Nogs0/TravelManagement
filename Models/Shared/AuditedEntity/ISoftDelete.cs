using System.ComponentModel;

namespace TravelManagement.Models.Shared.AuditedEntity
{
    public interface ISoftDelete
    {
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
