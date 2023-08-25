namespace Domain.Entities.Listings
{
    public class Stove : Cooking
    {
        public StoveBrand StoveBrand { get; set; }
        public Guid StoveBrandId { get; set; }
        public StoveFuelType StoveFuelType { get; set; }
        public Guid StoveFuelTypeId { get; set; }

        public override void Update(BaseListing updatedListing)
        {
            base.Update(updatedListing);
            StoveBrandId = ((Stove)updatedListing).StoveBrandId;
            StoveFuelTypeId = ((Stove)updatedListing).StoveFuelTypeId;
        }
    }
}
