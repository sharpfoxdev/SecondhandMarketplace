using AutoMapper;
using Domain.Entities.Listings;
using WebApi.ApiDtos.Listings.CreateListing;

namespace WebApi.Mappings {
	public class CreateListingRequestMappings : Profile {
		public CreateListingRequestMappings() {
			CreateMap<BaseListing, CreateCampingListingRequest>().ReverseMap();
			CreateMap<CampingListing, CreateCampingListingRequest>().ReverseMap();
			CreateMap<Backpack, CreateBackpackRequest>().ReverseMap();
			CreateMap<Cookware, CreateCookwareRequest>().ReverseMap();
			CreateMap<Stove, CreateStoveRequest>().ReverseMap();
		}
	}
}
