using Application.Interfaces;
using Domain.Entities;

namespace WebApi.ApiDtos.Listings {
	/// <summary>
	/// For adding pictures, use different request. This is only for the listing itself
	/// </summary>
	public class CreateListingRequest {
		public decimal Price { get; set; }
		public Guid SellerId { get; set; }
		public Guid StateOfItemId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ReasonOfSale { get; set; }
		public Guid CategoryId { get; set; }
		public List<AttributeSelectionDto> AttributeSelections { get; set; }
	}
}
