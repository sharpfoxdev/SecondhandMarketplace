using Domain.Entities;
using WebApi.ApiDtos.Categories;
using WebApi.ApiDtos.Images;
using WebApi.ApiDtos.ListingPropertyValues;
using WebApi.ApiDtos.StateOfItem;

namespace WebApi.ApiDtos.Listings
{
    public class ListingDto
    {
		public Guid Id { get; set; }
		public decimal Price { get; set; }
		public Guid SellerId { get; set; }
		public StateOfItemDto StateOfItem { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ReasonOfSale { get; set; }
		public bool IsSold { get; set; }
		public CategoryDto Category { get; set; }
		public List<ListingPropertyValueDto> SelectedListingPropertyValues { get; set; }
		public List<ImageDto> Images { get; set; }

	}
}
