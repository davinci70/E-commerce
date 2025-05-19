using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAddressIDtoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Addresses",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Addresses",
                newName: "ID");
        }
    }
}
