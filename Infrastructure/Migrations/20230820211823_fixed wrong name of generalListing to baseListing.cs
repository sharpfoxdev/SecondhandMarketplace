using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixedwrongnameofgeneralListingtobaseListing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_GeneralListings_Color_Clothes_ColorId",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneralListings",
                table: "GeneralListings");

            migrationBuilder.RenameTable(
                name: "GeneralListings",
                newName: "BaseListing");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_TrekkingPoleTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_TrekkingPoleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_TrekkingPoleBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_TrekkingPoleBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_TrekkingPole_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_TrekkingPole_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_TentBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_TentBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_TarpShapeId",
                table: "BaseListing",
                newName: "IX_BaseListing_TarpShapeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_TarpBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_TarpBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_Tarp_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_Tarp_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_StoveFuelTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_StoveFuelTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_StoveBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_StoveBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_StateOfItemId",
                table: "BaseListing",
                newName: "IX_BaseListing_StateOfItemId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_SleepingPadTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingPadTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_SleepingPadBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingPadBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_SleepingPad_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingPad_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_SleepingBagZipSideId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingBagZipSideId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_SleepingBagShapeId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingBagShapeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_SleepingBagSeasonId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingBagSeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_SleepingBagInsulationTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingBagInsulationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_SleepingBagBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingBagBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_SleepingBag_GenderId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingBag_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_SleepingBag_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingBag_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_SleepAcessoryTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepAcessoryTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_ShoeTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_ShoeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_ShoeSizeId",
                table: "BaseListing",
                newName: "IX_BaseListing_ShoeSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_ShoeBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_ShoeBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_Shoe_GenderId",
                table: "BaseListing",
                newName: "IX_BaseListing_Shoe_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_Shoe_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_Shoe_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_LightingTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_LightingTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_LightingBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_LightingBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_KnifeMultitoolTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_KnifeMultitoolTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_KnifeMultitoolBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_KnifeMultitoolBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_KnifeMultitool_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_KnifeMultitool_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_HammockBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_HammockBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_Hammock_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_Hammock_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_GenderId",
                table: "BaseListing",
                newName: "IX_BaseListing_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_ElectronicsTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_ElectronicsTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_CookwareTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_CookwareTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_CookwareMaterialId",
                table: "BaseListing",
                newName: "IX_BaseListing_CookwareMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_CookwareBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_CookwareBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_Cookware_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_Cookware_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_ClothesTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_ClothesTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_ClothesSizeId",
                table: "BaseListing",
                newName: "IX_BaseListing_ClothesSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_ClothesBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_ClothesBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_Clothes_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_Clothes_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_BinocularsTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_BinocularsTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_BackpackTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_BackpackTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralListings_BackpackBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_BackpackBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseListing",
                table: "BaseListing",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_BackpackBrand_BackpackBrandId",
                table: "BaseListing",
                column: "BackpackBrandId",
                principalTable: "BackpackBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_BackpackType_BackpackTypeId",
                table: "BaseListing",
                column: "BackpackTypeId",
                principalTable: "BackpackType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_BinocularsType_BinocularsTypeId",
                table: "BaseListing",
                column: "BinocularsTypeId",
                principalTable: "BinocularsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_ClothesBrand_ClothesBrandId",
                table: "BaseListing",
                column: "ClothesBrandId",
                principalTable: "ClothesBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_ClothesSize_ClothesSizeId",
                table: "BaseListing",
                column: "ClothesSizeId",
                principalTable: "ClothesSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_ClothesType_ClothesTypeId",
                table: "BaseListing",
                column: "ClothesTypeId",
                principalTable: "ClothesType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_Color_Clothes_ColorId",
                table: "BaseListing",
                column: "Clothes_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_Color_ColorId",
                table: "BaseListing",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_Color_Cookware_ColorId",
                table: "BaseListing",
                column: "Cookware_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_Color_Hammock_ColorId",
                table: "BaseListing",
                column: "Hammock_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_Color_KnifeMultitool_ColorId",
                table: "BaseListing",
                column: "KnifeMultitool_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_Color_Shoe_ColorId",
                table: "BaseListing",
                column: "Shoe_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_Color_SleepingBag_ColorId",
                table: "BaseListing",
                column: "SleepingBag_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_Color_SleepingPad_ColorId",
                table: "BaseListing",
                column: "SleepingPad_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_Color_Tarp_ColorId",
                table: "BaseListing",
                column: "Tarp_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_Color_TrekkingPole_ColorId",
                table: "BaseListing",
                column: "TrekkingPole_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_CookwareBrand_CookwareBrandId",
                table: "BaseListing",
                column: "CookwareBrandId",
                principalTable: "CookwareBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_CookwareMaterial_CookwareMaterialId",
                table: "BaseListing",
                column: "CookwareMaterialId",
                principalTable: "CookwareMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_CookwareType_CookwareTypeId",
                table: "BaseListing",
                column: "CookwareTypeId",
                principalTable: "CookwareType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_ElectronicsType_ElectronicsTypeId",
                table: "BaseListing",
                column: "ElectronicsTypeId",
                principalTable: "ElectronicsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_Gender_GenderId",
                table: "BaseListing",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_Gender_Shoe_GenderId",
                table: "BaseListing",
                column: "Shoe_GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_Gender_SleepingBag_GenderId",
                table: "BaseListing",
                column: "SleepingBag_GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_HammockBrand_HammockBrandId",
                table: "BaseListing",
                column: "HammockBrandId",
                principalTable: "HammockBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_KnifeMultitoolBrand_KnifeMultitoolBrandId",
                table: "BaseListing",
                column: "KnifeMultitoolBrandId",
                principalTable: "KnifeMultitoolBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_KnifeMultitoolType_KnifeMultitoolTypeId",
                table: "BaseListing",
                column: "KnifeMultitoolTypeId",
                principalTable: "KnifeMultitoolType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_LightingBrand_LightingBrandId",
                table: "BaseListing",
                column: "LightingBrandId",
                principalTable: "LightingBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_LightingType_LightingTypeId",
                table: "BaseListing",
                column: "LightingTypeId",
                principalTable: "LightingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_ShoeBrand_ShoeBrandId",
                table: "BaseListing",
                column: "ShoeBrandId",
                principalTable: "ShoeBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_ShoeSize_ShoeSizeId",
                table: "BaseListing",
                column: "ShoeSizeId",
                principalTable: "ShoeSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_ShoeType_ShoeTypeId",
                table: "BaseListing",
                column: "ShoeTypeId",
                principalTable: "ShoeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_SleepAcessoryType_SleepAcessoryTypeId",
                table: "BaseListing",
                column: "SleepAcessoryTypeId",
                principalTable: "SleepAcessoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_SleepingBagBrand_SleepingBagBrandId",
                table: "BaseListing",
                column: "SleepingBagBrandId",
                principalTable: "SleepingBagBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_SleepingBagInsulationType_SleepingBagInsulationT~",
                table: "BaseListing",
                column: "SleepingBagInsulationTypeId",
                principalTable: "SleepingBagInsulationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_SleepingBagSeason_SleepingBagSeasonId",
                table: "BaseListing",
                column: "SleepingBagSeasonId",
                principalTable: "SleepingBagSeason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_SleepingBagShape_SleepingBagShapeId",
                table: "BaseListing",
                column: "SleepingBagShapeId",
                principalTable: "SleepingBagShape",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_SleepingBagZipSide_SleepingBagZipSideId",
                table: "BaseListing",
                column: "SleepingBagZipSideId",
                principalTable: "SleepingBagZipSide",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_SleepingPadBrand_SleepingPadBrandId",
                table: "BaseListing",
                column: "SleepingPadBrandId",
                principalTable: "SleepingPadBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_SleepingPadType_SleepingPadTypeId",
                table: "BaseListing",
                column: "SleepingPadTypeId",
                principalTable: "SleepingPadType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_StateOfItem_StateOfItemId",
                table: "BaseListing",
                column: "StateOfItemId",
                principalTable: "StateOfItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_StoveBrand_StoveBrandId",
                table: "BaseListing",
                column: "StoveBrandId",
                principalTable: "StoveBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_StoveFuelType_StoveFuelTypeId",
                table: "BaseListing",
                column: "StoveFuelTypeId",
                principalTable: "StoveFuelType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_TarpBrand_TarpBrandId",
                table: "BaseListing",
                column: "TarpBrandId",
                principalTable: "TarpBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_TarpShape_TarpShapeId",
                table: "BaseListing",
                column: "TarpShapeId",
                principalTable: "TarpShape",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_TentBrand_TentBrandId",
                table: "BaseListing",
                column: "TentBrandId",
                principalTable: "TentBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_TrekkingPoleBrand_TrekkingPoleBrandId",
                table: "BaseListing",
                column: "TrekkingPoleBrandId",
                principalTable: "TrekkingPoleBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseListing_TrekkingPoleType_TrekkingPoleTypeId",
                table: "BaseListing",
                column: "TrekkingPoleTypeId",
                principalTable: "TrekkingPoleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_BackpackBrand_BackpackBrandId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_BackpackType_BackpackTypeId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_BinocularsType_BinocularsTypeId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_ClothesBrand_ClothesBrandId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_ClothesSize_ClothesSizeId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_ClothesType_ClothesTypeId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_Color_Clothes_ColorId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_Color_ColorId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_Color_Cookware_ColorId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_Color_Hammock_ColorId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_Color_KnifeMultitool_ColorId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_Color_Shoe_ColorId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_Color_SleepingBag_ColorId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_Color_SleepingPad_ColorId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_Color_Tarp_ColorId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_Color_TrekkingPole_ColorId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_CookwareBrand_CookwareBrandId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_CookwareMaterial_CookwareMaterialId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_CookwareType_CookwareTypeId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_ElectronicsType_ElectronicsTypeId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_Gender_GenderId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_Gender_Shoe_GenderId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_Gender_SleepingBag_GenderId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_HammockBrand_HammockBrandId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_KnifeMultitoolBrand_KnifeMultitoolBrandId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_KnifeMultitoolType_KnifeMultitoolTypeId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_LightingBrand_LightingBrandId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_LightingType_LightingTypeId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_ShoeBrand_ShoeBrandId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_ShoeSize_ShoeSizeId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_ShoeType_ShoeTypeId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_SleepAcessoryType_SleepAcessoryTypeId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_SleepingBagBrand_SleepingBagBrandId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_SleepingBagInsulationType_SleepingBagInsulationT~",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_SleepingBagSeason_SleepingBagSeasonId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_SleepingBagShape_SleepingBagShapeId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_SleepingBagZipSide_SleepingBagZipSideId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_SleepingPadBrand_SleepingPadBrandId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_SleepingPadType_SleepingPadTypeId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_StateOfItem_StateOfItemId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_StoveBrand_StoveBrandId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_StoveFuelType_StoveFuelTypeId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_TarpBrand_TarpBrandId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_TarpShape_TarpShapeId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_TentBrand_TentBrandId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_TrekkingPoleBrand_TrekkingPoleBrandId",
                table: "BaseListing");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseListing_TrekkingPoleType_TrekkingPoleTypeId",
                table: "BaseListing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseListing",
                table: "BaseListing");

            migrationBuilder.RenameTable(
                name: "BaseListing",
                newName: "GeneralListings");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_TrekkingPoleTypeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_TrekkingPoleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_TrekkingPoleBrandId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_TrekkingPoleBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_TrekkingPole_ColorId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_TrekkingPole_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_TentBrandId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_TentBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_TarpShapeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_TarpShapeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_TarpBrandId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_TarpBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_Tarp_ColorId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_Tarp_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_StoveFuelTypeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_StoveFuelTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_StoveBrandId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_StoveBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_StateOfItemId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_StateOfItemId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingPadTypeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_SleepingPadTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingPadBrandId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_SleepingPadBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingPad_ColorId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_SleepingPad_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingBagZipSideId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_SleepingBagZipSideId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingBagShapeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_SleepingBagShapeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingBagSeasonId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_SleepingBagSeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingBagInsulationTypeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_SleepingBagInsulationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingBagBrandId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_SleepingBagBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingBag_GenderId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_SleepingBag_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingBag_ColorId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_SleepingBag_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepAcessoryTypeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_SleepAcessoryTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_ShoeTypeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_ShoeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_ShoeSizeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_ShoeSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_ShoeBrandId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_ShoeBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_Shoe_GenderId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_Shoe_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_Shoe_ColorId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_Shoe_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_LightingTypeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_LightingTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_LightingBrandId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_LightingBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_KnifeMultitoolTypeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_KnifeMultitoolTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_KnifeMultitoolBrandId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_KnifeMultitoolBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_KnifeMultitool_ColorId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_KnifeMultitool_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_HammockBrandId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_HammockBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_Hammock_ColorId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_Hammock_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_GenderId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_ElectronicsTypeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_ElectronicsTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_CookwareTypeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_CookwareTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_CookwareMaterialId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_CookwareMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_CookwareBrandId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_CookwareBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_Cookware_ColorId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_Cookware_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_ColorId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_ClothesTypeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_ClothesTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_ClothesSizeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_ClothesSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_ClothesBrandId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_ClothesBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_Clothes_ColorId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_Clothes_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_BinocularsTypeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_BinocularsTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_BackpackTypeId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_BackpackTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_BackpackBrandId",
                table: "GeneralListings",
                newName: "IX_GeneralListings_BackpackBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneralListings",
                table: "GeneralListings",
                column: "Id");

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
                name: "FK_GeneralListings_Color_Clothes_ColorId",
                table: "GeneralListings",
                column: "Clothes_ColorId",
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
        }
    }
}
