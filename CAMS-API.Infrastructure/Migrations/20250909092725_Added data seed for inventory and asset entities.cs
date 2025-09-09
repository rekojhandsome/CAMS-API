using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CAMS_API.Migrations
{
    /// <inheritdoc />
    public partial class Addeddataseedforinventoryandassetentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetID", "AssetName", "DateAcquired", "DeviceID", "Price", "SerialNumber", "Status" },
                values: new object[,]
                {
                    { 1, "Sample Laptop Asset", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3000, "SN123456", "Available" },
                    { 2, "Sample Mobile Phone", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5000, "SN654321", "Available" }
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "InventoryID", "AssetID", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 20 },
                    { 2, 2, 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "AssetID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "AssetID",
                keyValue: 2);
        }
    }
}
