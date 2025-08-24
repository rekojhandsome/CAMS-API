using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAMS_API.Migrations
{
    /// <inheritdoc />
    public partial class Addedcascadedeletebehavioronarhtoarsrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetRequestSignatories_AssetRequestHeaders_AssetRequestHeaderAssetRequestID",
                table: "AssetRequestSignatories");

            migrationBuilder.DropIndex(
                name: "IX_AssetRequestSignatories_AssetRequestHeaderAssetRequestID",
                table: "AssetRequestSignatories");

            migrationBuilder.DropColumn(
                name: "AssetRequestHeaderAssetRequestID",
                table: "AssetRequestSignatories");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetRequestSignatories_AssetRequestHeaders_AssetRequestID",
                table: "AssetRequestSignatories",
                column: "AssetRequestID",
                principalTable: "AssetRequestHeaders",
                principalColumn: "AssetRequestID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetRequestSignatories_AssetRequestHeaders_AssetRequestID",
                table: "AssetRequestSignatories");

            migrationBuilder.AddColumn<int>(
                name: "AssetRequestHeaderAssetRequestID",
                table: "AssetRequestSignatories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetRequestSignatories_AssetRequestHeaderAssetRequestID",
                table: "AssetRequestSignatories",
                column: "AssetRequestHeaderAssetRequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetRequestSignatories_AssetRequestHeaders_AssetRequestHeaderAssetRequestID",
                table: "AssetRequestSignatories",
                column: "AssetRequestHeaderAssetRequestID",
                principalTable: "AssetRequestHeaders",
                principalColumn: "AssetRequestID");
        }
    }
}
