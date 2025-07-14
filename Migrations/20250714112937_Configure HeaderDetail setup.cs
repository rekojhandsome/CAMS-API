using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAMS_API.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureHeaderDetailsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetRequestHeaders",
                columns: table => new
                {
                    assetRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assetRequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    employeeID = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalAssetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    requiresApproval = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetRequestHeaders", x => x.assetRequestID);
                    table.ForeignKey(
                        name: "FK_AssetRequestHeaders_Employees_employeeID",
                        column: x => x.employeeID,
                        principalTable: "Employees",
                        principalColumn: "employeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetRequestDetail",
                columns: table => new
                {
                    assetRequestID = table.Column<int>(type: "int", nullable: false),
                    sequenceID = table.Column<int>(type: "int", nullable: false),
                    assetID = table.Column<int>(type: "int", nullable: false),
                    assetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetRequestDetail", x => new { x.assetRequestID, x.sequenceID });
                    table.ForeignKey(
                        name: "FK_AssetRequestDetail_AssetRequestHeaders_assetRequestID",
                        column: x => x.assetRequestID,
                        principalTable: "AssetRequestHeaders",
                        principalColumn: "assetRequestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetRequestHeaders_employeeID",
                table: "AssetRequestHeaders",
                column: "employeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetRequestDetail");

            migrationBuilder.DropTable(
                name: "AssetRequestHeaders");
        }
    }
}
