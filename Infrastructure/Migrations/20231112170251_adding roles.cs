using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "037456a1-ed87-45ab-9ca2-4d04ddcbd456", "037456a1-ed87-45ab-9ca2-4d04ddcbd456", "User", "USER" },
                    { "eb40d90b-a879-4582-a19f-d2732b324b2f", "eb40d90b-a879-4582-a19f-d2732b324b2f", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037456a1-ed87-45ab-9ca2-4d04ddcbd456");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb40d90b-a879-4582-a19f-d2732b324b2f");
        }
    }
}
