using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeddatatohavemanytomanyrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AttributeGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeGroups", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentCategoryId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
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
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AttributeGroupId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attributes_AttributeGroups_AttributeGroupId",
                        column: x => x.AttributeGroupId,
                        principalTable: "AttributeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AttributeGroupCategory",
                columns: table => new
                {
                    AttributeGroupsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CategoriesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeGroupCategory", x => new { x.AttributeGroupsId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_AttributeGroupCategory_AttributeGroups_AttributeGroupsId",
                        column: x => x.AttributeGroupsId,
                        principalTable: "AttributeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeGroupCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SellerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StateOfItemId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReasonOfSale = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ListingImageUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsSold = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listings_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listings_StateOfItem_StateOfItemId",
                        column: x => x.StateOfItemId,
                        principalTable: "StateOfItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ListingListingAttribute",
                columns: table => new
                {
                    ListingsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SelectedAttributesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingListingAttribute", x => new { x.ListingsId, x.SelectedAttributesId });
                    table.ForeignKey(
                        name: "FK_ListingListingAttribute_Attributes_SelectedAttributesId",
                        column: x => x.SelectedAttributesId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListingListingAttribute_Listings_ListingsId",
                        column: x => x.ListingsId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AttributeGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("72697394-56b3-4ed8-851f-b74e28454616"), "BinocularsType" },
                    { new Guid("9091889f-ed33-48a0-979e-875968b305fe"), "BackpackBrand" },
                    { new Guid("e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3"), "BackpackType" }
                });

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "AttributeGroupId", "Name" },
                values: new object[,]
                {
                    { new Guid("13b902a9-c0e4-4799-80d8-56206eb1acc8"), new Guid("9091889f-ed33-48a0-979e-875968b305fe"), "Patizon" },
                    { new Guid("3f5fd110-e73f-46fe-bb92-3a8094e3cbcb"), new Guid("9091889f-ed33-48a0-979e-875968b305fe"), "Sir Joseph" },
                    { new Guid("4f53489e-90b3-43ad-b51c-aa65f301b984"), new Guid("9091889f-ed33-48a0-979e-875968b305fe"), "Prima" },
                    { new Guid("8dd8cbb6-03a9-4220-b343-d4c5a283283b"), new Guid("e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3"), "Batoh" },
                    { new Guid("b567cbd5-d49d-427d-a90f-1d94f8cd5c8e"), new Guid("72697394-56b3-4ed8-851f-b74e28454616"), "Monokulár" },
                    { new Guid("ba38e3c6-777c-4dbd-87bd-450206c7e49a"), new Guid("e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3"), "Sumka" },
                    { new Guid("c62d49f3-0294-4e9a-9411-5a392f719b76"), new Guid("72697394-56b3-4ed8-851f-b74e28454616"), "Binokulár" },
                    { new Guid("d882ac03-d93e-41c6-8503-2d2fd47acac5"), new Guid("e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3"), "Taška" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeGroupCategory_CategoriesId",
                table: "AttributeGroupCategory",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_AttributeGroupId",
                table: "Attributes",
                column: "AttributeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingListingAttribute_SelectedAttributesId",
                table: "ListingListingAttribute",
                column: "SelectedAttributesId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_CategoryId",
                table: "Listings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_StateOfItemId",
                table: "Listings",
                column: "StateOfItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeGroupCategory");

            migrationBuilder.DropTable(
                name: "ListingListingAttribute");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "AttributeGroups");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "StateOfItem");
        }
    }
}
