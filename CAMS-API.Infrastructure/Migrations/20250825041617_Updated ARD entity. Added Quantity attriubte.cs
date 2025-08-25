using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAMS_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedARDentityAddedQuantityattriubte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "AssetRequestDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "AssetRequestDetails");
        }
    }
}
