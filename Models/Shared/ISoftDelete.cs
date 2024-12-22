using System.ComponentModel;

namespace TravelManagement.Models.Shared
{
    public interface ISoftDelete
    {
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
