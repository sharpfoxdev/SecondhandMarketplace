using Marketplace.API.Models.Domain.Categories.CommonProperties;
using Marketplace.API.Models.Domain.Users;

namespace Marketplace.API.Models.DTO.AddListing {
	public class CreateListingCampingDto {
		public decimal Price { get; set; }
		public Guid SellerId { get; set; }
		public Guid StateOfItemId { get; set; }
		public string Description { get; set; }
		public string ReasonOfSale { get; set; }
		/*public DateTime DateUploaded { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public DateTime DateSold { get; set; }*/
		// maybe redundant, since we have the date of selling
		public string ListingImageUrl { get; set; }
		public bool Ultralight { get; set; }
		public float? Weight { get; set; }
	}
}
