using Application.Interfaces;
using Domain.Entities;

namespace WebApi.ApiDtos.Listings {
	public class CreateListingRequest {
		public decimal Price { get; set; }
		public Guid SellerId { get; set; }
		public Guid StateOfItemId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ReasonOfSale { get; set; }
		public string ListingImageUrl { get; set; }
		public Guid CategoryId { get; set; }
		public List<IAttributeSelection> AttributeSelections { get; set; }
	}
}
