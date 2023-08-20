using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialmigrationtonewdatabaseMarketplace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "GeneralListings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SellerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StateOfItemId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReasonOfSale = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsSold = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ListingImageUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ultralight = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Weight = table.Column<float>(type: "float", nullable: true),
                    BackpackBrandId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    BackpackTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ColorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Volume = table.Column<float>(type: "float", nullable: true),
                    ClothesSizeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ClothesBrandId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Clothes_ColorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    GenderId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ClothesTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CookwareBrandId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CookwareTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CookwareMaterialId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Cookware_ColorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    StoveBrandId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    StoveFuelTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    BinocularsTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ElectronicsTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    KnifeMultitoolBrandId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    KnifeMultitoolTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    KnifeMultitool_ColorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    LightingBrandId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    LightingTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    TrekkingPole_ColorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    TrekkingPoleBrandId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    TrekkingPoleTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ShoeBrandId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ShoeTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ShoeSizeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Shoe_ColorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Shoe_GenderId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    HammockBrandId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Hammock_ColorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SleepAcessoryTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SleepingBag_ColorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SleepingBagZipSideId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SleepingBagShapeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SleepingBagBrandId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SleepingBagInsulationTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SleepingBagSeasonId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SleepingBag_GenderId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ComfortTemperature = table.Column<int>(type: "int", nullable: true),
                    LimitTemperature = table.Column<int>(type: "int", nullable: true),
                    ExtremeTemperature = table.Column<int>(type: "int", nullable: true),
                    SleepingPadBrandId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SleepingPadTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SleepingPad_ColorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    TarpBrandId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Tarp_ColorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    TarpShapeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SizeXMetres = table.Column<float>(type: "float", nullable: true),
                    SizeYMetres = table.Column<float>(type: "float", nullable: true),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: true),
                    NumberOfDoors = table.Column<int>(type: "int", nullable: true),
                    TentBrandId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralListings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralListings_BackpackBrand_BackpackBrandId",
                        column: x => x.BackpackBrandId,
                        principalTable: "BackpackBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_BackpackType_BackpackTypeId",
                        column: x => x.BackpackTypeId,
                        principalTable: "BackpackType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_BinocularsType_BinocularsTypeId",
                        column: x => x.BinocularsTypeId,
                        principalTable: "BinocularsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_ClothesBrand_ClothesBrandId",
                        column: x => x.ClothesBrandId,
                        principalTable: "ClothesBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_ClothesSize_ClothesSizeId",
                        column: x => x.ClothesSizeId,
                        principalTable: "ClothesSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_ClothesType_ClothesTypeId",
                        column: x => x.ClothesTypeId,
                        principalTable: "ClothesType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_Color_Clothes_ColorId",
                        column: x => x.Clothes_ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_Color_Cookware_ColorId",
                        column: x => x.Cookware_ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_Color_Hammock_ColorId",
                        column: x => x.Hammock_ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_Color_KnifeMultitool_ColorId",
                        column: x => x.KnifeMultitool_ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_Color_Shoe_ColorId",
                        column: x => x.Shoe_ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_Color_SleepingBag_ColorId",
                        column: x => x.SleepingBag_ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_Color_SleepingPad_ColorId",
                        column: x => x.SleepingPad_ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_Color_Tarp_ColorId",
                        column: x => x.Tarp_ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_Color_TrekkingPole_ColorId",
                        column: x => x.TrekkingPole_ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_CookwareBrand_CookwareBrandId",
                        column: x => x.CookwareBrandId,
                        principalTable: "CookwareBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_CookwareMaterial_CookwareMaterialId",
                        column: x => x.CookwareMaterialId,
                        principalTable: "CookwareMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_CookwareType_CookwareTypeId",
                        column: x => x.CookwareTypeId,
                        principalTable: "CookwareType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_ElectronicsType_ElectronicsTypeId",
                        column: x => x.ElectronicsTypeId,
                        principalTable: "ElectronicsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_Gender_Shoe_GenderId",
                        column: x => x.Shoe_GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_Gender_SleepingBag_GenderId",
                        column: x => x.SleepingBag_GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_HammockBrand_HammockBrandId",
                        column: x => x.HammockBrandId,
                        principalTable: "HammockBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_KnifeMultitoolBrand_KnifeMultitoolBrandId",
                        column: x => x.KnifeMultitoolBrandId,
                        principalTable: "KnifeMultitoolBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_KnifeMultitoolType_KnifeMultitoolTypeId",
                        column: x => x.KnifeMultitoolTypeId,
                        principalTable: "KnifeMultitoolType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_LightingBrand_LightingBrandId",
                        column: x => x.LightingBrandId,
                        principalTable: "LightingBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_LightingType_LightingTypeId",
                        column: x => x.LightingTypeId,
                        principalTable: "LightingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_ShoeBrand_ShoeBrandId",
                        column: x => x.ShoeBrandId,
                        principalTable: "ShoeBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_ShoeSize_ShoeSizeId",
                        column: x => x.ShoeSizeId,
                        principalTable: "ShoeSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_ShoeType_ShoeTypeId",
                        column: x => x.ShoeTypeId,
                        principalTable: "ShoeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_SleepAcessoryType_SleepAcessoryTypeId",
                        column: x => x.SleepAcessoryTypeId,
                        principalTable: "SleepAcessoryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_SleepingBagBrand_SleepingBagBrandId",
                        column: x => x.SleepingBagBrandId,
                        principalTable: "SleepingBagBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_SleepingBagInsulationType_SleepingBagInsulat~",
                        column: x => x.SleepingBagInsulationTypeId,
                        principalTable: "SleepingBagInsulationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_SleepingBagSeason_SleepingBagSeasonId",
                        column: x => x.SleepingBagSeasonId,
                        principalTable: "SleepingBagSeason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_SleepingBagShape_SleepingBagShapeId",
                        column: x => x.SleepingBagShapeId,
                        principalTable: "SleepingBagShape",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_SleepingBagZipSide_SleepingBagZipSideId",
                        column: x => x.SleepingBagZipSideId,
                        principalTable: "SleepingBagZipSide",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_SleepingPadBrand_SleepingPadBrandId",
                        column: x => x.SleepingPadBrandId,
                        principalTable: "SleepingPadBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_SleepingPadType_SleepingPadTypeId",
                        column: x => x.SleepingPadTypeId,
                        principalTable: "SleepingPadType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_StateOfItem_StateOfItemId",
                        column: x => x.StateOfItemId,
                        principalTable: "StateOfItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_StoveBrand_StoveBrandId",
                        column: x => x.StoveBrandId,
                        principalTable: "StoveBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_StoveFuelType_StoveFuelTypeId",
                        column: x => x.StoveFuelTypeId,
                        principalTable: "StoveFuelType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_TarpBrand_TarpBrandId",
                        column: x => x.TarpBrandId,
                        principalTable: "TarpBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_TarpShape_TarpShapeId",
                        column: x => x.TarpShapeId,
                        principalTable: "TarpShape",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_TentBrand_TentBrandId",
                        column: x => x.TentBrandId,
                        principalTable: "TentBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_TrekkingPoleBrand_TrekkingPoleBrandId",
                        column: x => x.TrekkingPoleBrandId,
                        principalTable: "TrekkingPoleBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralListings_TrekkingPoleType_TrekkingPoleTypeId",
                        column: x => x.TrekkingPoleTypeId,
                        principalTable: "TrekkingPoleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "IX_GeneralListings_Clothes_ColorId",
                table: "GeneralListings",
                column: "Clothes_ColorId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralListings");

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
        }
    }
}
