using AutoMapper;
using Domain.Entities.Listings;
using WebApi.ApiDtos.Listings.ListingDtos;

namespace WebApi.Mappings {
	public class ListingDtoMappings : Profile {
        public ListingDtoMappings()
        {
			CreateMap<BaseListing, CampingListingDto>().ReverseMap();
			CreateMap<CampingListing, CampingListingDto>().ReverseMap();
			CreateMap<Cookware, CookwareDto>().ReverseMap();
		}
	}
}
