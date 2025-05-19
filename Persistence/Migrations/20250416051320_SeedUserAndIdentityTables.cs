using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace e_commerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserAndIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDefault", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e963a95-217b-4c06-9622-57d9cb92a41c", "97e60efb-a384-407e-8130-23b5ede2f733", false, false, "Admin", "ADMIN" },
                    { "f1e3d9e3-87cd-462a-94d3-bac02fffab15", "6ee77eea-37f5-4c72-82ee-6d755f360441", true, false, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDisabled", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "44ea9939-cebc-4632-8471-0c3d2da01619", 0, "12dfb24d-b26d-4f94-b449-6f12558c7b3e", "admin@ecommerce.com", true, "Mohammed", false, "Elkashef", false, null, "ADMIN@ECOMMERCE.COM", "ADMIN@ECOMMERCE.COM", "AQAAAAIAAYagAAAAEOHet8Ru82eVNV9Yjz7hipZzsg585sKpUs3kaAWSNQlT644A0tX3m0xnAD1E5lkavw==", null, false, "40BD8B11906F462C9747E98EAC3E378D", false, "admin@ecommerce.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6e963a95-217b-4c06-9622-57d9cb92a41c", "44ea9939-cebc-4632-8471-0c3d2da01619" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1e3d9e3-87cd-462a-94d3-bac02fffab15");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6e963a95-217b-4c06-9622-57d9cb92a41c", "44ea9939-cebc-4632-8471-0c3d2da01619" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e963a95-217b-4c06-9622-57d9cb92a41c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44ea9939-cebc-4632-8471-0c3d2da01619");
        }
    }
}
