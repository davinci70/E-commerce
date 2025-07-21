using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlColumnToProductTypesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ProductTypes",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ProductTypes");
        }
    }
}
