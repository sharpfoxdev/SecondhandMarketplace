using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.API.Migrations
{
    /// <inheritdoc />
    public partial class test3mysql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GeneralListings",
                columns: new[] { "Id", "Description", "Discriminator", "Gender", "RandomIntProperty", "RandomProperty", "ReasonOfSale", "Size" },
                values: new object[] { new Guid("cacdc277-499a-4232-95f5-a5e1f5767d1c"), "A nice shirt", "Clothes", 2, 2, "Random", "I don't need it anymore", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GeneralListings",
                keyColumn: "Id",
                keyValue: new Guid("cacdc277-499a-4232-95f5-a5e1f5767d1c"));
        }
    }
}
