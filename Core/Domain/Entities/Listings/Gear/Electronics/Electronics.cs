namespace Domain.Entities.Listings.Gear.Electronics
{
    public class Electronics : Gear
    {
        public ElectronicsType ElectronicsType { get; set; }
        public Guid ElectronicsTypeId { get; set; }

        public override void Update(BaseListing updatedListing) {
			base.Update(updatedListing);
			ElectronicsTypeId = ((Electronics)updatedListing).ElectronicsTypeId;
		}  

    }
}
