using Microsoft.EntityFrameworkCore;
using TravelManagement.Models.Driver;
using TravelManagement.Models.Entries;

namespace TravelManagement.Database
{
    public class TravelManagementDbContext : DbContext
    {
        public TravelManagementDbContext(DbContextOptions<TravelManagementDbContext> options) 
            : base(options) { }

        public DbSet<DriverModel> Drivers { get; set; }
        public DbSet<EntryModel> Entries { get; set; }
    }
}
