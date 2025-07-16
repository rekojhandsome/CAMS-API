using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAMS_API.Migrations
{
    /// <inheritdoc />
    public partial class Editedattributenames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetRequestDetail_AssetRequestHeaders_assetRequestID",
                table: "AssetRequestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetRequestDetail_Asset_assetID",
                table: "AssetRequestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetRequestHeaders_Employees_employeeID",
                table: "AssetRequestHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_departmentID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Position_positionID",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "suffix",
                table: "Employees",
                newName: "Suffix");

            migrationBuilder.RenameColumn(
                name: "positionID",
                table: "Employees",
                newName: "PositionID");

            migrationBuilder.RenameColumn(
                name: "middleName",
                table: "Employees",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Employees",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Employees",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Employees",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Employees",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "departmentID",
                table: "Employees",
                newName: "DepartmentID");

            migrationBuilder.RenameColumn(
                name: "dateHired",
                table: "Employees",
                newName: "DateHired");

            migrationBuilder.RenameColumn(
                name: "dateCreated",
                table: "Employees",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "contactNo",
                table: "Employees",
                newName: "ContactNo");

            migrationBuilder.RenameColumn(
                name: "birthDate",
                table: "Employees",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "employeeID",
                table: "Employees",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_positionID",
                table: "Employees",
                newName: "IX_Employees_PositionID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_departmentID",
                table: "Employees",
                newName: "IX_Employees_DepartmentID");

            migrationBuilder.RenameColumn(
                name: "totalAssetValue",
                table: "AssetRequestHeaders",
                newName: "TotalAssetValue");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "AssetRequestHeaders",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "requiresApproval",
                table: "AssetRequestHeaders",
                newName: "RequiresApproval");

            migrationBuilder.RenameColumn(
                name: "employeeID",
                table: "AssetRequestHeaders",
                newName: "EmployeeID");

            migrationBuilder.RenameColumn(
                name: "assetRequestDate",
                table: "AssetRequestHeaders",
                newName: "AssetRequestDate");

            migrationBuilder.RenameColumn(
                name: "assetRequestID",
                table: "AssetRequestHeaders",
                newName: "AssetRequestID");

            migrationBuilder.RenameIndex(
                name: "IX_AssetRequestHeaders_employeeID",
                table: "AssetRequestHeaders",
                newName: "IX_AssetRequestHeaders_EmployeeID");

            migrationBuilder.RenameColumn(
                name: "assetValue",
                table: "AssetRequestDetail",
                newName: "AssetValue");

            migrationBuilder.RenameColumn(
                name: "assetID",
                table: "AssetRequestDetail",
                newName: "AssetID");

            migrationBuilder.RenameColumn(
                name: "sequenceID",
                table: "AssetRequestDetail",
                newName: "SequenceID");

            migrationBuilder.RenameColumn(
                name: "assetRequestID",
                table: "AssetRequestDetail",
                newName: "AssetRequestID");

            migrationBuilder.RenameIndex(
                name: "IX_AssetRequestDetail_assetID",
                table: "AssetRequestDetail",
                newName: "IX_AssetRequestDetail_AssetID");

            migrationBuilder.RenameColumn(
                name: "AssetTag",
                table: "Asset",
                newName: "AssetName");

            migrationBuilder.AlterColumn<string>(
                name: "PositionName",
                table: "Position",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Suffix",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentCode",
                table: "Department",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "Asset",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Asset",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAcquired",
                table: "Asset",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

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
                name: "FK_AssetRequestHeaders_Employees_EmployeeID",
                table: "AssetRequestHeaders",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetRequestDetail_AssetRequestHeaders_AssetRequestID",
                table: "AssetRequestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetRequestDetail_Asset_AssetID",
                table: "AssetRequestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetRequestHeaders_Employees_EmployeeID",
                table: "AssetRequestHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_DepartmentID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Position_PositionID",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Suffix",
                table: "Employees",
                newName: "suffix");

            migrationBuilder.RenameColumn(
                name: "PositionID",
                table: "Employees",
                newName: "positionID");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Employees",
                newName: "middleName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Employees",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Employees",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Employees",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Employees",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Employees",
                newName: "departmentID");

            migrationBuilder.RenameColumn(
                name: "DateHired",
                table: "Employees",
                newName: "dateHired");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Employees",
                newName: "dateCreated");

            migrationBuilder.RenameColumn(
                name: "ContactNo",
                table: "Employees",
                newName: "contactNo");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Employees",
                newName: "birthDate");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Employees",
                newName: "employeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_PositionID",
                table: "Employees",
                newName: "IX_Employees_positionID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees",
                newName: "IX_Employees_departmentID");

            migrationBuilder.RenameColumn(
                name: "TotalAssetValue",
                table: "AssetRequestHeaders",
                newName: "totalAssetValue");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "AssetRequestHeaders",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "RequiresApproval",
                table: "AssetRequestHeaders",
                newName: "requiresApproval");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "AssetRequestHeaders",
                newName: "employeeID");

            migrationBuilder.RenameColumn(
                name: "AssetRequestDate",
                table: "AssetRequestHeaders",
                newName: "assetRequestDate");

            migrationBuilder.RenameColumn(
                name: "AssetRequestID",
                table: "AssetRequestHeaders",
                newName: "assetRequestID");

            migrationBuilder.RenameIndex(
                name: "IX_AssetRequestHeaders_EmployeeID",
                table: "AssetRequestHeaders",
                newName: "IX_AssetRequestHeaders_employeeID");

            migrationBuilder.RenameColumn(
                name: "AssetValue",
                table: "AssetRequestDetail",
                newName: "assetValue");

            migrationBuilder.RenameColumn(
                name: "AssetID",
                table: "AssetRequestDetail",
                newName: "assetID");

            migrationBuilder.RenameColumn(
                name: "SequenceID",
                table: "AssetRequestDetail",
                newName: "sequenceID");

            migrationBuilder.RenameColumn(
                name: "AssetRequestID",
                table: "AssetRequestDetail",
                newName: "assetRequestID");

            migrationBuilder.RenameIndex(
                name: "IX_AssetRequestDetail_AssetID",
                table: "AssetRequestDetail",
                newName: "IX_AssetRequestDetail_assetID");

            migrationBuilder.RenameColumn(
                name: "AssetName",
                table: "Asset",
                newName: "AssetTag");

            migrationBuilder.AlterColumn<string>(
                name: "PositionName",
                table: "Position",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "suffix",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "middleName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentCode",
                table: "Department",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "Asset",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Asset",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAcquired",
                table: "Asset",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetRequestDetail_AssetRequestHeaders_assetRequestID",
                table: "AssetRequestDetail",
                column: "assetRequestID",
                principalTable: "AssetRequestHeaders",
                principalColumn: "assetRequestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetRequestDetail_Asset_assetID",
                table: "AssetRequestDetail",
                column: "assetID",
                principalTable: "Asset",
                principalColumn: "AssetID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetRequestHeaders_Employees_employeeID",
                table: "AssetRequestHeaders",
                column: "employeeID",
                principalTable: "Employees",
                principalColumn: "employeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_departmentID",
                table: "Employees",
                column: "departmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Position_positionID",
                table: "Employees",
                column: "positionID",
                principalTable: "Position",
                principalColumn: "PositionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
