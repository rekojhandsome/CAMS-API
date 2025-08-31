using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CAMS_API.Migrations
{
    /// <inheritdoc />
    public partial class Latestmigration310825 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceID);
                });

            migrationBuilder.CreateTable(
                name: "DocumentSignatories",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    SignatoryID = table.Column<int>(type: "int", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignatoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionID = table.Column<int>(type: "int", nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentSignatories", x => new { x.DocumentID, x.DepartmentID, x.SignatoryID });
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceID = table.Column<int>(type: "int", nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAcquired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetID);
                    table.ForeignKey(
                        name: "FK_Assets_Devices_DeviceID",
                        column: x => x.DeviceID,
                        principalTable: "Devices",
                        principalColumn: "DeviceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suffix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateHired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PositionID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_Inventory_Assets_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Assets",
                        principalColumn: "AssetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Accounts_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetRequestHeaders",
                columns: table => new
                {
                    AssetRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetRequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAssetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequiresApproval = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetRequestHeaders", x => x.AssetRequestID);
                    table.ForeignKey(
                        name: "FK_AssetRequestHeaders_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetRequestDetails",
                columns: table => new
                {
                    AssetRequestID = table.Column<int>(type: "int", nullable: false),
                    SequenceID = table.Column<int>(type: "int", nullable: false),
                    AssetID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetRequestDetails", x => new { x.AssetRequestID, x.SequenceID });
                    table.ForeignKey(
                        name: "FK_AssetRequestDetails_AssetRequestHeaders_AssetRequestID",
                        column: x => x.AssetRequestID,
                        principalTable: "AssetRequestHeaders",
                        principalColumn: "AssetRequestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetRequestDetails_Assets_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Assets",
                        principalColumn: "AssetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetRequestSignatories",
                columns: table => new
                {
                    AssetRequestID = table.Column<int>(type: "int", nullable: false),
                    SequenceID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    PositionID = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignatoryID = table.Column<int>(type: "int", nullable: false),
                    SignatoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    IsSigned = table.Column<bool>(type: "bit", nullable: true),
                    DateSigned = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetRequestSignatories", x => new { x.AssetRequestID, x.SequenceID, x.DepartmentID, x.PositionID });
                    table.ForeignKey(
                        name: "FK_AssetRequestSignatories_AssetRequestHeaders_AssetRequestID",
                        column: x => x.AssetRequestID,
                        principalTable: "AssetRequestHeaders",
                        principalColumn: "AssetRequestID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EmployeeID",
                table: "Accounts",
                column: "EmployeeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetRequestDetails_AssetID",
                table: "AssetRequestDetails",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetRequestHeaders_EmployeeID",
                table: "AssetRequestHeaders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_DeviceID",
                table: "Assets",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionID",
                table: "Employees",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_AssetID",
                table: "Inventory",
                column: "AssetID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AssetRequestDetails");

            migrationBuilder.DropTable(
                name: "AssetRequestSignatories");

            migrationBuilder.DropTable(
                name: "DocumentSignatories");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "AssetRequestHeaders");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
