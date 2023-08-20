namespace Domain.Entities.Listings.Sleeping.SleepAccessories
{
    public class SleepAccessory : Sleeping
    {
        public SleepAcessoryType SleepAcessoryType { get; set; }
        public Guid SleepAcessoryTypeId { get; set; }
    }
}
