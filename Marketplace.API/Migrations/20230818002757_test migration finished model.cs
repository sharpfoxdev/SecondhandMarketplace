using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.API.Migrations
{
    /// <inheritdoc />
    public partial class testmigrationfinishedmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "RandomIntProperty",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "RandomProperty",
                table: "GeneralListings");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "GeneralListings",
                newName: "NumberOfPeople");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "GeneralListings",
                newName: "NumberOfDoors");

            migrationBuilder.AddColumn<Guid>(
                name: "BackpackBrandId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "BackpackTypeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Backpack_ColorId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "BinocularsTypeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ClothesBrandId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ClothesSizeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ClothesTypeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ColorId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "ComfortTemperature",
                table: "GeneralListings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CookwareBrandId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "CookwareMaterialId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "CookwareTypeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Cookware_ColorId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ElectronicsTypeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "ExtremeTemperature",
                table: "GeneralListings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GenderId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "HammockBrandId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Hammock_ColorId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<bool>(
                name: "IsSold",
                table: "GeneralListings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "KnifeMultitoolBrandId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "KnifeMultitoolTypeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "KnifeMultitool_ColorId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "LightingBrandId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "LightingTypeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "LimitTemperature",
                table: "GeneralListings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListingImageUrl",
                table: "GeneralListings",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "GeneralListings",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "SellerId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ShoeBrandId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ShoeSizeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ShoeTypeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Shoe_ColorId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Shoe_GenderId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<float>(
                name: "SizeXMetres",
                table: "GeneralListings",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SizeYMetres",
                table: "GeneralListings",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SleepAcessoryTypeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "SleepingBagBrandId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "SleepingBagInsulationTypeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "SleepingBagSeasonId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "SleepingBagShapeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "SleepingBagZipSideId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "SleepingBag_ColorId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "SleepingBag_GenderId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "SleepingPadBrandId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "SleepingPadTypeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "SleepingPad_ColorId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "StateOfItemId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "StoveBrandId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "StoveFuelTypeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TarpBrandId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TarpShapeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Tarp_ColorId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TentBrandId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TrekkingPoleBrandId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TrekkingPoleTypeId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TrekkingPole_ColorId",
                table: "GeneralListings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<bool>(
                name: "Ultralight",
                table: "GeneralListings",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Volume",
                table: "GeneralListings",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "GeneralListings",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BackpackBrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackpackBrand", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BackpackType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackpackType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BinocularsType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinocularsType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClothesBrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesBrand", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClothesSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesSize", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClothesType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CookwareBrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookwareBrand", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CookwareMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookwareMaterial", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CookwareType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookwareType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ElectronicsType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectronicsType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HammockBrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HammockBrand", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KnifeMultitoolBrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnifeMultitoolBrand", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KnifeMultitoolType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnifeMultitoolType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LightingBrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightingBrand", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LightingType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightingType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShoeBrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeBrand", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShoeSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeSize", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShoeType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "SleepingBagBrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepingBagBrand", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SleepingBagInsulationType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepingBagInsulationType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SleepingBagSeason",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepingBagSeason", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SleepingBagShape",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepingBagShape", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SleepingBagZipSide",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepingBagZipSide", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SleepingPadBrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepingPadBrand", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SleepingPadType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepingPadType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StateOfItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateOfItem", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StoveBrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoveBrand", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StoveFuelType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoveFuelType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TarpBrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarpBrand", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TarpShape",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarpShape", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TentBrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TentBrand", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TrekkingPoleBrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrekkingPoleBrand", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TrekkingPoleType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrekkingPoleType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nickname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_Backpack_ColorId",
                table: "GeneralListings",
                column: "Backpack_ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_BackpackBrandId",
                table: "GeneralListings",
                column: "BackpackBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_BackpackTypeId",
                table: "GeneralListings",
                column: "BackpackTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_BinocularsTypeId",
                table: "GeneralListings",
                column: "BinocularsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_ClothesBrandId",
                table: "GeneralListings",
                column: "ClothesBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_ClothesSizeId",
                table: "GeneralListings",
                column: "ClothesSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_ClothesTypeId",
                table: "GeneralListings",
                column: "ClothesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_ColorId",
                table: "GeneralListings",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_Cookware_ColorId",
                table: "GeneralListings",
                column: "Cookware_ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_CookwareBrandId",
                table: "GeneralListings",
                column: "CookwareBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_CookwareMaterialId",
                table: "GeneralListings",
                column: "CookwareMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_CookwareTypeId",
                table: "GeneralListings",
                column: "CookwareTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_ElectronicsTypeId",
                table: "GeneralListings",
                column: "ElectronicsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_GenderId",
                table: "GeneralListings",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_Hammock_ColorId",
                table: "GeneralListings",
                column: "Hammock_ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_HammockBrandId",
                table: "GeneralListings",
                column: "HammockBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_KnifeMultitool_ColorId",
                table: "GeneralListings",
                column: "KnifeMultitool_ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_KnifeMultitoolBrandId",
                table: "GeneralListings",
                column: "KnifeMultitoolBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_KnifeMultitoolTypeId",
                table: "GeneralListings",
                column: "KnifeMultitoolTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_LightingBrandId",
                table: "GeneralListings",
                column: "LightingBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_LightingTypeId",
                table: "GeneralListings",
                column: "LightingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_SellerId",
                table: "GeneralListings",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_Shoe_ColorId",
                table: "GeneralListings",
                column: "Shoe_ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_Shoe_GenderId",
                table: "GeneralListings",
                column: "Shoe_GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_ShoeBrandId",
                table: "GeneralListings",
                column: "ShoeBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_ShoeSizeId",
                table: "GeneralListings",
                column: "ShoeSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_ShoeTypeId",
                table: "GeneralListings",
                column: "ShoeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_SleepAcessoryTypeId",
                table: "GeneralListings",
                column: "SleepAcessoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_SleepingBag_ColorId",
                table: "GeneralListings",
                column: "SleepingBag_ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_SleepingBag_GenderId",
                table: "GeneralListings",
                column: "SleepingBag_GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_SleepingBagBrandId",
                table: "GeneralListings",
                column: "SleepingBagBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_SleepingBagInsulationTypeId",
                table: "GeneralListings",
                column: "SleepingBagInsulationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_SleepingBagSeasonId",
                table: "GeneralListings",
                column: "SleepingBagSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_SleepingBagShapeId",
                table: "GeneralListings",
                column: "SleepingBagShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_SleepingBagZipSideId",
                table: "GeneralListings",
                column: "SleepingBagZipSideId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_SleepingPad_ColorId",
                table: "GeneralListings",
                column: "SleepingPad_ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_SleepingPadBrandId",
                table: "GeneralListings",
                column: "SleepingPadBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_SleepingPadTypeId",
                table: "GeneralListings",
                column: "SleepingPadTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_StateOfItemId",
                table: "GeneralListings",
                column: "StateOfItemId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_StoveBrandId",
                table: "GeneralListings",
                column: "StoveBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_StoveFuelTypeId",
                table: "GeneralListings",
                column: "StoveFuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_Tarp_ColorId",
                table: "GeneralListings",
                column: "Tarp_ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_TarpBrandId",
                table: "GeneralListings",
                column: "TarpBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_TarpShapeId",
                table: "GeneralListings",
                column: "TarpShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_TentBrandId",
                table: "GeneralListings",
                column: "TentBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_TrekkingPole_ColorId",
                table: "GeneralListings",
                column: "TrekkingPole_ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_TrekkingPoleBrandId",
                table: "GeneralListings",
                column: "TrekkingPoleBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralListings_TrekkingPoleTypeId",
                table: "GeneralListings",
                column: "TrekkingPoleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_BackpackBrand_BackpackBrandId",
                table: "GeneralListings",
                column: "BackpackBrandId",
                principalTable: "BackpackBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_BackpackType_BackpackTypeId",
                table: "GeneralListings",
                column: "BackpackTypeId",
                principalTable: "BackpackType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_BinocularsType_BinocularsTypeId",
                table: "GeneralListings",
                column: "BinocularsTypeId",
                principalTable: "BinocularsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_ClothesBrand_ClothesBrandId",
                table: "GeneralListings",
                column: "ClothesBrandId",
                principalTable: "ClothesBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_ClothesSize_ClothesSizeId",
                table: "GeneralListings",
                column: "ClothesSizeId",
                principalTable: "ClothesSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_ClothesType_ClothesTypeId",
                table: "GeneralListings",
                column: "ClothesTypeId",
                principalTable: "ClothesType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_Color_Backpack_ColorId",
                table: "GeneralListings",
                column: "Backpack_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_Color_ColorId",
                table: "GeneralListings",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_Color_Cookware_ColorId",
                table: "GeneralListings",
                column: "Cookware_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_Color_Hammock_ColorId",
                table: "GeneralListings",
                column: "Hammock_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_Color_KnifeMultitool_ColorId",
                table: "GeneralListings",
                column: "KnifeMultitool_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_Color_Shoe_ColorId",
                table: "GeneralListings",
                column: "Shoe_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_Color_SleepingBag_ColorId",
                table: "GeneralListings",
                column: "SleepingBag_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_Color_SleepingPad_ColorId",
                table: "GeneralListings",
                column: "SleepingPad_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_Color_Tarp_ColorId",
                table: "GeneralListings",
                column: "Tarp_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_Color_TrekkingPole_ColorId",
                table: "GeneralListings",
                column: "TrekkingPole_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_CookwareBrand_CookwareBrandId",
                table: "GeneralListings",
                column: "CookwareBrandId",
                principalTable: "CookwareBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_CookwareMaterial_CookwareMaterialId",
                table: "GeneralListings",
                column: "CookwareMaterialId",
                principalTable: "CookwareMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_CookwareType_CookwareTypeId",
                table: "GeneralListings",
                column: "CookwareTypeId",
                principalTable: "CookwareType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_ElectronicsType_ElectronicsTypeId",
                table: "GeneralListings",
                column: "ElectronicsTypeId",
                principalTable: "ElectronicsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_Gender_GenderId",
                table: "GeneralListings",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_Gender_Shoe_GenderId",
                table: "GeneralListings",
                column: "Shoe_GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_Gender_SleepingBag_GenderId",
                table: "GeneralListings",
                column: "SleepingBag_GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_HammockBrand_HammockBrandId",
                table: "GeneralListings",
                column: "HammockBrandId",
                principalTable: "HammockBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_KnifeMultitoolBrand_KnifeMultitoolBrandId",
                table: "GeneralListings",
                column: "KnifeMultitoolBrandId",
                principalTable: "KnifeMultitoolBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_KnifeMultitoolType_KnifeMultitoolTypeId",
                table: "GeneralListings",
                column: "KnifeMultitoolTypeId",
                principalTable: "KnifeMultitoolType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_LightingBrand_LightingBrandId",
                table: "GeneralListings",
                column: "LightingBrandId",
                principalTable: "LightingBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_LightingType_LightingTypeId",
                table: "GeneralListings",
                column: "LightingTypeId",
                principalTable: "LightingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_ShoeBrand_ShoeBrandId",
                table: "GeneralListings",
                column: "ShoeBrandId",
                principalTable: "ShoeBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_ShoeSize_ShoeSizeId",
                table: "GeneralListings",
                column: "ShoeSizeId",
                principalTable: "ShoeSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_ShoeType_ShoeTypeId",
                table: "GeneralListings",
                column: "ShoeTypeId",
                principalTable: "ShoeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_SleepAcessoryType_SleepAcessoryTypeId",
                table: "GeneralListings",
                column: "SleepAcessoryTypeId",
                principalTable: "SleepAcessoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_SleepingBagBrand_SleepingBagBrandId",
                table: "GeneralListings",
                column: "SleepingBagBrandId",
                principalTable: "SleepingBagBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_SleepingBagInsulationType_SleepingBagInsulat~",
                table: "GeneralListings",
                column: "SleepingBagInsulationTypeId",
                principalTable: "SleepingBagInsulationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_SleepingBagSeason_SleepingBagSeasonId",
                table: "GeneralListings",
                column: "SleepingBagSeasonId",
                principalTable: "SleepingBagSeason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_SleepingBagShape_SleepingBagShapeId",
                table: "GeneralListings",
                column: "SleepingBagShapeId",
                principalTable: "SleepingBagShape",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_SleepingBagZipSide_SleepingBagZipSideId",
                table: "GeneralListings",
                column: "SleepingBagZipSideId",
                principalTable: "SleepingBagZipSide",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_SleepingPadBrand_SleepingPadBrandId",
                table: "GeneralListings",
                column: "SleepingPadBrandId",
                principalTable: "SleepingPadBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_SleepingPadType_SleepingPadTypeId",
                table: "GeneralListings",
                column: "SleepingPadTypeId",
                principalTable: "SleepingPadType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_StateOfItem_StateOfItemId",
                table: "GeneralListings",
                column: "StateOfItemId",
                principalTable: "StateOfItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_StoveBrand_StoveBrandId",
                table: "GeneralListings",
                column: "StoveBrandId",
                principalTable: "StoveBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_StoveFuelType_StoveFuelTypeId",
                table: "GeneralListings",
                column: "StoveFuelTypeId",
                principalTable: "StoveFuelType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_TarpBrand_TarpBrandId",
                table: "GeneralListings",
                column: "TarpBrandId",
                principalTable: "TarpBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_TarpShape_TarpShapeId",
                table: "GeneralListings",
                column: "TarpShapeId",
                principalTable: "TarpShape",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_TentBrand_TentBrandId",
                table: "GeneralListings",
                column: "TentBrandId",
                principalTable: "TentBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_TrekkingPoleBrand_TrekkingPoleBrandId",
                table: "GeneralListings",
                column: "TrekkingPoleBrandId",
                principalTable: "TrekkingPoleBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_TrekkingPoleType_TrekkingPoleTypeId",
                table: "GeneralListings",
                column: "TrekkingPoleTypeId",
                principalTable: "TrekkingPoleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralListings_UserProfiles_SellerId",
                table: "GeneralListings",
                column: "SellerId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_BackpackBrand_BackpackBrandId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_BackpackType_BackpackTypeId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_BinocularsType_BinocularsTypeId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_ClothesBrand_ClothesBrandId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_ClothesSize_ClothesSizeId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_ClothesType_ClothesTypeId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_Color_Backpack_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_Color_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_Color_Cookware_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_Color_Hammock_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_Color_KnifeMultitool_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_Color_Shoe_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_Color_SleepingBag_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_Color_SleepingPad_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_Color_Tarp_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_Color_TrekkingPole_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_CookwareBrand_CookwareBrandId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_CookwareMaterial_CookwareMaterialId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_CookwareType_CookwareTypeId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_ElectronicsType_ElectronicsTypeId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_Gender_GenderId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_Gender_Shoe_GenderId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_Gender_SleepingBag_GenderId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_HammockBrand_HammockBrandId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_KnifeMultitoolBrand_KnifeMultitoolBrandId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_KnifeMultitoolType_KnifeMultitoolTypeId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_LightingBrand_LightingBrandId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_LightingType_LightingTypeId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_ShoeBrand_ShoeBrandId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_ShoeSize_ShoeSizeId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_ShoeType_ShoeTypeId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_SleepAcessoryType_SleepAcessoryTypeId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_SleepingBagBrand_SleepingBagBrandId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_SleepingBagInsulationType_SleepingBagInsulat~",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_SleepingBagSeason_SleepingBagSeasonId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_SleepingBagShape_SleepingBagShapeId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_SleepingBagZipSide_SleepingBagZipSideId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_SleepingPadBrand_SleepingPadBrandId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_SleepingPadType_SleepingPadTypeId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_StateOfItem_StateOfItemId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_StoveBrand_StoveBrandId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_StoveFuelType_StoveFuelTypeId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_TarpBrand_TarpBrandId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_TarpShape_TarpShapeId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_TentBrand_TentBrandId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_TrekkingPoleBrand_TrekkingPoleBrandId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_TrekkingPoleType_TrekkingPoleTypeId",
                table: "GeneralListings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralListings_UserProfiles_SellerId",
                table: "GeneralListings");

            migrationBuilder.DropTable(
                name: "BackpackBrand");

            migrationBuilder.DropTable(
                name: "BackpackType");

            migrationBuilder.DropTable(
                name: "BinocularsType");

            migrationBuilder.DropTable(
                name: "ClothesBrand");

            migrationBuilder.DropTable(
                name: "ClothesSize");

            migrationBuilder.DropTable(
                name: "ClothesType");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "CookwareBrand");

            migrationBuilder.DropTable(
                name: "CookwareMaterial");

            migrationBuilder.DropTable(
                name: "CookwareType");

            migrationBuilder.DropTable(
                name: "ElectronicsType");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "HammockBrand");

            migrationBuilder.DropTable(
                name: "KnifeMultitoolBrand");

            migrationBuilder.DropTable(
                name: "KnifeMultitoolType");

            migrationBuilder.DropTable(
                name: "LightingBrand");

            migrationBuilder.DropTable(
                name: "LightingType");

            migrationBuilder.DropTable(
                name: "ShoeBrand");

            migrationBuilder.DropTable(
                name: "ShoeSize");

            migrationBuilder.DropTable(
                name: "ShoeType");

            migrationBuilder.DropTable(
                name: "SleepAcessoryType");

            migrationBuilder.DropTable(
                name: "SleepingBagBrand");

            migrationBuilder.DropTable(
                name: "SleepingBagInsulationType");

            migrationBuilder.DropTable(
                name: "SleepingBagSeason");

            migrationBuilder.DropTable(
                name: "SleepingBagShape");

            migrationBuilder.DropTable(
                name: "SleepingBagZipSide");

            migrationBuilder.DropTable(
                name: "SleepingPadBrand");

            migrationBuilder.DropTable(
                name: "SleepingPadType");

            migrationBuilder.DropTable(
                name: "StateOfItem");

            migrationBuilder.DropTable(
                name: "StoveBrand");

            migrationBuilder.DropTable(
                name: "StoveFuelType");

            migrationBuilder.DropTable(
                name: "TarpBrand");

            migrationBuilder.DropTable(
                name: "TarpShape");

            migrationBuilder.DropTable(
                name: "TentBrand");

            migrationBuilder.DropTable(
                name: "TrekkingPoleBrand");

            migrationBuilder.DropTable(
                name: "TrekkingPoleType");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_Backpack_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_BackpackBrandId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_BackpackTypeId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_BinocularsTypeId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_ClothesBrandId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_ClothesSizeId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_ClothesTypeId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_Cookware_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_CookwareBrandId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_CookwareMaterialId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_CookwareTypeId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_ElectronicsTypeId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_GenderId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_Hammock_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_HammockBrandId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_KnifeMultitool_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_KnifeMultitoolBrandId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_KnifeMultitoolTypeId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_LightingBrandId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_LightingTypeId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_SellerId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_Shoe_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_Shoe_GenderId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_ShoeBrandId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_ShoeSizeId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_ShoeTypeId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_SleepAcessoryTypeId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_SleepingBag_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_SleepingBag_GenderId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_SleepingBagBrandId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_SleepingBagInsulationTypeId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_SleepingBagSeasonId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_SleepingBagShapeId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_SleepingBagZipSideId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_SleepingPad_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_SleepingPadBrandId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_SleepingPadTypeId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_StateOfItemId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_StoveBrandId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_StoveFuelTypeId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_Tarp_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_TarpBrandId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_TarpShapeId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_TentBrandId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_TrekkingPole_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_TrekkingPoleBrandId",
                table: "GeneralListings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralListings_TrekkingPoleTypeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "BackpackBrandId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "BackpackTypeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "Backpack_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "BinocularsTypeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "ClothesBrandId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "ClothesSizeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "ClothesTypeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "ComfortTemperature",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "CookwareBrandId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "CookwareMaterialId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "CookwareTypeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "Cookware_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "ElectronicsTypeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "ExtremeTemperature",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "HammockBrandId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "Hammock_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "IsSold",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "KnifeMultitoolBrandId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "KnifeMultitoolTypeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "KnifeMultitool_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "LightingBrandId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "LightingTypeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "LimitTemperature",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "ListingImageUrl",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "ShoeBrandId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "ShoeSizeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "ShoeTypeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "Shoe_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "Shoe_GenderId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "SizeXMetres",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "SizeYMetres",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "SleepAcessoryTypeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "SleepingBagBrandId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "SleepingBagInsulationTypeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "SleepingBagSeasonId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "SleepingBagShapeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "SleepingBagZipSideId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "SleepingBag_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "SleepingBag_GenderId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "SleepingPadBrandId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "SleepingPadTypeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "SleepingPad_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "StateOfItemId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "StoveBrandId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "StoveFuelTypeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "TarpBrandId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "TarpShapeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "Tarp_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "TentBrandId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "TrekkingPoleBrandId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "TrekkingPoleTypeId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "TrekkingPole_ColorId",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "Ultralight",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "GeneralListings");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "GeneralListings");

            migrationBuilder.RenameColumn(
                name: "NumberOfPeople",
                table: "GeneralListings",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "NumberOfDoors",
                table: "GeneralListings",
                newName: "Gender");

            migrationBuilder.AddColumn<int>(
                name: "RandomIntProperty",
                table: "GeneralListings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RandomProperty",
                table: "GeneralListings",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "GeneralListings",
                columns: new[] { "Id", "Description", "Discriminator", "RandomIntProperty", "ReasonOfSale" },
                values: new object[] { new Guid("8ee116e1-24c8-4421-97ec-75d6904d33c7"), "Easy", "GeneralListing", 1, "I don't need it anymore" });

            migrationBuilder.InsertData(
                table: "GeneralListings",
                columns: new[] { "Id", "Description", "Discriminator", "Gender", "RandomIntProperty", "RandomProperty", "ReasonOfSale", "Size" },
                values: new object[] { new Guid("cacdc277-499a-4232-95f5-a5e1f5767d1c"), "A nice shirt", "Clothes", 2, 2, "Random", "I don't need it anymore", 0 });
        }
    }
}
