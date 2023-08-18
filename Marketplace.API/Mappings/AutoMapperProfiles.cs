using AutoMapper;
using Marketplace.API.Models.Domain.Categories;
using Marketplace.API.Models.Domain.Categories.Gear.Electronics;
using Marketplace.API.Models.DTO.AddListing;

namespace Marketplace.API.Mappings {
	public class AutoMapperProfiles : Profile {
		public AutoMapperProfiles() {
			CreateMap<ListingGeneral, CreateListingCampingDto>().ReverseMap();
			CreateMap<ListingCamping, CreateListingCampingDto>().ReverseMap();
			CreateMap<Electronics, CreateElectronicsListingDto>().ReverseMap();
		}
	}
}
