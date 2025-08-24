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
        public DbSet<DocumentSignatory> DocumentSignatories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Department>().HasData(
                new Department{
                    DepartmentID = 1,
                    DepartmentName = "IT Department",
                    DepartmentCode = "IT"
                },
                new Department
                {
                    DepartmentID = 2,
                    DepartmentName = "HR Department",
                    DepartmentCode = "HR"
                });

            builder.Entity<Position>().HasData(
                new Position
                {
                    PositionID = 1,
                    PositionName = "Programmer",
                },
                new Position
                {
                    PositionID = 2,
                    PositionName = "Manager",
                },
                new Position 
                {
                    PositionID = 3,
                    PositionName = "CEO"
                });

            builder.Entity<Device>().HasData(
                new Device
                {
                    DeviceID = 1,
                    DeviceName = "Sample Laptop",
                    DeviceType = "Computer",
                    Brand = "Sample Brand",
                    Model = "Sample Model"
                },
                new Device
                {
                    DeviceID = 2,
                    DeviceName = "Mobile Phone",
                    DeviceType = "Smartphone",
                    Brand = "Sample Mobile Brand",
                    Model = "Sample Mobile Model"
                });

            builder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeID = 1,
                    FirstName = "John",
                    MiddleName = "A",
                    LastName = "Doe",
                    BirthDate = new DateTime(1990, 1, 1),
                    Gender = "Male",
                    ContactNo = 1234567890,
                    Email = "sample@gmail.com",
                    DateHired = new DateTime(2020, 1, 1),
                    PositionID = 1,
                    DepartmentID = 1,
                },
                 new Employee
                 {
                     EmployeeID = 2,
                     FirstName = "Sample",
                     MiddleName = "A",
                     LastName = "Manager",
                     BirthDate = new DateTime(1990, 1, 1),
                     Gender = "Male",
                     ContactNo = 1234567890,
                     Email = "sample@gmail.com",
                     DateHired = new DateTime(2020, 1, 1),
                     PositionID = 2,
                     DepartmentID = 1,
                 },
                 new Employee
                 {
                     EmployeeID = 3,
                     FirstName = "CEO",
                     MiddleName = "A",
                     LastName = "ceo",
                     BirthDate = new DateTime(1990, 1, 1),
                     Gender = "Male",
                     ContactNo = 1234567890,
                     Email = "sample@gmail.com",
                     DateHired = new DateTime(2020, 1, 1),
                     PositionID = 3,
                     DepartmentID = 1,
                 }
                 );

            builder.Entity<DocumentSignatory>().HasData(
                new DocumentSignatory
                {
                    DocumentID = 1,
                    DepartmentID = 1,
                    SignatoryID = 2,
                    DocumentName = "Asset Request",
                    SignatoryName = "Sample Manager",
                    PositionID = 2,
                    PositionName = "Manager",
                    Level = 1,
                    IsActive = true,
                    DateCreated = new DateTime(2025, 8, 10)
                },
                new DocumentSignatory
                {
                    DocumentID = 1,
                    DepartmentID = 1,
                    SignatoryID = 3,
                    DocumentName = "Asset Request",
                    SignatoryName = "CEO ceo",
                    PositionID = 3,
                    PositionName ="CEO",
                    Level = 2,
                    IsActive = true,
                    DateCreated = new DateTime(2025, 8, 10)
                });

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }


    }
}
