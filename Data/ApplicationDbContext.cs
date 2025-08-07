using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CAMS_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Asset> Assets { get; set; }
        
        public DbSet<AssetRequestDetail> AssetRequestDetails { get; set; } 
        public DbSet<AssetRequestHeader> AssetRequestHeaders { get; set; }
        public DbSet<AssetRequestSignatory> AssetRequestSignatories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
