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
			CreateMap<ListingAttribute, ListingAttributeDto>().ReverseMap();
			CreateMap<Listing, ListingDto>().ReverseMap();
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<AttributeGroup, AttributeGroupDto>().ReverseMap();
			CreateMap<StateOfItem, StateOfItemDto>().ReverseMap();
			CreateMap<Image, ImageDto>().ReverseMap();

			// Mapping between domain and Create Request Dtos
			CreateMap<ListingAttribute, CreateListingAttributeRequest>().ReverseMap();
			CreateMap<Listing, CreateListingRequest>().ReverseMap();
			CreateMap<Category, CreateCategoryRequest>().ReverseMap();
			CreateMap<AttributeGroup, CreateAttributeGroupRequest>().ReverseMap();
			CreateMap<ListingAttribute, CreateListingAttributeInsideGroupRequest>().ReverseMap();

			// Mapping between domain and Update Request Dtos
			CreateMap<ListingAttribute, UpdateListingAttributeRequest>().ReverseMap();
			CreateMap<Listing, UpdateListingRequest>().ReverseMap();
			CreateMap<Category, UpdateCategoryRequest>().ReverseMap();
			CreateMap<AttributeGroup, UpdateAttributeGroupRequest>().ReverseMap();
		}

	}
}
