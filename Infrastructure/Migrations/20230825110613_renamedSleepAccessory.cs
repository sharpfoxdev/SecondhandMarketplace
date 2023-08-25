using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renamedSleepAccessory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_SleepAcessoryType_SleepAcessoryTypeId",
                table: "Listings");

            migrationBuilder.DropTable(
                name: "SleepAcessoryType");

            migrationBuilder.CreateTable(
                name: "SleepAccessoryType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepAccessoryType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_SleepAccessoryType_SleepAcessoryTypeId",
                table: "Listings",
                column: "SleepAcessoryTypeId",
                principalTable: "SleepAccessoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_SleepAccessoryType_SleepAcessoryTypeId",
                table: "Listings");

            migrationBuilder.DropTable(
                name: "SleepAccessoryType");

            migrationBuilder.CreateTable(
                name: "SleepAcessoryType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepAcessoryType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_SleepAcessoryType_SleepAcessoryTypeId",
                table: "Listings",
                column: "SleepAcessoryTypeId",
                principalTable: "SleepAcessoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
