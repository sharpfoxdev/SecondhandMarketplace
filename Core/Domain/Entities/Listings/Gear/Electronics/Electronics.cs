namespace Domain.Entities.Listings.Gear.Electronics
{
    public class Electronics : Gear
    {
        public ElectronicsType ElectronicsType { get; set; }
        public Guid ElectronicsTypeId { get; set; }
    }
}
