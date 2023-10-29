using Domain.Entities;

namespace WebApi.ApiDtos.Listings {
	public class UpdateListingRequest {
		public decimal Price { get; set; }
		public Guid StateOfItemId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ReasonOfSale { get; set; }
		public string ListingImageUrl { get; set; }
		public bool IsSold { get; set; }

		// TODO add possibility to change attribute selections
		// public List<IAttributeSelection> AttributeSelections { get; set; }
	}
}
