namespace Domain.Entities.Listings
{
    public class Tent : Sleeping
    {
        public int NumberOfPeople { get; set; }
        public int NumberOfDoors { get; set; }
        public TentBrand TentBrand { get; set; }
        public Guid TentBrandId { get; set; }

        public override void Update(BaseListing updatedListing)
        {
            base.Update(updatedListing);
            NumberOfPeople = ((Tent)updatedListing).NumberOfPeople;
            NumberOfDoors = ((Tent)updatedListing).NumberOfDoors;
            TentBrandId = ((Tent)updatedListing).TentBrandId;
        }
    }
}
