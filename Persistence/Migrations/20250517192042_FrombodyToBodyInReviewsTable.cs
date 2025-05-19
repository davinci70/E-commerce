using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FrombodyToBodyInReviewsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "body",
                table: "Reviews",
                newName: "Body");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Reviews",
                newName: "body");
        }
    }
}
