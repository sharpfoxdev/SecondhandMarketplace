using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addednavigationpropertyforlistingtoseeimages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ListingId1",
                table: "Images",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ListingId1",
                table: "Images",
                column: "ListingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Listings_ListingId1",
                table: "Images",
                column: "ListingId1",
                principalTable: "Listings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Listings_ListingId1",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ListingId1",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ListingId1",
                table: "Images");
        }
    }
}
