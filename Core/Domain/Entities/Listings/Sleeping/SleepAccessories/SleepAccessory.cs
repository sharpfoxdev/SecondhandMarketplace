namespace Domain.Entities.Listings
{
    public class SleepAccessory : Sleeping
    {
        public SleepAcessoryType SleepAcessoryType { get; set; }
        public Guid SleepAcessoryTypeId { get; set; }

        public override void Update(BaseListing updatedListing)
        {
            base.Update(updatedListing);
            SleepAcessoryTypeId = ((SleepAccessory)updatedListing).SleepAcessoryTypeId;

        }
    }
}
