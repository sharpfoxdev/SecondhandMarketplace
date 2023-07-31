namespace Marketplace.API.Models.Domain {
	public class GeneralListing {
		public Guid Id { get; set; }
		public string Description { get; set; }
		public string ReasonOfSale { get; set; }
		public int RandomIntProperty { get; set; }
	}
}
