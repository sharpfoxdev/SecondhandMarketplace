namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateCampingListingRequest
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }

        //public UserProfile Seller { get; set; }
        public Guid SellerId { get; set; }
        public Guid StateOfItemId { get; set; }

        public string Description { get; set; }
        public string ReasonOfSale { get; set; }
        public string ListingImageUrl { get; set; }
        public bool Ultralight { get; set; }
        public float? Weight { get; set; }
    }
}
