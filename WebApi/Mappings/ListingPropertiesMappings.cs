using AutoMapper;
using Domain.Entities.Listings;
using WebApi.ApiDtos.ListingsProperties;

namespace WebApi.Mappings
{
    public class ListingPropertiesMappings : Profile {
		public ListingPropertiesMappings() {
			// backpack
			CreateMap<BackpackBrandDto, BackpackBrand>().ReverseMap();
			CreateMap<BackpackTypeDto, BackpackType>().ReverseMap();

			// clothes
			CreateMap<ClothesBrandDto, ClothesBrand>().ReverseMap();
			CreateMap<ClothesSizeDto, ClothesSize>().ReverseMap();
			CreateMap<ClothesTypeDto, ClothesType>().ReverseMap();

			// general
			CreateMap<ColorDto, Color>().ReverseMap();
			CreateMap<GenderDto, Gender>().ReverseMap();
			CreateMap<StateOfItemDto, StateOfItem>().ReverseMap();

			// cooking
			// cookware
			CreateMap<CookwareBrandDto, CookwareBrand>().ReverseMap();
			CreateMap<CookwareMaterialDto, CookwareMaterial>().ReverseMap();
			CreateMap<CookwareTypeDto, CookwareType>().ReverseMap();
			// stoves
			CreateMap<StoveBrandDto, StoveBrand>().ReverseMap();
			CreateMap<StoveFuelTypeDto, StoveFuelType>().ReverseMap();
			
			// gear
			// binoculars
			CreateMap<BinocularsTypeDto, BinocularsType>().ReverseMap();
			// electronics
			CreateMap<ElectronicsTypeDto, ElectronicsType>().ReverseMap();
			// knifemultitool
			CreateMap<KnifeMultitoolBrandDto, KnifeMultitoolBrand>().ReverseMap();
			CreateMap<KnifeMultitoolTypeDto, KnifeMultitoolType>().ReverseMap();
			// lighting
			CreateMap<LightingBrandDto, LightingBrand>().ReverseMap();
			CreateMap<LightingTypeDto, LightingType>().ReverseMap();
			// trekking poles
			CreateMap<TrekkingPoleBrandDto, TrekkingPoleBrand>().ReverseMap();
			CreateMap<TrekkingPoleTypeDto, TrekkingPoleType>().ReverseMap();

			// shoes
			CreateMap<ShoeBrandDto, ShoeBrand>().ReverseMap();
			CreateMap<ShoeSizeDto, ShoeSize>().ReverseMap();
			CreateMap<ShoeTypeDto, ShoeType>().ReverseMap();

			// Sleeping
			// Hammocks
			CreateMap<HammockBrandDto, HammockBrand>().ReverseMap();
			// Sleep accessory
			CreateMap<SleepAccessoryTypeDto, SleepAccessoryType>().ReverseMap();
			// Sleeping bag
			CreateMap<SleepingBagBrandDto, SleepingBagBrand>().ReverseMap();
			CreateMap<SleepingBagInsulationTypeDto, SleepingBagInsulationType>().ReverseMap();
			CreateMap<SleepingBagSeasonDto,  SleepingBagSeason>().ReverseMap();
			CreateMap<SleepingBagShapeDto,  SleepingBagShape>().ReverseMap();
			CreateMap<SleepingBagZipSideDto,  SleepingBagZipSide>().ReverseMap();
			// Sleeping pad
			CreateMap<SleepingPadBrandDto, SleepingPadBrand>().ReverseMap();
			CreateMap<SleepingPadTypeDto, SleepingPadType>().ReverseMap();
			// Tarp
			CreateMap<TarpBrandDto, TarpBrand>().ReverseMap();
			CreateMap<TarpShapeDto, TarpShape>().ReverseMap();
			// Tent
			CreateMap<TentBrandDto, TentBrand>().ReverseMap();
		}
	}
}
