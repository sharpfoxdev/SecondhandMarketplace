namespace Domain.Entities.Listings
{
    public class Binoculars : Gear
    {
        public BinocularsType BinocularsType { get; set; }
        public Guid BinocularsTypeId { get; set; }

        public override void Update(BaseListing updatedListing)
        {
            base.Update(updatedListing);
            BinocularsTypeId = ((Binoculars)updatedListing).BinocularsTypeId;

        }

    }
}
