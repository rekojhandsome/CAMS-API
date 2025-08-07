using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAMS_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedAssetRequestSignatory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Device_DeviceID",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetRequestDetail_AssetRequestHeaders_AssetRequestID",
                table: "AssetRequestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetRequestDetail_Asset_AssetID",
                table: "AssetRequestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_DepartmentID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Position_PositionID",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Device",
                table: "Device");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetRequestDetail",
                table: "AssetRequestDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asset",
                table: "Asset");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.RenameTable(
                name: "Device",
                newName: "Devices");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "AssetRequestDetail",
                newName: "AssetRequestDetails");

            migrationBuilder.RenameTable(
                name: "Asset",
                newName: "Assets");

            migrationBuilder.RenameIndex(
                name: "IX_AssetRequestDetail_AssetID",
                table: "AssetRequestDetails",
                newName: "IX_AssetRequestDetails_AssetID");

            migrationBuilder.RenameIndex(
                name: "IX_Asset_DeviceID",
                table: "Assets",
                newName: "IX_Assets_DeviceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "PositionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "DeviceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "DepartmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetRequestDetails",
                table: "AssetRequestDetails",
                columns: new[] { "AssetRequestID", "SequenceID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assets",
                table: "Assets",
                column: "AssetID");

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
                    IsSigned = table.Column<bool>(type: "bit", nullable: false),
                    DateSigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssetRequestHeaderAssetRequestID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetRequestSignatories", x => new { x.AssetRequestID, x.SequenceID, x.DepartmentID, x.PositionID });
                    table.ForeignKey(
                        name: "FK_AssetRequestSignatories_AssetRequestHeaders_AssetRequestHeaderAssetRequestID",
                        column: x => x.AssetRequestHeaderAssetRequestID,
                        principalTable: "AssetRequestHeaders",
                        principalColumn: "AssetRequestID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetRequestSignatories_AssetRequestHeaderAssetRequestID",
                table: "AssetRequestSignatories",
                column: "AssetRequestHeaderAssetRequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetRequestDetails_AssetRequestHeaders_AssetRequestID",
                table: "AssetRequestDetails",
                column: "AssetRequestID",
                principalTable: "AssetRequestHeaders",
                principalColumn: "AssetRequestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetRequestDetails_Assets_AssetID",
                table: "AssetRequestDetails",
                column: "AssetID",
                principalTable: "Assets",
                principalColumn: "AssetID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Devices_DeviceID",
                table: "Assets",
                column: "DeviceID",
                principalTable: "Devices",
                principalColumn: "DeviceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionID",
                table: "Employees",
                column: "PositionID",
                principalTable: "Positions",
                principalColumn: "PositionID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetRequestDetails_AssetRequestHeaders_AssetRequestID",
                table: "AssetRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetRequestDetails_Assets_AssetID",
                table: "AssetRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Devices_DeviceID",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionID",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "AssetRequestSignatories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assets",
                table: "Assets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetRequestDetails",
                table: "AssetRequestDetails");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.RenameTable(
                name: "Devices",
                newName: "Device");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "Assets",
                newName: "Asset");

            migrationBuilder.RenameTable(
                name: "AssetRequestDetails",
                newName: "AssetRequestDetail");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_DeviceID",
                table: "Asset",
                newName: "IX_Asset_DeviceID");

            migrationBuilder.RenameIndex(
                name: "IX_AssetRequestDetails_AssetID",
                table: "AssetRequestDetail",
                newName: "IX_AssetRequestDetail_AssetID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "PositionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Device",
                table: "Device",
                column: "DeviceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "DepartmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asset",
                table: "Asset",
                column: "AssetID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetRequestDetail",
                table: "AssetRequestDetail",
                columns: new[] { "AssetRequestID", "SequenceID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Device_DeviceID",
                table: "Asset",
                column: "DeviceID",
                principalTable: "Device",
                principalColumn: "DeviceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetRequestDetail_AssetRequestHeaders_AssetRequestID",
                table: "AssetRequestDetail",
                column: "AssetRequestID",
                principalTable: "AssetRequestHeaders",
                principalColumn: "AssetRequestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetRequestDetail_Asset_AssetID",
                table: "AssetRequestDetail",
                column: "AssetID",
                principalTable: "Asset",
                principalColumn: "AssetID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_DepartmentID",
                table: "Employees",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Position_PositionID",
                table: "Employees",
                column: "PositionID",
                principalTable: "Position",
                principalColumn: "PositionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
