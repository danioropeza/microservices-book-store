using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreServices.Api.Book.Migrations
{
    /// <inheritdoc />
    public partial class RestructureOfBookNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaterialLibraryId",
                table: "BookMaterial",
                newName: "BookMaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookMaterialId",
                table: "BookMaterial",
                newName: "MaterialLibraryId");
        }
    }
}
