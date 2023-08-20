using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renamesoncemore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "Listings");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_TrekkingPoleTypeId",
                table: "Listings",
                newName: "IX_Listings_TrekkingPoleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_TrekkingPoleBrandId",
                table: "Listings",
                newName: "IX_Listings_TrekkingPoleBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_TrekkingPole_ColorId",
                table: "Listings",
                newName: "IX_Listings_TrekkingPole_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_TentBrandId",
                table: "Listings",
                newName: "IX_Listings_TentBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_TarpShapeId",
                table: "Listings",
                newName: "IX_Listings_TarpShapeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_TarpBrandId",
                table: "Listings",
                newName: "IX_Listings_TarpBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_Tarp_ColorId",
                table: "Listings",
                newName: "IX_Listings_Tarp_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_StoveFuelTypeId",
                table: "Listings",
                newName: "IX_Listings_StoveFuelTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_StoveBrandId",
                table: "Listings",
                newName: "IX_Listings_StoveBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_StateOfItemId",
                table: "Listings",
                newName: "IX_Listings_StateOfItemId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingPadTypeId",
                table: "Listings",
                newName: "IX_Listings_SleepingPadTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingPadBrandId",
                table: "Listings",
                newName: "IX_Listings_SleepingPadBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingPad_ColorId",
                table: "Listings",
                newName: "IX_Listings_SleepingPad_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingBagZipSideId",
                table: "Listings",
                newName: "IX_Listings_SleepingBagZipSideId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingBagShapeId",
                table: "Listings",
                newName: "IX_Listings_SleepingBagShapeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingBagSeasonId",
                table: "Listings",
                newName: "IX_Listings_SleepingBagSeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingBagInsulationTypeId",
                table: "Listings",
                newName: "IX_Listings_SleepingBagInsulationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingBagBrandId",
                table: "Listings",
                newName: "IX_Listings_SleepingBagBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingBag_GenderId",
                table: "Listings",
                newName: "IX_Listings_SleepingBag_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepingBag_ColorId",
                table: "Listings",
                newName: "IX_Listings_SleepingBag_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_SleepAcessoryTypeId",
                table: "Listings",
                newName: "IX_Listings_SleepAcessoryTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_ShoeTypeId",
                table: "Listings",
                newName: "IX_Listings_ShoeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_ShoeSizeId",
                table: "Listings",
                newName: "IX_Listings_ShoeSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_ShoeBrandId",
                table: "Listings",
                newName: "IX_Listings_ShoeBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_Shoe_GenderId",
                table: "Listings",
                newName: "IX_Listings_Shoe_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_Shoe_ColorId",
                table: "Listings",
                newName: "IX_Listings_Shoe_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_LightingTypeId",
                table: "Listings",
                newName: "IX_Listings_LightingTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_LightingBrandId",
                table: "Listings",
                newName: "IX_Listings_LightingBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_KnifeMultitoolTypeId",
                table: "Listings",
                newName: "IX_Listings_KnifeMultitoolTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_KnifeMultitoolBrandId",
                table: "Listings",
                newName: "IX_Listings_KnifeMultitoolBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_KnifeMultitool_ColorId",
                table: "Listings",
                newName: "IX_Listings_KnifeMultitool_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_HammockBrandId",
                table: "Listings",
                newName: "IX_Listings_HammockBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_Hammock_ColorId",
                table: "Listings",
                newName: "IX_Listings_Hammock_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_GenderId",
                table: "Listings",
                newName: "IX_Listings_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_ElectronicsTypeId",
                table: "Listings",
                newName: "IX_Listings_ElectronicsTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_CookwareTypeId",
                table: "Listings",
                newName: "IX_Listings_CookwareTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_CookwareMaterialId",
                table: "Listings",
                newName: "IX_Listings_CookwareMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_CookwareBrandId",
                table: "Listings",
                newName: "IX_Listings_CookwareBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_Cookware_ColorId",
                table: "Listings",
                newName: "IX_Listings_Cookware_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_ColorId",
                table: "Listings",
                newName: "IX_Listings_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_ClothesTypeId",
                table: "Listings",
                newName: "IX_Listings_ClothesTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_ClothesSizeId",
                table: "Listings",
                newName: "IX_Listings_ClothesSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_ClothesBrandId",
                table: "Listings",
                newName: "IX_Listings_ClothesBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_Clothes_ColorId",
                table: "Listings",
                newName: "IX_Listings_Clothes_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_BinocularsTypeId",
                table: "Listings",
                newName: "IX_Listings_BinocularsTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_BackpackTypeId",
                table: "Listings",
                newName: "IX_Listings_BackpackTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseListing_BackpackBrandId",
                table: "Listings",
                newName: "IX_Listings_BackpackBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listings",
                table: "Listings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_BackpackBrand_BackpackBrandId",
                table: "Listings",
                column: "BackpackBrandId",
                principalTable: "BackpackBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_BackpackType_BackpackTypeId",
                table: "Listings",
                column: "BackpackTypeId",
                principalTable: "BackpackType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_BinocularsType_BinocularsTypeId",
                table: "Listings",
                column: "BinocularsTypeId",
                principalTable: "BinocularsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_ClothesBrand_ClothesBrandId",
                table: "Listings",
                column: "ClothesBrandId",
                principalTable: "ClothesBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_ClothesSize_ClothesSizeId",
                table: "Listings",
                column: "ClothesSizeId",
                principalTable: "ClothesSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_ClothesType_ClothesTypeId",
                table: "Listings",
                column: "ClothesTypeId",
                principalTable: "ClothesType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Color_Clothes_ColorId",
                table: "Listings",
                column: "Clothes_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Color_ColorId",
                table: "Listings",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Color_Cookware_ColorId",
                table: "Listings",
                column: "Cookware_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Color_Hammock_ColorId",
                table: "Listings",
                column: "Hammock_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Color_KnifeMultitool_ColorId",
                table: "Listings",
                column: "KnifeMultitool_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Color_Shoe_ColorId",
                table: "Listings",
                column: "Shoe_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Color_SleepingBag_ColorId",
                table: "Listings",
                column: "SleepingBag_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Color_SleepingPad_ColorId",
                table: "Listings",
                column: "SleepingPad_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Color_Tarp_ColorId",
                table: "Listings",
                column: "Tarp_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Color_TrekkingPole_ColorId",
                table: "Listings",
                column: "TrekkingPole_ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_CookwareBrand_CookwareBrandId",
                table: "Listings",
                column: "CookwareBrandId",
                principalTable: "CookwareBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_CookwareMaterial_CookwareMaterialId",
                table: "Listings",
                column: "CookwareMaterialId",
                principalTable: "CookwareMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_CookwareType_CookwareTypeId",
                table: "Listings",
                column: "CookwareTypeId",
                principalTable: "CookwareType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_ElectronicsType_ElectronicsTypeId",
                table: "Listings",
                column: "ElectronicsTypeId",
                principalTable: "ElectronicsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Gender_GenderId",
                table: "Listings",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Gender_Shoe_GenderId",
                table: "Listings",
                column: "Shoe_GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Gender_SleepingBag_GenderId",
                table: "Listings",
                column: "SleepingBag_GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_HammockBrand_HammockBrandId",
                table: "Listings",
                column: "HammockBrandId",
                principalTable: "HammockBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_KnifeMultitoolBrand_KnifeMultitoolBrandId",
                table: "Listings",
                column: "KnifeMultitoolBrandId",
                principalTable: "KnifeMultitoolBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_KnifeMultitoolType_KnifeMultitoolTypeId",
                table: "Listings",
                column: "KnifeMultitoolTypeId",
                principalTable: "KnifeMultitoolType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_LightingBrand_LightingBrandId",
                table: "Listings",
                column: "LightingBrandId",
                principalTable: "LightingBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_LightingType_LightingTypeId",
                table: "Listings",
                column: "LightingTypeId",
                principalTable: "LightingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_ShoeBrand_ShoeBrandId",
                table: "Listings",
                column: "ShoeBrandId",
                principalTable: "ShoeBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_ShoeSize_ShoeSizeId",
                table: "Listings",
                column: "ShoeSizeId",
                principalTable: "ShoeSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_ShoeType_ShoeTypeId",
                table: "Listings",
                column: "ShoeTypeId",
                principalTable: "ShoeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_SleepAcessoryType_SleepAcessoryTypeId",
                table: "Listings",
                column: "SleepAcessoryTypeId",
                principalTable: "SleepAcessoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_SleepingBagBrand_SleepingBagBrandId",
                table: "Listings",
                column: "SleepingBagBrandId",
                principalTable: "SleepingBagBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_SleepingBagInsulationType_SleepingBagInsulationType~",
                table: "Listings",
                column: "SleepingBagInsulationTypeId",
                principalTable: "SleepingBagInsulationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_SleepingBagSeason_SleepingBagSeasonId",
                table: "Listings",
                column: "SleepingBagSeasonId",
                principalTable: "SleepingBagSeason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_SleepingBagShape_SleepingBagShapeId",
                table: "Listings",
                column: "SleepingBagShapeId",
                principalTable: "SleepingBagShape",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_SleepingBagZipSide_SleepingBagZipSideId",
                table: "Listings",
                column: "SleepingBagZipSideId",
                principalTable: "SleepingBagZipSide",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_SleepingPadBrand_SleepingPadBrandId",
                table: "Listings",
                column: "SleepingPadBrandId",
                principalTable: "SleepingPadBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_SleepingPadType_SleepingPadTypeId",
                table: "Listings",
                column: "SleepingPadTypeId",
                principalTable: "SleepingPadType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_StateOfItem_StateOfItemId",
                table: "Listings",
                column: "StateOfItemId",
                principalTable: "StateOfItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_StoveBrand_StoveBrandId",
                table: "Listings",
                column: "StoveBrandId",
                principalTable: "StoveBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_StoveFuelType_StoveFuelTypeId",
                table: "Listings",
                column: "StoveFuelTypeId",
                principalTable: "StoveFuelType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_TarpBrand_TarpBrandId",
                table: "Listings",
                column: "TarpBrandId",
                principalTable: "TarpBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_TarpShape_TarpShapeId",
                table: "Listings",
                column: "TarpShapeId",
                principalTable: "TarpShape",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_TentBrand_TentBrandId",
                table: "Listings",
                column: "TentBrandId",
                principalTable: "TentBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_TrekkingPoleBrand_TrekkingPoleBrandId",
                table: "Listings",
                column: "TrekkingPoleBrandId",
                principalTable: "TrekkingPoleBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_TrekkingPoleType_TrekkingPoleTypeId",
                table: "Listings",
                column: "TrekkingPoleTypeId",
                principalTable: "TrekkingPoleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_BackpackBrand_BackpackBrandId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_BackpackType_BackpackTypeId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_BinocularsType_BinocularsTypeId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_ClothesBrand_ClothesBrandId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_ClothesSize_ClothesSizeId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_ClothesType_ClothesTypeId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Color_Clothes_ColorId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Color_ColorId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Color_Cookware_ColorId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Color_Hammock_ColorId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Color_KnifeMultitool_ColorId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Color_Shoe_ColorId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Color_SleepingBag_ColorId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Color_SleepingPad_ColorId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Color_Tarp_ColorId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Color_TrekkingPole_ColorId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_CookwareBrand_CookwareBrandId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_CookwareMaterial_CookwareMaterialId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_CookwareType_CookwareTypeId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_ElectronicsType_ElectronicsTypeId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Gender_GenderId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Gender_Shoe_GenderId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Gender_SleepingBag_GenderId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_HammockBrand_HammockBrandId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_KnifeMultitoolBrand_KnifeMultitoolBrandId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_KnifeMultitoolType_KnifeMultitoolTypeId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_LightingBrand_LightingBrandId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_LightingType_LightingTypeId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_ShoeBrand_ShoeBrandId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_ShoeSize_ShoeSizeId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_ShoeType_ShoeTypeId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_SleepAcessoryType_SleepAcessoryTypeId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_SleepingBagBrand_SleepingBagBrandId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_SleepingBagInsulationType_SleepingBagInsulationType~",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_SleepingBagSeason_SleepingBagSeasonId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_SleepingBagShape_SleepingBagShapeId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_SleepingBagZipSide_SleepingBagZipSideId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_SleepingPadBrand_SleepingPadBrandId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_SleepingPadType_SleepingPadTypeId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_StateOfItem_StateOfItemId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_StoveBrand_StoveBrandId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_StoveFuelType_StoveFuelTypeId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_TarpBrand_TarpBrandId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_TarpShape_TarpShapeId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_TentBrand_TentBrandId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_TrekkingPoleBrand_TrekkingPoleBrandId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_TrekkingPoleType_TrekkingPoleTypeId",
                table: "Listings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Listings",
                table: "Listings");

            migrationBuilder.RenameTable(
                name: "Listings",
                newName: "BaseListing");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_TrekkingPoleTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_TrekkingPoleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_TrekkingPoleBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_TrekkingPoleBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_TrekkingPole_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_TrekkingPole_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_TentBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_TentBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_TarpShapeId",
                table: "BaseListing",
                newName: "IX_BaseListing_TarpShapeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_TarpBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_TarpBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_Tarp_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_Tarp_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_StoveFuelTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_StoveFuelTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_StoveBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_StoveBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_StateOfItemId",
                table: "BaseListing",
                newName: "IX_BaseListing_StateOfItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_SleepingPadTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingPadTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_SleepingPadBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingPadBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_SleepingPad_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingPad_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_SleepingBagZipSideId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingBagZipSideId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_SleepingBagShapeId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingBagShapeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_SleepingBagSeasonId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingBagSeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_SleepingBagInsulationTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingBagInsulationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_SleepingBagBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingBagBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_SleepingBag_GenderId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingBag_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_SleepingBag_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepingBag_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_SleepAcessoryTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_SleepAcessoryTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_ShoeTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_ShoeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_ShoeSizeId",
                table: "BaseListing",
                newName: "IX_BaseListing_ShoeSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_ShoeBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_ShoeBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_Shoe_GenderId",
                table: "BaseListing",
                newName: "IX_BaseListing_Shoe_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_Shoe_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_Shoe_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_LightingTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_LightingTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_LightingBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_LightingBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_KnifeMultitoolTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_KnifeMultitoolTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_KnifeMultitoolBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_KnifeMultitoolBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_KnifeMultitool_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_KnifeMultitool_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_HammockBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_HammockBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_Hammock_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_Hammock_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_GenderId",
                table: "BaseListing",
                newName: "IX_BaseListing_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_ElectronicsTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_ElectronicsTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_CookwareTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_CookwareTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_CookwareMaterialId",
                table: "BaseListing",
                newName: "IX_BaseListing_CookwareMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_CookwareBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_CookwareBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_Cookware_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_Cookware_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_ClothesTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_ClothesTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_ClothesSizeId",
                table: "BaseListing",
                newName: "IX_BaseListing_ClothesSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_ClothesBrandId",
                table: "BaseListing",
                newName: "IX_BaseListing_ClothesBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_Clothes_ColorId",
                table: "BaseListing",
                newName: "IX_BaseListing_Clothes_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_BinocularsTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_BinocularsTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_BackpackTypeId",
                table: "BaseListing",
                newName: "IX_BaseListing_BackpackTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_BackpackBrandId",
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
    }
}
