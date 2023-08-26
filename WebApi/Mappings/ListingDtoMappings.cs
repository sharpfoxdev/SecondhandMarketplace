using AutoMapper;
using Domain.Entities.Listings;
using WebApi.ApiDtos.Listings.ListingDtos;

namespace WebApi.Mappings {
	public class ListingDtoMappings : Profile {
        public ListingDtoMappings()
        {
			CreateMap<BaseListing, CampingListingDto>().ReverseMap();
			CreateMap<CampingListing, CampingListingDto>().ReverseMap();

			CreateMap<Backpack, BackpackDto>().ReverseMap();
			CreateMap<Clothes, ClothesDto>().ReverseMap();

			CreateMap<Cooking, CookingDto>().ReverseMap();
			CreateMap<Cookware, CookwareDto>().ReverseMap();
			CreateMap<Stove, StoveDto>().ReverseMap();
			CreateMap<OtherCooking, OtherCookingDto>().ReverseMap();
			
			CreateMap<Gear, GearDto>().ReverseMap();
			CreateMap<Binoculars, BinocularsDto>().ReverseMap();
			CreateMap<Electronics, ElectronicsDto>().ReverseMap();
			CreateMap<KnifeMultitool, KnifeMultitoolDto>().ReverseMap();
			CreateMap<Lighting, LightingDto>().ReverseMap();
			CreateMap<TrekkingPole, TrekkingPoleDto>().ReverseMap();
			CreateMap<OtherGear, OtherGearDto>().ReverseMap();

			CreateMap<Shoe, ShoeDto>().ReverseMap();

			CreateMap<Sleeping, SleepingDto>().ReverseMap();
			CreateMap<Hammock, HammockDto>().ReverseMap();
			CreateMap<SleepAccessory, SleepAccessoryDto>().ReverseMap();
			CreateMap<SleepingBag, SleepingBagDto>().ReverseMap();
			CreateMap<SleepingPad, SleepingPadDto>().ReverseMap();
			CreateMap<Tarp, TarpDto>().ReverseMap();
			CreateMap<Tent, TentDto>().ReverseMap();
			CreateMap<OtherSleeping, OtherSleepingDto>().ReverseMap();
		}
	}
}
