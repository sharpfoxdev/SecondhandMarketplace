using AutoMapper;
using Domain.Entities.Listings;
using WebApi.ApiDtos.Listings.CreateListing;

namespace WebApi.Mappings {
	public class CreateListingRequestMappings : Profile {
		public CreateListingRequestMappings() {
			CreateMap<BaseListing, CreateCampingListingRequest>().ReverseMap();
			CreateMap<CampingListing, CreateCampingListingRequest>().ReverseMap();
			CreateMap<Backpack, CreateBackpackRequest>().ReverseMap();
			CreateMap<Clothes, CreateClothesRequest>().ReverseMap();
			CreateMap<Cookware, CreateCookwareRequest>().ReverseMap();
			CreateMap<Stove, CreateStoveRequest>().ReverseMap();
			CreateMap<OtherCooking, CreateOtherCookingRequest>().ReverseMap();
			CreateMap<Binoculars, CreateBinocularsRequest>().ReverseMap();
			CreateMap<Electronics, CreateElectronicsRequest>().ReverseMap();
			CreateMap<KnifeMultitool, CreateKnifeMultitoolRequest>().ReverseMap();
			CreateMap<Lighting, CreateLightingRequest>().ReverseMap();
			CreateMap<TrekkingPole, CreateTrekkingPoleRequest>().ReverseMap();
			CreateMap<OtherGear, CreateOtherGearRequest>().ReverseMap();
			CreateMap<Shoe, CreateShoeRequest>().ReverseMap();
			CreateMap<Hammock, CreateHammockRequest>().ReverseMap();
			CreateMap<SleepAccessory, CreateSleepAccessoryRequest>().ReverseMap();
			CreateMap<SleepingBag, CreateSleepingBagRequest>().ReverseMap();
			CreateMap<SleepingPad, CreateSleepingPadRequest>().ReverseMap();
			CreateMap<Tarp, CreateTarpRequest>().ReverseMap();
			CreateMap<Tent, CreateTentRequest>().ReverseMap();
			CreateMap<OtherSleeping, CreateOtherSleepingRequest>().ReverseMap();
		}
	}
}
