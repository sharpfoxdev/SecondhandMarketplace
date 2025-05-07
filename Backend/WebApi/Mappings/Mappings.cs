using AutoMapper;
using Domain.Entities;
using WebApi.ApiDtos.ListingProperties;
using WebApi.ApiDtos.Categories;
using WebApi.ApiDtos.Images;
using WebApi.ApiDtos.ListingPropertyValues;
using WebApi.ApiDtos.Listings;
using WebApi.ApiDtos.StateOfItem;
using Application.Filters;
using WebApi.ApiDtos.Messages;
using WebApi.ApiDtos.Conversations;

namespace WebApi.Mappings {
	/// <summary>
	/// AutoMapper mappings for Dtos, Domain Entities, Update and Create Request Dtos. 
	/// Further documentation at <see cref="https://docs.automapper.org/en/latest/Getting-started.html"/>
	/// </summary>
	public class Mappings : Profile {
		public Mappings() {
			// TODO PUT INTO METHODS

			// Mapping between Domain and return Dtos
			CreateMap<ListingPropertyValue, ListingPropertyValueDto>().ReverseMap();
			CreateMap<ListingPropertyValue, ListingPropertyValueDetailDto>().ReverseMap();
			CreateMap<Listing, ListingDto>().ReverseMap();
			CreateMap<Listing, ListingDetailDto>().ReverseMap();
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<Category, CategoryDetailDto>().ReverseMap();
			CreateMap<Category, CategoryHierarchyDto>().ReverseMap();
			CreateMap<ListingProperty, ListingPropertyDto>().ReverseMap();
			CreateMap<ListingProperty, ListingPropertyDetailDto>().ReverseMap();
			CreateMap<StateOfItem, StateOfItemDto>().ReverseMap();
			CreateMap<Image, ImageDto>().ReverseMap();
			CreateMap<ListingFilter, ListingFilterDto>().ReverseMap();
			CreateMap<Message, MessageDto>().ReverseMap();
			CreateMap<Conversation, ConversationDto>().ReverseMap();
			CreateMap<ConversationParticipant, ConversationParticipantDto>().ReverseMap();

			// Mapping between domain and Create Request Dtos
			CreateMap<ListingPropertyValue, CreateListingPropertyValueRequest>().ReverseMap();
			CreateMap<Listing, CreateListingRequest>().ReverseMap();
			CreateMap<Category, CreateCategoryRequest>().ReverseMap();
			CreateMap<ListingProperty, CreateListingPropertyRequest>().ReverseMap();
			CreateMap<ListingPropertyValue, CreatePropertyValueInsidePropertyRequest>().ReverseMap();

			// Mapping between domain and Update Request Dtos
			CreateMap<ListingPropertyValue, UpdateListingPropertyValueRequest>().ReverseMap();
			CreateMap<Listing, UpdateListingRequest>().ReverseMap();
			CreateMap<Category, UpdateCategoryRequest>().ReverseMap();
			CreateMap<ListingProperty, UpdateListingPropertyRequest>().ReverseMap();
		}

	}
}
