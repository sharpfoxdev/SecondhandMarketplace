using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.API.Migrations
{
    /// <inheritdoc />
    public partial class tryingtofillinthetablesandmoreeditingtocolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GeneralListings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RandomIntProperty",
                table: "GeneralListings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RandomProperty",
                table: "GeneralListings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonOfSale",
                table: "GeneralListings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "GeneralListings",
                columns: new[] { "Id", "Description", "Discriminator", "RandomIntProperty", "ReasonOfSale" },
                values: new object[] { new Guid("8ee116e1-24c8-4421-97ec-75d6904d33c7"), "Easy", "GeneralListing", 1, "I don't need it anymore" });

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
                keyValue: new Guid("8ee116e1-24c8-4421-97ec-75d6904d33c7"));

            migrationBuilder.DeleteData(
                table: "GeneralListings",
                keyColumn: "Id",
                keyValue: new Guid("cacdc277-499a-4232-95f5-a5e1f5767d1c"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "RandomIntProperty",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "RandomProperty",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "ReasonOfSale",
                table: "GeneralListings");
        }
    }
}
