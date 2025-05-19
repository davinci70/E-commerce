using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace e_commerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCartsPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 11, "permissions", "carts:read", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 12, "permissions", "carts:add", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 13, "permissions", "carts:update", "6e963a95-217b-4c06-9622-57d9cb92a41c" },
                    { 14, "permissions", "carts:delete", "6e963a95-217b-4c06-9622-57d9cb92a41c" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);
        }
    }
}
