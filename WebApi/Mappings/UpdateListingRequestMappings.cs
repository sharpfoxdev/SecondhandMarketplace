using AutoMapper;
using Domain.Entities.Listings;
using WebApi.ApiDtos.Listings.UpdateListing;

namespace WebApi.Mappings {
	public class UpdateListingRequestMappings : Profile {
        public UpdateListingRequestMappings()
        {
			CreateMap<BaseListing, UpdateCampingListingRequest>().ReverseMap();
			CreateMap<CampingListing, UpdateCampingListingRequest>().ReverseMap();
			CreateMap<Backpack, UpdateBackpackRequest>().ReverseMap();
			CreateMap<Clothes, UpdateClothesRequest>().ReverseMap();
			CreateMap<Cookware, UpdateCookwareRequest>().ReverseMap();
			CreateMap<Stove, UpdateStoveRequest>().ReverseMap();
			CreateMap<OtherCooking, UpdateOtherCookingRequest>().ReverseMap();
			CreateMap<Binoculars, UpdateBinocularsRequest>().ReverseMap();
			CreateMap<Electronics, UpdateElectronicsRequest>().ReverseMap();
			CreateMap<KnifeMultitool, UpdateKnifeMultitoolRequest>().ReverseMap();
			CreateMap<Lighting, UpdateLightingRequest>().ReverseMap();
			CreateMap<TrekkingPole, UpdateTrekkingPoleRequest>().ReverseMap();
			CreateMap<OtherGear,  UpdateOtherGearRequest>().ReverseMap();
			CreateMap<Shoe,  UpdateShoeRequest>().ReverseMap();
			CreateMap<Hammock,  UpdateHammockRequest>().ReverseMap();
			CreateMap<SleepAccessory,  UpdateSleepAccessoryRequest>().ReverseMap();
			CreateMap<SleepingBag,  UpdateSleepingBagRequest>().ReverseMap();
			CreateMap<SleepingPad,  UpdateSleepingPadRequest>().ReverseMap();
			CreateMap<Tarp, UpdateTarpRequest>().ReverseMap();
			CreateMap<Tent,  UpdateTentRequest>().ReverseMap();
			CreateMap<OtherSleeping, UpdateOtherSleepingRequest>().ReverseMap();

		}

	}
}
