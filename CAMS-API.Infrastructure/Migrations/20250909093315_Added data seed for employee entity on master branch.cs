using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAMS_API.Migrations
{
    /// <inheritdoc />
    public partial class Addeddataseedforemployeeentityonmasterbranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "BirthDate", "ContactNo", "DateCreated", "DateHired", "DepartmentID", "Email", "FirstName", "Gender", "LastName", "MiddleName", "PositionID", "Suffix" },
                values: new object[] { 4, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1234567890, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "admin@gmail.com", "Admin", "Male", "admin", "A", 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 4);
        }
    }
}
