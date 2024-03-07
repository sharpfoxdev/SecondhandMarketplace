using AutoMapper;
using Domain.Entities;
using WebApi.ApiDtos.AttributeGroups;
using WebApi.ApiDtos.Categories;
using WebApi.ApiDtos.Image;
using WebApi.ApiDtos.ListingAttribute;
using WebApi.ApiDtos.Listings;
using WebApi.ApiDtos.StateOfItem;

namespace WebApi.Mappings {
	/// <summary>
	/// AutoMapper mappings for Dtos, Domain Entities, Update and Create Request Dtos. 
	/// Further documentation at <see cref="https://docs.automapper.org/en/latest/Getting-started.html"/>
	/// </summary>
	public class Mappings : Profile {
		public Mappings() {
			// TODO PUT INTO METHODS

			// Mapping between Domain and return Dtos
			CreateMap<ListingPropertyValue, ListingAttributeDto>().ReverseMap();
			CreateMap<Listing, ListingDto>().ReverseMap();
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<ListingProperty, AttributeGroupDto>().ReverseMap();
			CreateMap<StateOfItem, StateOfItemDto>().ReverseMap();
			CreateMap<Image, ImageDto>().ReverseMap();

			// Mapping between domain and Create Request Dtos
			CreateMap<ListingPropertyValue, CreateListingAttributeRequest>().ReverseMap();
			CreateMap<Listing, CreateListingRequest>().ReverseMap();
			CreateMap<Category, CreateCategoryRequest>().ReverseMap();
			CreateMap<ListingProperty, CreateAttributeGroupRequest>().ReverseMap();
			CreateMap<ListingPropertyValue, CreateListingAttributeInsideGroupRequest>().ReverseMap();

			// Mapping between domain and Update Request Dtos
			CreateMap<ListingPropertyValue, UpdateListingAttributeRequest>().ReverseMap();
			CreateMap<Listing, UpdateListingRequest>().ReverseMap();
			CreateMap<Category, UpdateCategoryRequest>().ReverseMap();
			CreateMap<ListingProperty, UpdateAttributeGroupRequest>().ReverseMap();
		}

	}
}
