namespace Marketplace.API.Models.Domain {

	/// <summary>
	/// The root of the listing/product hierarchy, properties are the same for any
	/// type of secondand marketplace. By making childen from this class,
	/// you create specialized categories with their specific properties,
	/// on which they can be filtered. 
	/// </summary>
	public class ListingGeneral {
		public Guid Id { get; set; }
		public decimal Price { get; set; }

		public UserProfile Seller { get; set; }
		public Guid SellerId { get; set; }

		public StateOfItem StateOfItem { get; set; }
		public Guid StateOfItemId { get; set; }

		public string Description { get; set; }
		public string ReasonOfSale { get; set; }

		public DateTime DateUploaded { get; set; }
		public DateTime DateLastUpdated { get; set; }
		public DateTime DateSold { get; set; }

		// maybe redundant, since we have the date of selling
		public bool IsSold { get; set; }
		// TODO LIST OF PICTURES



	}
}
