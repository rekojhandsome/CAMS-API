using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CAMS_API.Migrations
{
    /// <inheritdoc />
    public partial class CreatedSeeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "DepartmentCode", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "IT", "IT Department" },
                    { 2, "HR", "HR Department" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "DeviceID", "Brand", "DeviceName", "DeviceType", "Model" },
                values: new object[,]
                {
                    { 1, "Sample Brand", "Sample Laptop", "Computer", "Sample Model" },
                    { 2, "Sample Mobile Brand", "Mobile Phone", "Smartphone", "Sample Mobile Model" }
                });

            migrationBuilder.InsertData(
                table: "DocumentSignatories",
                columns: new[] { "DepartmentID", "DocumentID", "SignatoryID", "DateCreated", "DateModified", "DocumentName", "IsActive", "Level", "PositionID", "PositionName", "SignatoryName" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asset Request", true, 1, 2, "Manager", "Sample Manager" },
                    { 1, 1, 3, new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asset Request", true, 2, 3, "CEO", "CEO ceo" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionID", "PositionName" },
                values: new object[,]
                {
                    { 1, "Programmer" },
                    { 2, "Manager" },
                    { 3, "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "BirthDate", "ContactNo", "DateCreated", "DateHired", "DepartmentID", "Email", "FirstName", "Gender", "LastName", "MiddleName", "PositionID", "Suffix" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1234567890, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "sample@gmail.com", "John", "Male", "Doe", "A", 1, null },
                    { 2, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1234567890, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "sample@gmail.com", "Sample", "Male", "Manager", "A", 2, null },
                    { 3, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1234567890, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "sample@gmail.com", "CEO", "Male", "ceo", "A", 3, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "DeviceID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "DeviceID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DocumentSignatories",
                keyColumns: new[] { "DepartmentID", "DocumentID", "SignatoryID" },
                keyValues: new object[] { 1, 1, 2 });

            migrationBuilder.DeleteData(
                table: "DocumentSignatories",
                keyColumns: new[] { "DepartmentID", "DocumentID", "SignatoryID" },
                keyValues: new object[] { 1, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionID",
                keyValue: 3);
        }
    }
}
